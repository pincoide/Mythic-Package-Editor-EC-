using System;
using System.Diagnostics;
using System.Collections.Generic;

using Mythic.Package;
using Mythic.Package.Spy;

namespace Mythic.Package.Editor
{
	public class DictionaryArgs
	{
		public const int LOAD = 0;
		public const int SAVE = 1;
		public const int MERGE = 2;

		private string m_Name;
		private int m_Action;

		public string Name{ get{ return m_Name; } }
		public bool Load{ get{ return m_Action == 0; } }
		public bool Save{ get{ return m_Action == 1; } }
		public bool Merge{ get{ return m_Action == 2; } }

		public DictionaryArgs( string name, int action )
		{
			m_Name = name;
			m_Action = action;
		}
	}

	public class LoadMythicPackageArgs
	{
		private string[] m_Names;
		private MythicPackage[] m_Result;

		public string[] Names{ get{ return m_Names; } }

		public MythicPackage[] Result
		{ 
			get{ return m_Result; } 
			set{ m_Result = value; }
		}

		public LoadMythicPackageArgs( string[] names )
		{
			m_Names = names;
			m_Result = null;
		}
	}

	public class SaveMythicPackageArgs
	{
		private MythicPackage m_Package;
		private string m_FileName;

		public MythicPackage Package{ get{ return m_Package; } }
		public string FileName{ get{ return m_FileName; } }

		public SaveMythicPackageArgs( MythicPackage package, string fileName )
		{
			m_Package = package;
			m_FileName = fileName;
		}
	}

	public class UnpackMythicPackageArgs
	{
		public const int PACKAGE = 0;
		public const int BLOCK = 1;
		public const int FILE = 2;

		private int m_Action;
		public bool IsPackage{ get{ return m_Action == 0; } }
		public bool IsBlock{ get{ return m_Action == 1; } }
		public bool IsFile{ get{ return m_Action == 2; } }

		private MythicPackage m_Package;
		private MythicPackageBlock m_Block;
		private MythicPackageFile[] m_Files;
		private string m_Folder;
		private bool m_FullPath;

		public MythicPackage Package{ get{ return m_Package; } }
		public MythicPackageBlock Block{ get{ return m_Block; } }
		public MythicPackageFile[] Files{ get{ return m_Files; } }
		public string Folder{ get{ return m_Folder; } }
		public bool FullPath{ get{ return m_FullPath; } }

		public UnpackMythicPackageArgs( MythicPackage package, string folder, bool fullPath )
		{
			m_Action = PACKAGE;
			m_Package = package;
			m_Folder = folder;
			m_FullPath = fullPath;
		}

		public UnpackMythicPackageArgs( MythicPackageBlock block, string folder, bool fullPath )
		{
			m_Action = BLOCK;
			m_Block = block;
			m_Folder = folder;
			m_FullPath = fullPath;
		}

		public UnpackMythicPackageArgs( MythicPackageFile[] files, string folder, bool fullPath )
		{
			m_Action = FILE;
			m_Files = files;
			m_Folder = folder;
			m_FullPath = fullPath;
		}
	}

	public class SpyProcessArgs
	{
		private HashSpy m_HashSpy;
		private Process m_Process;
		
		public HashSpy HashSpy{ get{ return m_HashSpy; } }
		public Process Process{ get{ return m_Process; } }

		public SpyProcessArgs( HashSpy hashSpy, Process process )
		{
			m_HashSpy = hashSpy;
			m_Process = process;
		}
	}

	public class SpyPathArgs
	{
		private HashSpy m_HashSpy;
		private string m_Path;
		
		public HashSpy HashSpy{ get{ return m_HashSpy; } }		
		public string Path{ get{ return m_Path; } }

		public SpyPathArgs( HashSpy hashSpy, string path )
		{
			m_HashSpy = hashSpy;
			m_Path = path;
		}
	}

	public class SearchExpressionArgs
	{
		private object m_Source;
		private List<SearchExpressionEntry> m_Entries;
		private char[] m_After;
		private int m_Length;
		private int m_Found;
		
		public object Source{ get{ return m_Source; } }
		public List<SearchExpressionEntry> Entries { get { return m_Entries; } }
		public int Length { get { return m_Length; } }
		public char[] After{ get{ return m_After; } }

		public int Found
		{ 
			get{ return m_Found; } 
			set{ m_Found = value; } 
		}

		public SearchExpressionArgs( object source, List<SearchExpressionEntry> entries, char[] after, int length )
		{
			m_Source = source;
			m_Entries = entries;
			m_After = after;
			m_Length = length;
		}
	}

	public class SearchExpressionEntry
	{
		private char[] m_Before;
		private char[] m_From;
		private char[] m_To;
		private int m_Start;
		private int m_End;

		public char[] Before { get { return m_Before; } }
		public char[] From { get { return m_From; } }
		public char[] To { get { return m_To; } }
		public int Start { get { return m_Start; } }
		public int End { get { return m_End; } }

		public SearchExpressionEntry( char[] before, char[] from, char[] to, int start, int end )
		{
			m_Before = before;
			m_From = from;
			m_To = to;
			m_Start = start;
			m_End = end;
		}
	}
}
