using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace Mythic.Package.Editor
{
	public interface ISettingsPage
	{
		void Reset();
		bool Verify();
		void Save();
	}

	public class Settings
	{
		#region Constants
		public static string FileName{ get{ return "Settings.xml"; } }

		private static string NodeRoot = "Settings";
		private static string NodeSetting = "Setting";
		private static string NodeName = "Name";
		private static string NodeValue = "Value";
		private static string NodeOption = "Option";
		#endregion

		#region Properties
		private Dictionary<string, SettingEntry> m_Dictionary = new Dictionary<string,SettingEntry>();

		#region Language
		private static string SettingLanguage = "Language";

		public string Language
		{
			get
			{
				return GetValue( SettingLanguage, "Eng.xml" );
			}
			set
			{
				SetValue( SettingLanguage, value );
			}
		}

		public List<string> LanguageOptions
		{
			get
			{
				return GetOptions( SettingLanguage );
			}
		}
		#endregion

		#region OutputPath
		private static string SettingOutputFolder = "OutputFolder";

		public string OutputPath
		{
			get
			{
				return GetValue( SettingOutputFolder, "C:\\" );
			}
			set
			{
				SetValue( SettingOutputFolder, value );
			}
		}
		#endregion

		#region WithInnerPath
		private static string SettingWithInnerPath = "WithInnerPath";

		public bool WithInnerPath
		{
			get
			{
				return GetBool( SettingWithInnerPath, true );
			}
			set
			{
				SetValue( SettingWithInnerPath, value.ToString() );
			}
		}
		#endregion

		#region InnerDirectory
		private static string SettingInnerDirectory = "InnerDirectory";

		public string InnerDirectory
		{
			get
			{
				return GetValue( SettingInnerDirectory, "data/worldart/" );
			}
			set
			{
				SetValue( SettingInnerDirectory, value );
			}
		}

		public List<string> InnerDirectoryOptions
		{
			get
			{
				return GetOptions( SettingInnerDirectory );
			}
		}
		#endregion

		#region SettingsPages
		private static string SettingSettingsPages = "SettingsPages";

		public List<string> SettingsPages
		{
			get
			{
				return GetOptions( SettingSettingsPages );
			}
		}
		#endregion
		#endregion

		#region Constructors
		public Settings()
		{
			string name = null;
			string value = null;

			XmlDocument doc = new XmlDocument();
			doc.Load( FileName );

			XmlNodeList list = doc.GetElementsByTagName( NodeSetting );
			XmlElement element;

			List<string> options = new List<string>();

			element = doc[ NodeRoot ];

			if ( element == null )
				throw new XmlException( String.Format( "{0} is not a setting file.", FileName ) );

			foreach ( XmlNode node in list )
			{
				element = node[ NodeName ];

				if ( element != null )
					name = element.InnerText;

				if ( String.IsNullOrEmpty( name ) )
					continue;

				element = node[ NodeValue ];

				if ( element != null )
					value = element.InnerText;

				options = new List<string>();

				foreach ( XmlNode child in node.ChildNodes )
				{
					if ( String.Equals( child.Name, NodeOption ) )
					{
						options.Add( child.InnerText );
					}
				}

				m_Dictionary.Add( name, new SettingEntry( value, options ) );
			}
		}
		#endregion

		#region GetValue
		public string GetValue( string name, string defaultValue )
		{
			SettingEntry entry = null;

			if ( m_Dictionary.TryGetValue( name, out entry ) )
				return entry.Value;

			return defaultValue;
		}
		#endregion

		#region GetBool
		public bool GetBool( string name, bool defaultValue )
		{
			SettingEntry entry = null;

			if ( m_Dictionary.TryGetValue( name, out entry ) )
			{
				bool result;

				if ( Boolean.TryParse( entry.Value, out result ) )
					return result;
			}

			return defaultValue;
		}
		#endregion

		#region SetValue
		public void SetValue( string name, string value )
		{
			SettingEntry entry = null;

			if ( m_Dictionary.TryGetValue( name, out entry ) )
				entry.Value = value;

			else
				m_Dictionary.Add( name, new SettingEntry( value, new List<string>() ) );
		}

		public void AddInnerDirectory( string dir )
        {
			SettingEntry entry = null;

			if ( m_Dictionary.TryGetValue( SettingInnerDirectory, out entry ) )
				entry.Options.Add( dir );
		}
		#endregion

		#region GetOptions
		public List<string> GetOptions( string name )
		{
			SettingEntry entry = null;

			if ( m_Dictionary.TryGetValue( name, out entry ) )
				return entry.Options;

			return null;
		}
		#endregion

		#region Save
		public void Save()
		{
			if ( File.Exists( FileName ) )
				File.Delete( FileName );

			XmlTextWriter writer = new XmlTextWriter( FileName, Encoding.UTF8 );

			writer.Formatting = Formatting.Indented;
			writer.WriteProcessingInstruction( "xml", "version='1.0' encoding='UTF-8'" );
			writer.WriteStartElement( NodeRoot );

			foreach ( KeyValuePair<string, SettingEntry> kvp in m_Dictionary )
			{
				writer.WriteStartElement( NodeSetting );

				writer.WriteElementString( NodeName, kvp.Key );
				writer.WriteElementString( NodeValue, kvp.Value.Value );

				foreach ( string option in kvp.Value.Options )
					writer.WriteElementString( NodeOption, option );

				writer.WriteEndElement();
			}

			writer.WriteEndElement();
			writer.Flush();
			writer.Close();
		}
		#endregion

		#region SettingEntry
		private class SettingEntry
		{
			#region Value
			private string m_Value;

			public string Value
			{
				get{ return m_Value; }
				set{ m_Value = value; }
			}
			#endregion

			#region Options
			private List<string> m_Options;

			public List<string> Options
			{
				get{ return m_Options; }
			}
			#endregion

			public SettingEntry( string value, List<string> options )
			{
				m_Value = value;
				m_Options = options;
			}
		}
		#endregion
	}
}
