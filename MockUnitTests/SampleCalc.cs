namespace MockUnitTests
{
    public class SampleCalc : ISampleCalc
    {
        private ISampleClass _sampleClass;

        public SampleCalc(ISampleClass sampleClass)
        {
            _sampleClass = sampleClass;
        }

        public int CallingCalc(int val1, int val2)
        {
            var returnval = _sampleClass.DoMultiply(val1, val2) + 100;
            return returnval;
        }
    }
}