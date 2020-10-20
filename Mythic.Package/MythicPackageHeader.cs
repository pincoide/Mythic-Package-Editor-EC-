using System;
using System.IO;
using System.Collections.Generic;

namespace Mythic.Package
{
	/// <summary>
	/// Class describing .uop file header.
	/// </summary>
	public class MythicPackageHeader
	{
		#region SupportedVersion
		/// <summary>
		/// Supported version.
		/// </summary>
		public static int SupportedVersion{ get{ return 5; } }
		#endregion

		#region DefaultMisc
		/// <summary>
		/// Default misc value.
		/// </summary>
		public static uint DefaultMisc{ get{ return 0xFD23EC43; } }
		#endregion

		#region DefaultStartAddress
		/// <summary>
		/// Default start address.
		/// </summary>
		public static int DefaultStartAddress{ get{ return 0x200; } }
		#endregion

		#region DefaultBlockSize
		/// <summary>
		/// Default <see cref="Mythic.Package.MythicPackageHeader.BlockSize"/>.
		/// </summary>
		public static int DefaultBlockSize{ get{ return 1000; } }
		#endregion

		#region Version
		private int m_Version;

		/// <summary>
		/// Version of .uop format.
		/// </summary>
		public int Version
		{
			get{ return m_Version; }
			set{ m_Version = value; }
		}
		#endregion

		#region Misc
		private uint m_Misc;

		/// <summary>
		/// Probably format release date and time
		/// </summary>
		public uint Misc
		{
			get{ return m_Misc; }
			set{ m_Misc = value; }
		}
		#endregion

		#region StartAddress
		private long m_StartAddress;

		/// <summary>
		/// Start of the first <see cref="Mythic.Package.MythicPackageBlock"/>.
		/// </summary>
		public long StartAddress
		{
			get{ return m_StartAddress; }
			set{ m_StartAddress = value; }
		}
		#endregion

		#region BlockSize
		private int m_BlockSize;

		/// <summary>
		/// Maximum amount of files that one <see cref="Mythic.Package.MythicPackageBlock"/> can hold.
		/// </summary>
		public int BlockSize
		{
			get{ return m_BlockSize; }
			set{ m_BlockSize = value; }
		}
		#endregion

		#region FileCount
		private int m_FileCount;

		/// <summary>
		/// Number if files in this .uop file.
		/// </summary>
		public int FileCount
		{
			get{ return m_FileCount; }
			set{ m_FileCount = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public MythicPackageHeader( int version )
		{
			m_Version = version;
			m_Misc = DefaultMisc;
			m_StartAddress = DefaultStartAddress;
			m_BlockSize = DefaultBlockSize;

			m_FileCount = 0;
		}

		/// <summary>
		/// Creates a new instance from <paramref name="reader"/>.
		/// </summary>
		/// <param name="reader">Binary file (.uop source).</param>
		public MythicPackageHeader( BinaryReader reader )
		{
			byte[] id = reader.ReadBytes( 4 );

			if ( id[ 0 ] != 'M' || id[ 1 ] != 'Y' || id[ 2 ] != 'P' || id[ 3 ] != 0 )
				throw new FormatException( "This is not a Mythic Package file!" );

			m_Version = reader.ReadInt32();

			if ( m_Version > SupportedVersion )
				throw new FormatException( "Unsupported version!" );

			m_Misc = reader.ReadUInt32();
			m_StartAddress = reader.ReadInt64();

			m_BlockSize = reader.ReadInt32();
			m_FileCount = reader.ReadInt32();
		}
		#endregion

		#region Save
		/// <summary>
		/// Saves .uop header to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">Binary file (.uop destination).</param>
		public void Save( BinaryWriter writer )
		{
			writer.Write( (byte) 'M' );
			writer.Write( (byte) 'Y' );
			writer.Write( (byte) 'P' );
			writer.Write( (byte) 0x0 );

			writer.Write( m_Version );
			writer.Write( m_Misc );
			writer.Write( m_StartAddress );
			writer.Write( m_BlockSize );
			writer.Write( m_FileCount );

			for ( int i = 28; i < m_StartAddress; i++ )
				writer.Write( (byte) 0x0 );
		}
		#endregion
	}
}
