using System;
using System.IO;
using System.Security.AccessControl;

namespace Mythic.Package.Editor
{
	public class Logger
	{
		#region FileName
		private static string m_FileName = "Log";

		public static string FileName
		{
			get
			{
				return String.Format( "Logs\\{0} {1}.txt", m_FileName, DateTime.Now.ToShortDateString() );
			}
		}
		#endregion

		private TextWriter m_LogFile;
		private string m_LogName;

		#region Constructors
		public Logger( string fileName )
		{
			string dir = Path.GetDirectoryName( fileName );

			if ( !Directory.Exists( dir ) )
				Directory.CreateDirectory( dir );

			m_LogName = fileName;
			m_LogFile = new StreamWriter( m_LogName, true );
		}
		#endregion

		#region Logging
		public void LogException( Exception e )
		{
			m_LogFile.WriteLine( String.Format( "{0}: {1}", DateTime.Now, e.Message ) );
			m_LogFile.WriteLine( String.Format( "       Stack trace: {0}", e.StackTrace ) );
			m_LogFile.WriteLine( "---------------------------------------------------------------------------------------------------" );
			m_LogFile.Flush();
		}

		public void LogMessage( string message )
		{
			m_LogFile.WriteLine( String.Format( "{0}: {1}", DateTime.Now, message ) );
			m_LogFile.Flush();
		}
		#endregion

		#region Close
		public void Close()
		{
			m_LogFile.Close();
		}
		#endregion
	}
}
