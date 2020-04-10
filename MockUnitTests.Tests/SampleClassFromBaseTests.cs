using Moq;
using NUnit.Framework;
using System;

namespace MockUnitTests.Tests
{
    [TestFixture]
    public class SampleCalcFromBaseClassTests
    {
        [Test]
        public void Mock_DoMultiply()
        {
            //Arrange
            var sampleClass = new Mock<SampleClassFromBase>();

            sampleClass.Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()))
                .Returns((Int32 a, Int32 b) => a * b);

            //Act
            var multval = sampleClass.Object.DoMultiply(3, 2);

            //Assert
            Assert.IsTrue(multval.Equals(6));
        }

        [Test]
        public void Mock_DoCalc_Mock_Exception_DivideByZero()
        {
            //Arrange
            var sampleClass = new Mock<SampleClassFromBase>();
            sampleClass.Setup(x => x.DoDivide(It.IsAny<Int32>(), It.IsAny<Int32>()))
                .Throws<DivideByZeroException>();


            //Act
            //Assert
            Assert.Throws<DivideByZeroException>(() => sampleClass.Object.CallingDivideCalc(10, 2));
        }

        [Test]
        public void Mock_Verify_DoMultiply_Called_Twice()
        {
            //Arrange
            var sampleClass = new Mock<SampleClassFromBase>();
            sampleClass.CallBase = true;
            sampleClass.Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>())).Returns((Int32 a, Int32 b) => a * b);
            //Act
            var multval = sampleClass.Object.CallingMultiplyCalc(3, 2);

            //Assert
            sampleClass.Verify(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()), Times.Exactly(2));
        }

        [Test]
        public void Mock_Verify_CallMultipleCalc_Returns_112()
        {
            //Arrange
            var sampleClass = new Mock<SampleClassFromBase>();
            sampleClass.CallBase = true;
            sampleClass.Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>())).Returns((Int32 a, Int32 b) => a * b);
            //Act
            var multval = sampleClass.Object.CallingMultiplyCalc(3, 2);

            //Assert
            Assert.IsTrue(multval.Equals(112));
        }
    }
}