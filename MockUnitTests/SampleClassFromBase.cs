﻿namespace MockUnitTests
{
    using System;
    public class SampleClassFromBase : BaseSampleClass
    {
        public override int AdderValue { get; set; }

        public Int32 CallingMultiplyCalc(int val1, int val2)
        {
            var returnval = DoMultiply(val1, val2) + DoMultiply(val1, val2) + AdderValue;
            return returnval;
        }

        public Int32 CallingDivideCalc(int val1, int val2)
        {
            var returnval = DoDivide(val1, val2);
            return returnval;
        }


        public override Int32 DoMultiply(int val1, int val2)
        {
            throw new NotImplementedException();
        }

        public override Int32 DoDivide(int val1, int val2)
        {
            throw new NotImplementedException();
        }
    }
}