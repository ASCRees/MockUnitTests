namespace MockUnitTests.Tests
{
    using Moq;
    using NUnit.Framework;
    using System;

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
            sampleClass.Object.AdderValue = 100;
            var multval = sampleClass.Object.CallingMultiplyCalc(3, 2);

            //Assert
            sampleClass.Verify(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()), Times.Exactly(2));
        }

        [Test]
        public void Mock_Verify_CallMultipleCalc_Returns_22()
        {
            //Arrange
            var sampleClass = new Mock<SampleClassFromBase>();
            sampleClass.CallBase = true;
            sampleClass.Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>())).Returns((Int32 a, Int32 b) => a * b);
           
            sampleClass.SetupProperty(x => x.AdderValue,10);
            //Act
            var multval = sampleClass.Object.CallingMultiplyCalc(3, 2);

            //Assert
            Assert.IsTrue(multval.Equals(22));
        }

        [Test]
        public void Mock_Verify_CallMultipleCalc_Verify_Property_Set()
        {
            //Arrange
            var sampleClass = new Mock<SampleClassFromBase>();
            sampleClass.CallBase = true;
            sampleClass.Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>())).Returns((Int32 a, Int32 b) => a * b);

            sampleClass.SetupProperty(x => x.AdderValue, 20);
            //Act
            sampleClass.Object.AdderValue = 20;
            var multval = sampleClass.Object.CallingMultiplyCalc(5, 4);

            //Assert
            sampleClass.VerifySet(x => x.AdderValue = 20);
        }
    }
}