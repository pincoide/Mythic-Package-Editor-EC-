using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Mythic.Package.Editor
{
    /// <summary>
    /// Class with the tools to execute the brute force search
    /// </summary>
    public class BruteForce
    {
		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// list of all possible output of the verify entry
		/// </summary>
		public enum CreateEntryResults
        {
			succecss = 0,
			IncompletePatterns = 1,
			MismatchLength = 2,
			InvalidCharacters = 3,
			EndMustBeGreaterThanStart = 4,
			StartAndEndAreTheSame = 5
		}

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// Get the brute force patterns from a string (if any)
		/// </summary>
		/// <param name="keyword">text to get the search patterns from</param>
		/// <param name="patterns">list of patterns that we have found in the keyword</param>
		/// <returns>Do we have at least 1 valid pattern?</returns>
		public static CreateEntryResults VerifyBruteForcePattern( string keyword, out List<BruteForceEntry> patterns )
		{
			// initialize a list of patterns
			patterns = new List<BruteForceEntry>();

			// find all the brute force patterns
            MatchCollection m = Regex.Matches( keyword, @"\{(\w+)\-(\w+)\}" );

			// scan the patterns and create the entry
			foreach ( Match mtc in m )
            {
				try
                {
					// split the first and second part
					string firstPart = mtc.Groups[1].Value;
					string secondPart = mtc.Groups[2].Value;

					// make sure both parts are different
					if ( firstPart == secondPart )
						return CreateEntryResults.StartAndEndAreTheSame;

					// make sure both parts have the same length
					if ( firstPart.Length != secondPart.Length )
						return CreateEntryResults.MismatchLength;

					// make sure there are only valid characters
					if ( firstPart.Where( c => BruteForceEntry.AllowedCharacters.All( c2 => c2 != c ) ).Count() > 0 || secondPart.Where( c => BruteForceEntry.AllowedCharacters.All( c2 => c2 != c ) ).Count() > 0 )
						return CreateEntryResults.InvalidCharacters;

					// make sure the starting part is smaller than the end
					if ( GetParameterValue( firstPart.ToCharArray() ) > GetParameterValue( secondPart.ToCharArray() ) )
						return CreateEntryResults.EndMustBeGreaterThanStart;

					// create the brute force entry
					patterns.Add( new BruteForceEntry( mtc.Index, mtc.Length, firstPart.ToCharArray(), secondPart.ToCharArray(), mtc.Value, keyword ) );

				}
				catch { }
			}

			return patterns.Count > 0 ? CreateEntryResults.succecss : CreateEntryResults.IncompletePatterns;
		}

		/// <summary>
		/// Generate the next brute force string with the given patterns
		/// </summary>
		/// <param name="entries">Patterns to use to generate the string</param>
		public static string GetNextBruteString( ref List<BruteForceEntry> entries )
        {
			// initialize all the entries
			InitializeResults( ref entries );

			// get the index of the last entry in the list.
			// we generate the string from right to left
			int lastEntry = entries.Count - 1;

			// get the current entry
			BruteForceEntry entry = entries[lastEntry];

			// create the results for the next pattern
			while ( entry.GetNextBruteResult() && lastEntry > 0 )
            {
				// set the index of the previous entry
				lastEntry--;

				// get the entry
				entry = entries[lastEntry];
			}

			// return a possible final string with the current results
			return DoReplacement( ref entries );
		}

		/// <summary>
		/// Determine if all the brute force entries are completed
		/// </summary>
		/// <param name="entries">brute force entries to check</param>
		/// <returns>are all entries completed?</returns>
		public static bool AllEntriesCompleted( ref List<BruteForceEntry> entries )
        {
			// scan all the entries
			foreach( BruteForceEntry entry in entries )
            {
				// if at least 1 entry is incomplete, we return false
				if ( !entry.Completed )
					return false;
            }

			// if we got here all entries are completed
			return true;
        }

		#endregion

		// --------------------------------------------------------------
		#region LOCAL FUNCTIONS
		// --------------------------------------------------------------

		private static void InitializeResults( ref List<BruteForceEntry> entries )
        {
			// scan all the entries
			foreach ( BruteForceEntry entry in entries )
            {
				// reset the completed flag
				entry.Completed = false;

				// is the current result null? get one then...
				if ( entry.CurrentString == null )
					entry.GetNextBruteResult();
			}
		}

		/// <summary>
		/// Do the replacements on the original string to generate the final result
		/// </summary>
		/// <param name="entries">Patterns to use to generate the string</param>
		/// <returns>Final string with the current results</returns>
		private static string DoReplacement( ref List<BruteForceEntry> entries )
        {
			// initialize the final string to return
			string final = entries[0].OriginalString;

			// create the string builder
			StringBuilder builder = new StringBuilder();

			// scan all the entries
			foreach ( BruteForceEntry entry in entries.Reverse<BruteForceEntry>() )
			{
				// reset the string builder
				builder.Clear();

				// add the part of the string from the beginning to the starting point
				builder.Append( final.Substring( 0, entry.StartIndex ) );

				// add the result
				builder.Append( new string( entry.CurrentString ) );

				// add the last part of the string
				builder.Append( final.Substring( entry.StartIndex + entry.Length ) );

				// update the final string
				final = builder.ToString();
			}

			return builder.ToString();
		}

		/// <summary>
		/// Calculate the value of a parameter (used to determine if start > end for example)
		/// </summary>
		/// <param name="param">parameter to measure</param>
		/// <returns>Numeric measurement of the parameter</returns>
		private static int GetParameterValue( char[] param )
        {
			// sum the index value of each character to get the value of the array
			return param.Select( c => Array.IndexOf(BruteForceEntry.AllowedCharacters, c) ).Sum();
        }

		#endregion
	}

	/// <summary>
	/// Parameters for the brute force search
	/// </summary>
	public class BruteForceEntry
	{
		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// list of all the allowed characters in the pattern
		/// </summary>
		public static readonly char[] AllowedCharacters = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '_', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

		/// <summary>
		/// starting index in the original string to do the replacement
		/// </summary>
		public int StartIndex { get; set; }

		/// <summary>
		/// Total length of the pattern
		/// </summary>
		public int Length { get; set; }

		/// <summary>
		/// set of chars to start with
		/// </summary>
		public char[] StartPattern { get; set; }

		/// <summary>
		/// set of chars to end with
		/// </summary>
		public char[] EndPattern { get; set; }

		/// <summary>
		/// full string of the original pattern
		/// </summary>
		public string OriginalPattern { get; set; }

		/// <summary>
		/// original string to brute force
		/// </summary>
		public string OriginalString { get; set; }

		/// <summary>
		/// current characters set we are trying
		/// </summary>
		public char[] CurrentString { get; set; }

		/// <summary>
		/// Flag indicating if we have only numbers
		/// </summary>
		public bool IsNumeric { get; set; }

		/// <summary>
		/// Flag indicating that we reached the last combination possible
		/// </summary>
		public bool Completed { get; set; }

		#endregion

		// --------------------------------------------------------------
		#region CONSTRUCTOR
		// --------------------------------------------------------------

		/// <summary>
		/// Create a brute force entry
		/// </summary>
		/// <param name="startIndex">start index of the current pattern</param>
		/// <param name="length">length of the current pattern</param>
		/// <param name="startPattern">set of chars to start with</param>
		/// <param name="endPattern">set of chars to end with</param>
		/// <param name="originalPattern">full string of the original pattern</param>
		/// <param name="originalString">original string to brute force</param>
		public BruteForceEntry( int startIndex, int length, char[] startPattern, char[] endPattern, string originalPattern, string originalString )
		{
			// store the staring parameters
			StartIndex = startIndex;
			Length = length;
			StartPattern = startPattern;
			EndPattern = endPattern;
			OriginalPattern = originalPattern;
			OriginalString = originalString;

			// are both start and end pattern numbers? if so flag that is a numberic progression
			if ( int.TryParse( new string( startPattern ), out _ ) && int.TryParse( new string( EndPattern ), out _ ) )
				IsNumeric = true;
		}

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// Generate the next brute force result for the entry
		/// </summary>
		/// <returns>next result for the search entry</returns>
		public bool GetNextBruteResult()
		{
			// is the progression numeric? then calculate the next number in the progression
			if ( IsNumeric )
				GetNextNumericEntry();

			else // calculate the next characters set in the progression
				GetNextCharsEntry();

			// determine if we have to increase the previous entry
			return Completed;
		}

		#endregion

		// --------------------------------------------------------------
		#region LOCAL FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// Calculate the next number in the pattern sequence
		/// </summary>
		public void GetNextNumericEntry()
		{
			// if the entry is not numeric, we can g et out...
			if ( !IsNumeric )
				return;

			// get the starting number
			long startNumber = long.Parse( new string( StartPattern ) );

			// get the ending number
			long endNumber = long.Parse( new string( EndPattern ) );

			// initialize the current number to the starting value
			long currentNumber = startNumber - 1;

			// if we have a current value, we use that instead
			if ( CurrentString != null && !Completed )
				currentNumber = long.Parse( new string( CurrentString ) );

			// initialize the leading zeroes string
			string leadZero = "";

			// fill the correct number of leading zeroes
			for ( int k = 0; k < StartPattern.Length; k++ )
				leadZero += "0";

			// if the sequence was completed we restart from the beginning
			if ( Completed )
				Completed = false;

			// did we reach the end value?
			if ( currentNumber < endNumber )
			{
				// increase the current number
				currentNumber++;

				// calculate the next number
				CurrentString =  currentNumber.ToString( leadZero ).ToCharArray();

				// if we reached the last number, we flag the sequence completed
				if ( currentNumber == endNumber )
					Completed = true;
			}
		}

		/// <summary>
		/// Get the next char entry
		/// </summary>
		public void GetNextCharsEntry()
		{
			// if we have no current string, we use the start pattern and we're done
			if ( CurrentString == null )
            {
				// set the current string as starting pattern
				CurrentString = (char[])StartPattern.Clone();

				return;
			}

			// get the last "digit" of our char sequence
			int lastDigit = GetLastDigit();

			// increase each "digit" of the characters sequence as a number
			while ( IncreaseDigit( lastDigit ) && lastDigit > 0 )
				lastDigit--;

			// when the current string is the same as the final pattern, the search is complete.
			if ( new string( CurrentString ) == new string( EndPattern ) )
				Completed = true;
		}

		/// <summary>
		/// Get the last "digit" of the character set
		/// </summary>
		/// <returns>last "digit" of the character set</returns>
		private int GetLastDigit()
        {
			// we search the last "digit" in case it's a fixed value
			for ( int i = CurrentString.Length - 1; i >= 0; i-- )
			{
				// get the index of the starting character for this position
				int startIdx = Array.IndexOf( AllowedCharacters, StartPattern[i] );

				// get the index of the last character for this position
				int lastIdx = Array.IndexOf( AllowedCharacters, EndPattern[i] );

				// if the first and last char of the sequence are different, then we found our last "digit"
				if ( startIdx != lastIdx )
					return i;
			}

			// it should never get here unless the start and end pattern are exactly the same
			return CurrentString.Length - 1;
		}

		/// <summary>
		/// Increase the "digit" at the current character position
		/// </summary>
		/// <param name="index">"digit" to increase</param>
		/// <returns>do we have to increase the next digit?</returns>
		private bool IncreaseDigit( int index )
        {
			// get the index of the starting character for this position
			int startIdx = Array.IndexOf( AllowedCharacters, StartPattern[index] );

			// get the index of the last character for this position
			int lastIdx = Array.IndexOf( AllowedCharacters, EndPattern[index] );

			// get the index of the current character
			int currIdx = Array.IndexOf( AllowedCharacters, CurrentString[index] );

			// is there another "digit" after this one in the pattern?
			if ( currIdx + 1 <= lastIdx )
			{
				// "increase" the character
				CurrentString[index] = AllowedCharacters[currIdx + 1];

				return false;
			}
			else // no more "digits" for this position
            {
				// reset the character at this position
				CurrentString[index] = AllowedCharacters[startIdx];

				// we need to increase the next "digit"
				return true;
			}
		}

		#endregion
	}
}
