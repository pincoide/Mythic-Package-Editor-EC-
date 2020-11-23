using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace Mythic.Package.Editor
{
	/// <summary>
	/// Language manager class
	/// </summary>
	public class LanguageManager
	{
		// --------------------------------------------------------------
		#region PRIVATE VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Main language dictionary
		/// </summary>
		private readonly Dictionary<string, string> m_Language = new Dictionary<string,string>();

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Active language name
		/// </summary>
		public string LanguageName { get; }

		#endregion

		// --------------------------------------------------------------
		#region CONSTRUCTOR
		// --------------------------------------------------------------

		/// <summary>
		/// Initialize the language
		/// </summary>
		public LanguageManager()
		{
			// clear the current language dictionary
			m_Language.Clear();

			// Load the xml
			XDocument xdoc = XDocument.Load( Globals.Settings.Language );

			// get the language name
			LanguageName = xdoc.Root.FirstAttribute.Value;

			// load the language data
			m_Language = ( from lang in xdoc.Descendants( "entry" )
						   select new
						   {
							   key = lang.Attribute( "key" ).Value,
							   value = lang.Value
						   }
						 ).ToDictionary( itm => itm.key, itm => itm.value );
		}

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// Get a string from the dictionary
		/// </summary>
		/// <param name="key">Key to search</param>
		/// <param name="param">Parameters to fill</param>
		/// <returns>String text from the dictionary (with filled parameters)</returns>
		public string GetString( string key, params string[] param )
		{
			// get the key from the dictionary
			if ( m_Language.TryGetValue( key, out string value ) )
			{
                // do we have parameters to fill? if so, we fill them
                return param.Length > 0 ? string.Format( value, param ) : value;
            }

            return string.Empty;
		}

		#endregion
	}
}
