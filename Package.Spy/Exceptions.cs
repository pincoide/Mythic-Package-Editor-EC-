using System;

namespace Mythic.Package.Spy
{
    public class AddressNotFoundException : Exception
    {
        public AddressNotFoundException() : base( "Cannot find hash function address!" )
        {
        }
    }
}
