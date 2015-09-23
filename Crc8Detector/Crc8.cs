namespace Crc8Detector
{
    public static class Crc8
    {
        private static readonly byte[] Reversed = new byte[256]; // байты с обратным порядком битов

        static Crc8()
        {
            for (var i = 0; i < Reversed.Length; i++)
                Reversed[i] = ReverseInternal((byte)i);
        }

        public static byte Calculate(byte[] data, byte polynom, byte initial, byte finalXor, bool refIn, bool refOut)
        {
            var crc = initial;
            foreach (var b in data)
            {
                var temp = crc ^ (refIn ? Reversed[b] : b);
                for (var j = 0; j < 8; j++)
                {
                    if ((temp & 0x80) != 0) // старший бит = 1
                        temp = (temp << 1) ^ polynom;
                    else // старший бит = 0
                        temp = temp << 1;
                }
                crc = (byte)temp;
            }
            if (refOut)
                crc = Reversed[crc];
            return (byte)(crc ^ finalXor);
        }

        private static byte ReverseInternal(byte b)
        {
            var result = 0;
            for (var i = 0; i < 8; i++)
                result += ((b >> 8-i-1) & 1) << i;
            return (byte)result;
        }
    }
}
