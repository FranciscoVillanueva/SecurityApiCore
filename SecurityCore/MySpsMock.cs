using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityCore
{
    public class MySpsMock : MySps
    {
        public override string DesencriptaSp(byte[] hash)
        {
            if (hash.SequenceEqual(new byte[] { 1 }))
            {
                return "pass1";
            }
            else if (hash.SequenceEqual(new byte[] { 2 }))
            {
                return "pass2";
            }
            else if (hash.SequenceEqual(new byte[] { 3 }))
            {
                return "pass3";
            }
            else
            {
                return "wrong";
            }
        }

        public override byte[] EncriptaSp(string word)
        {
            if (word == "pass1")
            {
                return new byte[] { 1 };
            }
            else if (word == "pass2")
            {
                return new byte[] { 2 };
            }
            else if (word == "pass3")
            {
                return new byte[] { 3 };
            }
            else
            {
                return new byte[] { };
            }
        }
    }
}
