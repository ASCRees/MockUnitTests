using System;

namespace MockUnitTests
{
    public class SampleClassFromBase : BaseSampleClass
    {
        public override Int32 CallingCalc(int val1, int val2)
        {
            var returnval = DoMultiply(val1, val2) + DoMultiply(val1, val2) + 100;
            return returnval;
        }

        public override Int32 DoMultiply(int val1, int val2)
        {
            throw new NotImplementedException();
        }
    }
}