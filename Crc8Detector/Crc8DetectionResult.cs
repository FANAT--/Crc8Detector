namespace Crc8Detector
{
    public struct Crc8DetectionResult
    {
        private readonly bool _succeed;
        private readonly byte _polynom;
        private readonly byte _initial;
        private readonly byte _finalXor;
        private readonly bool _refIn;
        private readonly bool _refOut;
        private readonly int _counter;

        public Crc8DetectionResult(byte polynom, byte initial, byte finalXor, bool refIn, bool refOut, int counter)
        {
            _succeed = true;
            _polynom = polynom;
            _initial = initial;
            _finalXor = finalXor;
            _refIn = refIn;
            _refOut = refOut;
            _counter = counter;
        }

        public Crc8DetectionResult(int counter)
        {
            _succeed = false;
            _counter = counter;
            _polynom = 0;
            _initial = 0;
            _finalXor = 0;
            _refIn = false;
            _refOut = false;
        }

        public bool Succeed
        {
            get { return _succeed; }
        }

        public byte Polynom
        {
            get { return _polynom; }
        }

        public byte Initial
        {
            get { return _initial; }
        }

        public byte FinalXor
        {
            get { return _finalXor; }
        }

        public bool RefIn
        {
            get { return _refIn; }
        }

        public bool RefOut
        {
            get { return _refOut; }
        }

        public int Counter
        {
            get { return _counter; }
        }

        public override string ToString()
        {
            return string.Format("Succeed: {0}, calculation steps: {1}, polynom: {2:X2}, initial: {3:X2}, finalFor: {4:X2}, refIn: {5}, refOut: {6}",
                _succeed, _counter, _polynom, _initial, _finalXor, _refIn, _refOut);
        }
    }
}
