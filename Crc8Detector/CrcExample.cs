using System;
using System.Linq;

namespace Crc8Detector
{
    public class CrcExample
    {
        public readonly byte Crc8;
        public readonly byte[] Data;

        public CrcExample(string hex, byte crc8)
        {
            while (hex.Contains(' '))
                hex = hex.Replace(" ", "");
            Data = StringToByteArrayFastest(hex);
            Crc8 = crc8;
        }

        private static byte[] StringToByteArrayFastest(string hex) // http://stackoverflow.com/a/9995303/1453092
        {   
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");
            var arr = new byte[hex.Length >> 1];
            for (var i = 0; i < hex.Length >> 1; ++i)
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            return arr;
        }

        private static int GetHexVal(char hex)
        {
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return hex - (hex < 58 ? 48 : (hex < 97 ? 55 : 87));
        }
    }
}
