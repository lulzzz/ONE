using System;
using System.Linq;

namespace ONE.Common.Utility
{
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Bytes the array to hexadecimal string.
        /// </summary>
        /// <param name="ba">The ba.</param>
        /// <returns></returns>
        public static string ByteArrayToHexString(this byte[] ba)
        {
            return ba.ByteArrayToHexString(String.Empty);
        }

        /// <summary>
        /// Bytes the array to hexadecimal string.
        /// </summary>
        /// <param name="ba">The ba.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static string ByteArrayToHexString(this byte[] ba, string separator)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", separator);
        }

        /// <summary>
        /// Takes a string of Hexadecimal values and turns it into a byte array
        /// </summary>
        /// <param name="hex">The hexadecimal.</param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        /// <summary>
        /// Sums the specified start index.
        /// </summary>
        /// <param name="ba">The ba.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static int Sum(this byte[] ba, int startIndex, int length)
        {
            //Initialize the sum
            int sum = 0;

            //Iterate the byte array and add the values to the sum
            for (int i = startIndex; i < length; i++)
            {
                sum += ba[i];
            }

            //return the sum
            return sum;
        }
    }

}
