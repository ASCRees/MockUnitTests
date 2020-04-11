namespace MockUnitTests
{
    using System;
    public class SampleCalc : ISampleCalc
    {
        private ISampleClass _sampleClass;

        public SampleCalc(ISampleClass sampleClass)
        {
            _sampleClass = sampleClass;
        }

        public int CallingCalcMultiply(int val1, int val2)
        {          
            var returnval = _sampleClass.DoMultiply(val1, val2);
            return returnval;
        }

        public int CallingCalcDivide(int val1, int val2)
        {
            var returnval = _sampleClass.DoDivide(val1, val2);
            return returnval;
        }

        public int CalcToPower(int Value, int toPowerOf)
        {
            int rollingResult = 0;
            if (toPowerOf > 0)
            {
                rollingResult = Value;

                for (int i = 2; i <= toPowerOf; i++)
                {
                    rollingResult = _sampleClass.DoMultiply(rollingResult, Value);
                }

            }
            else
            {
                throw new ArgumentException("toPowerOf cannot be less than 0");
            }

            return rollingResult;
        }

    }
}