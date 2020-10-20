using System;
using System.Xml;
using System.Collections.Generic;

using Mythic.Package.Editor.Properties;

namespace Mythic.Package.Editor
{
	public class LanguageManager
	{
		#region Constants
		private static string NodeRoot = "Language";
		private static string NodeLanguageName = "name";
		private static string NodeKey = "key";
		#endregion

		#region LanguageName
		private string m_LanguageName;
 
		public string LanguageName
		{
			get{ return m_LanguageName; }
		}
		#endregion

		#region Collection
		private Dictionary<string, string> m_Language = new Dictionary<string,string>();
		#endregion

		#region Constructors
		public LanguageManager()
		{
			m_Language.Clear();

			string key = null;
			string value = null;

			XmlDocument doc = new XmlDocument();
			doc.Load( Globals.Settings.Language );

			XmlElement root = doc[ NodeRoot ];

			if ( root != null )
			{
				m_LanguageName = root.GetAttribute( NodeLanguageName );

				foreach ( XmlNode node in root.ChildNodes )
				{
					if ( node.Attributes == null )
						continue;

					foreach ( XmlAttribute attr in node.Attributes )
					{
						if ( String.Equals( attr.Name, NodeKey ) )
							key = attr.Value;
					}

					value = node.InnerText;

					if ( !String.IsNullOrEmpty( key ) && !String.IsNullOrEmpty( value ) )
						m_Language.Add( key, value );					
				}
			}
			else
				throw new XmlException( String.Format( "{0} is not a language file.", Globals.Settings.Language ) );
		}
		#endregion

		#region GetString
		public string GetString( string key, params string[] param )
		{
			string value;

			if ( m_Language.TryGetValue( key, out value ) )
			{
				if ( param.Length > 0 )
					return String.Format( value, param );

				return value;
			}

			return String.Empty;
		}
		#endregion
	}
}
