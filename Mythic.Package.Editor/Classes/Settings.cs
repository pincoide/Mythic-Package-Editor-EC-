using System;
using System.Linq;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Mythic.Package.Editor
{
	/// <summary>
	/// Class to handle settings
	/// </summary>
	public class Settings
	{
		// --------------------------------------------------------------
		#region PRIVATE VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Setting variable
		/// </summary>
		private class SettingEntry
		{
			/// <summary>
			/// Setting value
			/// </summary>
			public string Value { get; set; }

			/// <summary>
			/// Setting options
			/// </summary>
			public List<string> Options { get; }

			/// <summary>
			/// Create the setting
			/// </summary>
			/// <param name="value">setting value</param>
			/// <param name="options">setting options</param>
			public SettingEntry( string value, List<string> options )
			{
				Value = value;
				Options = options;
			}
		}

		/// <summary>
		/// Main settings dictionary
		/// </summary>
		private readonly Dictionary<string, SettingEntry> m_Dictionary = new Dictionary<string,SettingEntry>();

		/// <summary>
		/// Language setting name
		/// </summary>
		private static readonly string SettingLanguage = "Language";

		/// <summary>
		/// Output folder setting name
		/// </summary>
		private static readonly string SettingOutputFolder = "OutputFolder";

		/// <summary>
		/// Save with relative path setting name
		/// </summary>
		private static readonly string SettingWithInnerPath = "WithInnerPath";

		/// <summary>
		/// Relative paths list setting name
		/// </summary>
		private static readonly string SettingInnerDirectory = "InnerDirectory";

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Main setting file name
		/// </summary>
		public static string FileName { get; } = "Settings.xml";

		/// <summary>
		/// Language setting value
		/// </summary>
		public string Language { get => GetValue( SettingLanguage, "Eng.xml" ); set => SetValue( SettingLanguage, value ); }

        /// <summary>
        /// List of all the available languages
        /// </summary>
        public List<string> LanguageOptions => GetOptions( SettingLanguage );

        /// <summary>
        /// Output path setting value
        /// </summary>
        public string OutputPath
        {
            get => GetValue( SettingOutputFolder, Path.Combine( Application.StartupPath, "Output" ) );
            set => SetValue( SettingOutputFolder, value );
        }

        /// <summary>
        /// Use relative path setting
        /// </summary>
        public bool WithInnerPath { get => GetValue( SettingWithInnerPath, true ); set => SetValue( SettingWithInnerPath, value.ToString() ); }

        /// <summary>
        /// List of the saved relative paths
        /// </summary>
        public List<string> InnerDirectoryOptions => GetOptions( SettingInnerDirectory );

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Initialize the settings
        /// </summary>
        public Settings()
		{
			// Load the xml
			XDocument xdoc = XDocument.Load( FileName );

			// make sure is a settings file
			if ( xdoc.Descendants( "Settings" ).Count() <= 0 )
				throw new XmlException( string.Format( "{0} is not a setting file.", FileName ) );

			// get all the settings nodes
			List<XElement> elms = xdoc.Descendants("Setting").ToList();

			// scan all the setting nodes
			foreach ( XElement el in elms )
			{
				// get the name node
				XElement name = el.Descendants( "Name" ).FirstOrDefault();

				// if there is no name, we can move to the next setting
				if ( name != null && string.IsNullOrEmpty( name.Value ) )
					continue;

				// get the name node
				XElement value = el.Descendants( "Value" ).FirstOrDefault();

				// if there is no name, we can move to the next setting
				if ( value != null && string.IsNullOrEmpty( value.Value ) )
					continue;

				// intialize the options list
				List<string> options = new List<string>();

				// get the options (if there are any)
				foreach ( XElement subEl in el.Descendants( "Option" ) )
					options.Add( subEl.Value );

				// store the setting
				m_Dictionary.Add( name.Value, new SettingEntry( value.Value, options ) );
			}
		}

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// Get setting value
		/// </summary>
		/// <param name="name">setting name</param>
		/// <param name="defaultValue">default value to use</param>
		/// <returns>setting value</returns>
		public string GetValue( string name, string defaultValue )
		{
			// get the setting value
			if ( m_Dictionary.TryGetValue( name, out SettingEntry entry ) )
			{
                // is the setting a string?
                return entry.Value.GetType() == typeof( string ) ? !string.IsNullOrEmpty( entry.Value ) ? entry.Value : defaultValue : entry.Value;
            }

			return defaultValue;
		}

		/// <summary>
		/// Get setting value
		/// </summary>
		/// <param name="name">setting name</param>
		/// <param name="defaultValue">default value to use</param>
		/// <returns>setting value</returns>
		public bool GetValue( string name, bool defaultValue )
		{
			// get the setting value
			if ( m_Dictionary.TryGetValue( name, out SettingEntry entry ) )
			{
				// convert the value to boolean
				if ( bool.TryParse( entry.Value, out bool result ) )
					return result;
			}

			return defaultValue;
		}

		/// <summary>
		/// Set the setting value
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public void SetValue( string name, string value )
		{
			// get the current setting value and replace it
			if ( m_Dictionary.TryGetValue( name, out SettingEntry entry ) )
				entry.Value = value;

			else // if it's a new setting, we add it to the dictionary
				m_Dictionary.Add( name, new SettingEntry( value, new List<string>() ) );
		}

		/// <summary>
		/// Add new relative paths
		/// </summary>
		/// <param name="dirs">list of paths to add</param>
		/// <param name="clearFirst">do we have to clear the current list first? (default: true)</param>
		public void AddInnerDirectory( List<string> dirs, bool clearFirst = true )
		{
			// get the setting data
			if ( m_Dictionary.TryGetValue( SettingInnerDirectory, out SettingEntry entry ) )
			{
				// do we have to clear the list first?
				if ( clearFirst )
					entry.Options.Clear();

				// add the new data
				entry.Options.AddRange( dirs );
			}
		}

		/// <summary>
		/// Add a new relative path
		/// </summary>
		/// <param name="dir">path to add</param>
		/// <param name="avoidDuplicates">DO NOT add the path if already exist. (default: true)</param>
		public void AddInnerDirectory( string dir, bool avoidDuplicates = true )
		{
			// does the setting exist?
			if ( m_Dictionary.TryGetValue( SettingInnerDirectory, out SettingEntry entry ) )

				// if the path exist and we DO NOT avoid duplicates or the path doesn't exist, we add it to the list
				if ( ( entry.Options.Contains( dir ) && !avoidDuplicates ) || !entry.Options.Contains( dir ) )
					entry.Options.Add( dir );
		}

		/// <summary>
		/// Get the options list for the setting
		/// </summary>
		/// <param name="name">setting name</param>
		/// <returns>list of options for the setting</returns>
		public List<string> GetOptions( string name )
		{
            // does the setting exist? if it does get the options
            return m_Dictionary.TryGetValue( name, out SettingEntry entry ) ? entry.Options : null;
        }

        /// <summary>
        /// Save the settings
        /// </summary>
        public void Save()
		{
			try
            {
				// delete the existing file
				if ( File.Exists( FileName ) )
					File.Delete( FileName );

				// create a new xml document
				XDocument xdoc = new XDocument();

				// create the root element
				xdoc.Add( new XElement( "Settings" ) );

				// parse all settings
				foreach ( KeyValuePair<string, SettingEntry> kvp in m_Dictionary )
				{
					// create the setting node
					XElement elm = new XElement( "Setting" );

					// create the setting name child
					XElement child = new XElement( "Name" )
					{
						Value = kvp.Key
					};

					// add the child node to the setting
					elm.Add( child );

					// create the setting value child
					child = new XElement( "Value" )
					{
						Value = kvp.Value.Value
					};

					// add the child node to the setting
					elm.Add( child );

					// parse the options
					foreach ( string option in kvp.Value.Options )
                    {
						// create the option child
						child = new XElement( "Option" )
						{
							Value = option
						};

						// add the child node to the setting
						elm.Add( child );
					}

					// add the setting to the root of the file
					xdoc.Root.Add( elm );
				}

				// save the settings file
				xdoc.Save( FileName );
			}
			catch ( Exception ex )
            {
				// in case something goes wrong, log the exception
				Globals.Logger.Log( ex );
			}
		}

		#endregion
	}
}
