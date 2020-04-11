namespace MockUnitTests
{
    using System;
    public abstract class BaseSampleClass
    {
        public abstract int AdderValue { get; set; }
        public abstract Int32 DoMultiply(int val1, int val2);
        public abstract Int32 DoDivide(int val1, int val2);
    }
}