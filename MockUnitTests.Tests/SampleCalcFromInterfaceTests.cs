using Moq;
using NUnit.Framework;
using System;

namespace MockUnitTests.Tests
{
    public class SampleCalcFromInterfaceTests
    {
        [Test]
        public void Mock_DoCalc2()
        {
            //Arrange
            var sampleClass = new Mock<ISampleClass>();
            sampleClass.Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()))
                       .Returns((Int32 a, Int32 b) => a * b);

            ISampleCalc sampleCalc = new SampleCalc(sampleClass.Object);

            //Act
            var multval = sampleCalc.CallingCalc(3, 2);

            //Assert
            Assert.IsTrue(multval.Equals(106));
        }
    }
}