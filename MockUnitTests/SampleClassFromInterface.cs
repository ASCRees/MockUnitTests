using System;

namespace MockUnitTests
{
    public class SampleClassFromInterface : ISampleClass
    {
        public int DoMultiply(int val1, int val2)
        {
            throw new NotImplementedException();
        }
    }
}