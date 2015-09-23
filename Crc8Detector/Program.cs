using System;

namespace Crc8Detector
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var examples = new[]
            {
                new CrcExample("07 00 01 50 ff 37 37", 0x0a),
                new CrcExample("07 00 02 50 ff 37 37", 0x44),
                new CrcExample("07 00 03 50 ff 37 37", 0x89),
                new CrcExample("07 00 04 50 ff 37 37", 0xd8),
                new CrcExample("07 00 05 50 ff 37 37", 0x15),
                new CrcExample("16 54 d8 54 23 00 00 00 00 00 00 00 00 00 20 20 20 20 20 00 00 00", 0xf2),
                new CrcExample("16 54 d8 54 80 00 00 2e 20 00 2f c2 01 0a 20 20 20 20 20 00 00 00", 0x6e),
                new CrcExample("19 48 aa 54 80 00 00 2c 20 20 20 20 20 20 20 20 20 20 20 20 20 00 00 00 00", 0x5d)
            };
            var result = Crc8AlgorithmDetector.DetectFor(examples);
            Console.WriteLine(result);
        }
    }
}
