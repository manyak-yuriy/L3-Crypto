using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSALab.Implementation
{
    public class ExtendedGCD
    {
        public static BigInteger[] Extended_GCD(BigInteger A, BigInteger B)
        {
            BigInteger[] result = new BigInteger[3];
            if (A < B) //if A less than B, switch them
            {
                BigInteger temp = A;
                A = B;
                B = temp;
            }
            BigInteger r = B;
            BigInteger q = 0;
            BigInteger x0 = 1;
            BigInteger y0 = 0;
            BigInteger x1 = 0;
            BigInteger y1 = 1;
            BigInteger x = 0, y = 0;
            while (r > 1)
            {
                r = A % B;
                q = A / B;
                x = x0 - q * x1;
                y = y0 - q * y1;
                x0 = x1;
                y0 = y1;
                x1 = x;
                y1 = y;
                A = B;
                B = r;
            }
            result[0] = r;
            result[1] = x;
            result[2] = y;
            return result;
        }

        public static BigInteger ModInverse(BigInteger e, BigInteger m)
        {
            BigInteger[] result = new BigInteger[3];
            result = Extended_GCD(m, e);

            if (result[2] < 0)
                result[2] = result[2] + m;

            return result[2];
        }
    }
}
