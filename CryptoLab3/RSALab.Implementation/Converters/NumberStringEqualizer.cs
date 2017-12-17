using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSALab.Implementation.Converters
{
    public static class NumberStringEqualizer
    {
        public static string BigIntToStringEquivalent(BigInteger number)
        {
            var toBytes = number.ToByteArray();

            string str = Encoding.Unicode.GetString(toBytes);

            return str;
        }

        public static BigInteger StringToBigIntegerEquivalent(string str)
        {
            byte[] toBytes = Encoding.Unicode.GetBytes(str);

            var number = new BigInteger(toBytes);

            return number;
        }
    }
}
