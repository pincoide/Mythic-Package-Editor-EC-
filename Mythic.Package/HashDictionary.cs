using System;
using System.Collections.Generic;
using System.IO;

namespace Mythic.Package
{
    /// <summary>
    /// Handles .uop hashing.
    /// </summary>
    public static class HashDictionary
    {
        // --------------------------------------------------------------
        #region PRIVATE VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Active dictionary
        /// </summary>
        private static readonly Dictionary<ulong,string> m_Dictionary = new Dictionary<ulong,string>();

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Default dictionary file name.
        /// </summary>
        public static string FileName { get; private set; } = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "Dictionary.dic" );

        /// <summary>
        /// Was this dictionary modified?
        /// </summary>
        public static bool Modified { get; private set; } = false;

        /// <summary>
        /// Number of new hashes since load. Resets upon save.
        /// </summary>
        public static int NewHashes { get; private set; }

        /// <summary>
        /// Number of new file names since load. Resets upon save.
        /// </summary>
        public static int NewFileNames { get; private set; }

        /// <summary>
        /// List of all the new file names added since the last save.
        /// </summary>
        public static List<ulong> AddedFilenames { get; set; } = new List<ulong>();

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        /// Computes Adler32 hash of the <paramref name="d"/>.
        /// </summary>
        /// <param name="d">Data to hash.</param>
        /// <returns>Adler32 hash.</returns>
        public static uint HashDataBlock( byte[] d )
        {
            uint a = 1;
            uint b = 0;

            for ( int i = 0; i < d.Length; i++ )
            {
                a = ( a + d[i] ) % 0xFFF1;
                b = ( b + a ) % 0xFFF1;
            }

            return ( b << 16 ) | a;
        }

        /// <summary>
        /// Computes KR hash of the <paramref name="s"/>.
        /// </summary>
        /// <param name="s">String to hash.</param>
        /// <returns>Hashed string.</returns>
        public static ulong HashFileName( string s )
        {
            // we turn the string to a char array and run the other overload
            return HashFileName( s.ToCharArray() );
        }

        /// <summary>
        /// Computes KR hash of the <paramref name="s"/>.
        /// </summary>
        /// <param name="s">Char array to hash.</param>
        /// <returns>Hashed string.</returns>
        public static ulong HashFileName( char[] s )
        {
            uint eax, ecx, edx, ebx, esi, edi;

            eax = 0;

            ebx = edi = esi = (uint)s.Length + 0xDEADBEEF;

            int i;

            for ( i = 0; i + 12 < s.Length; i += 12 )
            {
                edi = (uint)( ( s[i + 7] << 24 ) | ( s[i + 6] << 16 ) | ( s[i + 5] << 8 ) | s[i + 4] ) + edi;
                esi = (uint)( ( s[i + 11] << 24 ) | ( s[i + 10] << 16 ) | ( s[i + 9] << 8 ) | s[i + 8] ) + esi;
                edx = (uint)( ( s[i + 3] << 24 ) | ( s[i + 2] << 16 ) | ( s[i + 1] << 8 ) | s[i] ) - esi;

                edx = ( edx + ebx ) ^ ( esi >> 28 ) ^ ( esi << 4 );
                esi += edi;
                edi = ( edi - edx ) ^ ( edx >> 26 ) ^ ( edx << 6 );
                edx += esi;
                esi = ( esi - edi ) ^ ( edi >> 24 ) ^ ( edi << 8 );
                edi += edx;
                ebx = ( edx - esi ) ^ ( esi >> 16 ) ^ ( esi << 16 );
                esi += edi;
                edi = ( edi - ebx ) ^ ( ebx >> 13 ) ^ ( ebx << 19 );
                ebx += esi;
                esi = ( esi - edi ) ^ ( edi >> 28 ) ^ ( edi << 4 );
                edi += ebx;
            }

            if ( s.Length - i > 0 )
            {
                switch ( s.Length - i )
                {
                    case 12:
                        esi += (uint)s[i + 11] << 24;
                        goto case 11;
                    case 11:
                        esi += (uint)s[i + 10] << 16;
                        goto case 10;
                    case 10:
                        esi += (uint)s[i + 9] << 8;
                        goto case 9;
                    case 9:
                        esi += s[i + 8];
                        goto case 8;
                    case 8:
                        edi += (uint)s[i + 7] << 24;
                        goto case 7;
                    case 7:
                        edi += (uint)s[i + 6] << 16;
                        goto case 6;
                    case 6:
                        edi += (uint)s[i + 5] << 8;
                        goto case 5;
                    case 5:
                        edi += s[i + 4];
                        goto case 4;
                    case 4:
                        ebx += (uint)s[i + 3] << 24;
                        goto case 3;
                    case 3:
                        ebx += (uint)s[i + 2] << 16;
                        goto case 2;
                    case 2:
                        ebx += (uint)s[i + 1] << 8;
                        goto case 1;
                    case 1:
                        ebx += s[i];
                        break;
                    default:
                        break;
                }

                esi = ( esi ^ edi ) - ( ( edi >> 18 ) ^ ( edi << 14 ) );
                ecx = ( esi ^ ebx ) - ( ( esi >> 21 ) ^ ( esi << 11 ) );
                edi = ( edi ^ ecx ) - ( ( ecx >> 7 ) ^ ( ecx << 25 ) );
                esi = ( esi ^ edi ) - ( ( edi >> 16 ) ^ ( edi << 16 ) );
                edx = ( esi ^ ecx ) - ( ( esi >> 28 ) ^ ( esi << 4 ) );
                edi = ( edi ^ edx ) - ( ( edx >> 18 ) ^ ( edx << 14 ) );
                eax = ( esi ^ edi ) - ( ( edi >> 8 ) ^ ( edi << 24 ) );

                return ( (ulong)edi << 32 ) | eax;
            }

            return ( (ulong)esi << 32 ) | eax;
        }

