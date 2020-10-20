using System;
using System.Text;

namespace Mythic.Package.Spy
{
	public delegate void HashFound( ulong hash, string value );

	public class HashSpy : BaseSpy
	{		
		public event HashFound HashFound;

		private byte[] m_Buffer;

        private const uint StartAddress = 0x500000; //0x665000;
        private const uint EndAddress = 0xAE5000; //0x8E5000;

        private const uint ScanRange = EndAddress - StartAddress;	

		private static ASCIIEncoding m_Encoding = new ASCIIEncoding();

		private uint m_Address;

		public HashSpy() : base()
		{
			m_Buffer = new byte[ ScanRange ];
		}

		private static byte[] m_Signature = new byte[]
		{
			0x59, 0x89, 0x44, 0x24, 0x10, 0x89, 0x54, 0x24, 0x14, 0xEB
		};

		private uint FindBreakPoint()
		{
			m_Buffer = ReadProcessMemory( StartAddress, ScanRange );

			for ( int i = 0; i < m_Buffer.Length - m_Signature.Length; i ++ )
			{
				int j;

				for ( j = 0; j < m_Signature.Length; j ++ )
				{
					if ( m_Buffer[ i + j ] != m_Signature[ j ] )
						break;
				}

				if ( j == m_Signature.Length )
					return (uint) ( StartAddress + i + 1 );
			}

			return 0;
		}

		protected override void InitBreakpoints()
		{
			m_Address = FindBreakPoint();

			if ( m_Address == 0 )
				throw new AddressNotFoundException();

			AddBreakpoint( m_Address );
		}

		protected override void OnSpyAddress( uint address )
		{
			byte[] data = ReadProcessMemory( m_ContextBuffer.Ecx, 256 );
			int length = 0;

			for ( int i = 0; i < data.Length && length == 0; i++ )
				if ( data[ i ] == 0 )
					length = i;

			string name = m_Encoding.GetString( data, 0, length );
			ulong hash = ( (ulong) m_ContextBuffer.Edx << 32 ) | m_ContextBuffer.Eax;

			if ( HashFound != null )
				HashFound( hash, name );
		}
	}
}
