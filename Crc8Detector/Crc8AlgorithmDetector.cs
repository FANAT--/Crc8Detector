using System.Collections.Generic;

namespace Crc8Detector
{
    public static class Crc8AlgorithmDetector
    {
        public static Crc8DetectionResult DetectFor(CrcExample[] examples)
        {
            var counter = 0;
            foreach (var polynom in EnumerateBytes())
                foreach (var initial in EnumerateBytes())
                    foreach (var finalXor in EnumerateBytes())
                        foreach (var refIn in EnumerateBooleans())
                            foreach (var refOut in EnumerateBooleans())
                            {
                                ++counter;
                                var matchAll = true;
                                foreach (var example in examples)
                                {
                                    if (Crc8.Calculate(example.Data, polynom, initial, finalXor, refIn, refOut) == example.Crc8)
                                        continue;
                                    matchAll = false;
                                    break;
                                }
                                if (matchAll)
                                    return new Crc8DetectionResult(polynom, initial, finalXor, refIn, refOut, counter);
                            }
            return new Crc8DetectionResult(counter);
        }

        private static IEnumerable<byte> EnumerateBytes()
        {
            for (var i = 0; i < 256; i++)
                yield return (byte)i;
        }

        private static IEnumerable<bool> EnumerateBooleans()
        {
            yield return false;
            yield return true;
        }
    }
}