        /// <summary>
        /// Loads dictionary from <paramref name="fileName"/>.
        /// </summary>
        /// <param name="fileName">Path to dictionary file.</param>
        public static void LoadDictionary( string fileName )
        {
            // empty file name? throw an exception
            if ( string.IsNullOrEmpty( fileName ) )
                throw new ArgumentException( "fileName" );

            // if the file doesn't exist, throw an exception
            if ( !File.Exists( fileName ) )
                throw new Exception( string.Format( "Cannot find {0}!", Path.GetFileName( fileName ) ) );

            // open the dictionary
            using ( FileStream stream = new FileStream( fileName, FileMode.Open ) )
            using ( BinaryReader reader = new BinaryReader( stream ) )
            {
                // read the header
                byte[] id = reader.ReadBytes( 4 );

                // is this a correct header?
                if ( id[0] != 'D' || id[1] != 'I' || id[2] != 'C' || id[3] != 0 )
                    throw new Exception( string.Format( "{0} is not a Dictionary file!", Path.GetFileName( fileName ) ) );

                // clear the current dictionary data
                m_Dictionary.Clear();

                // get the version
                int version = reader.ReadByte();

                // start reading the file from the current position till the end
                while ( stream.Position < stream.Length )
                {
                    // get the hash
                    ulong hash = reader.ReadUInt64();

                    // initialize the string name as null
                    string name = null;

                    // read the name if we have it
                    if ( reader.ReadByte() == 1 )
                        name = reader.ReadString();

                    // if the hash is not already inside the dictionary, we add it and pair it with the name
                    if ( !m_Dictionary.ContainsKey( hash ) )
                        m_Dictionary.Add( hash, name );
                }
            }

            // store the dictionary file name
            FileName = fileName;

            // reset the dictionary unsaved changes flags
            AddedFilenames.Clear();
            NewHashes = 0;
            NewFileNames = 0;
            Modified = false;
        }

        /// <summary>
        /// Saves dictionary to <paramref name="fileName"/>.
        /// </summary>
        /// <param name="fileName">Path on the HD.</param>
        public static void SaveDictionary( string fileName )
        {
            // make sure the file name is viable
            if ( Path.GetFileName( fileName ).IndexOfAny( Path.GetInvalidFileNameChars() ) >= 0 )
                throw new Exception( string.Format( "Invalid file name {0}!", Path.GetFileName( fileName ) ) );

            // open the file to write
            using ( FileStream stream = new FileStream( fileName, FileMode.Create, FileAccess.Write ) )
            using ( BinaryWriter writer = new BinaryWriter( stream ) )
            {
                // save the header
                writer.Write( 'D' );
                writer.Write( 'I' );
                writer.Write( 'C' );
                writer.Write( (byte)0 );

                // save the version
                writer.Write( (byte)1 );

                // scan the active dictionary
                foreach ( KeyValuePair<ulong, string> kvp in m_Dictionary )
                {
                    // write the hash
                    writer.Write( kvp.Key );

                    // do we have the file name?
                    if ( kvp.Value != null )
                    {
                        // write the flag indicating the name is available
                        writer.Write( (byte)1 );

                        // write the file name
                        writer.Write( kvp.Value );
                    }
                    else // write the flag indicating the name is NOT available
                        writer.Write( (byte)0 );
                }
            }

            // reset the dictionary unsaved changes flags
            AddedFilenames.Clear();
            NewHashes = 0;
            NewFileNames = 0;
            Modified = false;
        }

