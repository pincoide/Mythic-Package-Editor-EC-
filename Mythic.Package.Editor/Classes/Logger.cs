using System;
using System.IO;

namespace Mythic.Package.Editor
{
	/// <summary>
	/// Log file manager class
	/// </summary>
	public class Logger
	{
		// --------------------------------------------------------------
		#region PRIVATE VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Main file writer
		/// </summary>
		private readonly TextWriter m_LogFile;

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Get the current file name used by the logger
		/// </summary>
		public string FileName { get; set; }

		#endregion

		// --------------------------------------------------------------
		#region CONSTRUCTOR
		// --------------------------------------------------------------

		/// <summary>
		/// Initialize the logger
		/// </summary>
		public Logger()
		{
			// generate the log file name
			FileName = string.Format( "Logs\\Log {0}.txt", DateTime.Now.ToShortDateString() );

			// get the log file path
			string dir = Path.GetDirectoryName( FileName );

			// if the folder doesn't exist, we create it
			if ( !Directory.Exists( dir ) )
				Directory.CreateDirectory( dir );

			// create the file writer
			m_LogFile = new StreamWriter( FileName, true );
		}

		#endregion

		// --------------------------------------------------------------
		#region LOCAL EVENTS
		// --------------------------------------------------------------

		/// <summary>
		/// Close the file writer
		/// </summary>
		public void Close()
		{
			// terminate the streamwriter
			m_LogFile.Close();

			// dispose the streamwriter
			m_LogFile.Dispose();
		}

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// Write an exception in the log file
		/// </summary>
		/// <param name="e">exception to write in the log</param>
		public void Log( Exception e )
		{
			// write the exception message
			m_LogFile.WriteLine( string.Format( "{0}: {1}", DateTime.Now, e.Message ) );

			// add the exception data to the log
			foreach ( object key in e.Data.Keys )
				m_LogFile.WriteLine( string.Format( "      {0}: {1}", key.ToString(), e.Data[key].ToString() ) );

			// write the exception stack trace (where to locate the error)
			m_LogFile.WriteLine( string.Format( "       Stack trace: {0}", e.StackTrace ) );

			// write a separator
			m_LogFile.WriteLine( "---------------------------------------------------------------------------------------------------" );

			// execute the file write
			m_LogFile.Flush();
		}

		/// <summary>
		/// Write a custom message in the log
		/// </summary>
		/// <param name="message">message to log</param>
		public void Log( string message )
		{
			// write the message in the log
			m_LogFile.WriteLine( string.Format( "{0}: {1}", DateTime.Now, message ) );

			// execute the file write
			m_LogFile.Flush();
		}

		#endregion
	}
}