        /// <summary>
        /// Merges loaded dictionary with another dictionary.
        /// </summary>
        /// <param name="fileName">Location of the second dictionary.</param>
        public static void MergeDictionary( string fileName )
        {
            // empty file name? throw an exception
            if ( string.IsNullOrEmpty( fileName ) )
                throw new ArgumentException( "fileName" );

            // if the file doesn't exist, throw an exception
            if ( !File.Exists( fileName ) )
                throw new Exception( string.Format( "Cannot find {0}!", Path.GetFileName( fileName ) ) );

            // open the SECOND dictionary (the one to merge in the active one)
            using ( FileStream stream = new FileStream( fileName, FileMode.Open ) )
            using ( BinaryReader reader = new BinaryReader( stream ) )
            {
                // read the header
                byte[] id = reader.ReadBytes( 4 );

                // is this a correct header?
                if ( id[0] != 'D' || id[1] != 'I' || id[2] != 'C' || id[3] != 0 )
                    throw new Exception( string.Format( "{0} is not a Dictionary file!", Path.GetFileName( fileName ) ) );

                // get the version
                int version = reader.ReadByte();

                // start reading the file from the current position till the end
                while ( stream.Position < stream.Length )
                {
                    // get the hash
                    ulong hash = reader.ReadUInt64();

                    // initialize the string name as null
                    string name = null;

                    // read the name if we have it
                    if ( reader.ReadByte() == 1 )
                        name = reader.ReadString();

                    // does the hash exist?
                    if ( m_Dictionary.ContainsKey( hash ) )
                    {
                        // is the hash without a file name, and this new dictionary has one?
                        if ( m_Dictionary[hash] == null && !string.IsNullOrEmpty( name ) )
                        {
                            // add the name to the dictionary
                            m_Dictionary[hash] = name;

                            // set that we have a new name
                            NewFileNames += 1;

                            // flag that the dictionary has changed
                            Modified = true;
                        }
                    }
                    else // new hash
                    {
                        // add the hash to the dictionary
                        m_Dictionary.Add( hash, name );

                        // set that we have a new hash
                        NewHashes += 1;

                        // set that we have a new name (if we have a file name)
                        if ( name != null )
                            NewFileNames += 1;

                        // flag that the dictionary has changed
                        Modified = true;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if <paramref name="hash"/> is in the dictionary.
        /// </summary>
        /// <param name="hash">File name hash.</param>
        /// <returns>True if found, false otherwise.</returns>
        public static bool Contains( ulong hash )
        {
            return m_Dictionary.ContainsKey( hash );
        }

        /// <summary>
        /// Tries to retrieve file name binded to <paramref name="hash"/>.
        /// </summary>
        /// <param name="hash">File name hash.</param>
        /// <param name="add">Adds if hash doesn't exist.</param>
        /// <returns>File name.</returns>
        public static string Get( ulong hash, bool add )
        {
            // is the hash available? then return the name (if we have one)
            if ( m_Dictionary.ContainsKey( hash ) )
                if ( m_Dictionary.TryGetValue( hash, out string name ) )
                    return name;

            // do we have to add this new hash?
            if ( add )
            {
                // add the new hash
                m_Dictionary.Add( hash, null );

                // set that we have a new hash
                NewHashes += 1;

                // flag that the dictionary has changed
                Modified = true;
            }

            return null;
        }

        /// <summary>
        /// Tries to add <paramref name="name"/> binded to <paramref name="hash"/> to the dictionary. Doulbe
        /// </summary>
        /// <param name="hash">File name hash.</param>
        /// <param name="name">File name.</param>
        /// <returns>True if successful, false otherwise.</returns>
        public static bool Set( ulong hash, string name )
        {
            // is the hash available?
            if ( m_Dictionary.ContainsKey( hash ) )
            {
                // get the current file name for the hash
                string value = m_Dictionary[hash];

                // was the name missing?
                if ( value == null )
                {
                    // set the new file name for the hash
                    m_Dictionary[hash] = name;

                    // add the hash to the list of the new hashes
                    AddedFilenames.Add( hash );

                    // set that we have a new name
                    NewFileNames += 1;

                    // flag that the dictionary has changed
                    Modified = true;

                    return true;
                }
            }
            else
            {
                // add the hash to the list of the new hashes
                AddedFilenames.Add( hash );

                // set that we have a new hash
                NewHashes += 1;

                // set that we have a new name
                NewFileNames += 1;

                // flag that the dictionary has changed
                Modified = true;

                // add the new hash with the file name to the dictionary
                m_Dictionary.Add( hash, name );
            }

            return false;
        }

        /// <summary>
        /// Removes the file name with the specified hash from the dictionary.
        /// </summary>
        /// <param name="hash">The hash of the file name to remove.</param>
        /// <returns>true if the file name is successfully found and removed; otherwise, false.</returns>
        public static bool Unset( ulong hash )
        {
            // does this hash exist and has a file name?
            if ( m_Dictionary.ContainsKey( hash ) && m_Dictionary[hash] != null )
            {
                // remove the file name
                m_Dictionary[hash] = null;

                // set that we have one less file names
                NewFileNames -= 1;

                // flag that the dictionary has changed
                Modified = true;

                return true;
            }

            return false;
        }

        #endregion
    }
}
