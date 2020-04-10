using Moq;
using NUnit.Framework;
using System;

namespace MockUnitTests.Tests
{
    public class SampleCalcFromInterfaceTests
    {
        [Test]
        public void Mock_DoCalc_Interface_Perform_Calc()
        {
            //Arrange
            var sampleClass = new Mock<ISampleClass>();
            sampleClass.Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()))
                       .Returns((Int32 a, Int32 b) => a * b);

            ISampleCalc sampleCalc = new SampleCalc(sampleClass.Object);

            //Act
            var multval = sampleCalc.CallingCalcMultiply(3, 2);

            //Assert
            Assert.IsTrue(multval.Equals(6));
        }

        [Test]
        public void Mock_DoCalc_Interface_Verify()
        {
            //Arrange
            var sampleClass = new Mock<ISampleClass>();
            sampleClass.Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()))
                       .Returns((Int32 a, Int32 b) => a * b);

            ISampleCalc sampleCalc = new SampleCalc(sampleClass.Object);

            //Act
            var multval = sampleCalc.CallingCalcMultiply(3, 2);

            //Assert
            sampleClass.Verify(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()), Times.Once);
        }

        [Test]
        public void Mock_DoCalc_Interface_Sequence_Verify()
        {
            //Arrange
            var sampleClass = new Mock<ISampleClass>();
            var mockSequence = new MockSequence();
            sampleClass.InSequence(mockSequence).Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()))
                       .Returns((Int32 a, Int32 b) => a * b);

            ISampleCalc sampleCalc = new SampleCalc(sampleClass.Object);

            //Act
            int toPower = 3;
            var multval = sampleCalc.CalcToPower(2, toPower);

            //Assert
            sampleClass.Verify(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()), Times.Exactly(toPower-1));
        }

        [Test]
        public void Mock_DoCalc_Interface_Sequence_Calc()
        {
            //Arrange
            var sampleClass = new Mock<ISampleClass>();
            var mockSequence = new MockSequence();
            sampleClass.InSequence(mockSequence).Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()))
                       .Returns((Int32 a, Int32 b) => a * b);
            sampleClass.InSequence(mockSequence).Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()))
                       .Returns((Int32 a, Int32 b) => a * b);

            ISampleCalc sampleCalc = new SampleCalc(sampleClass.Object);

            //Act
            int toPower = 3;
            var multval = sampleCalc.CalcToPower(2, toPower);

            //Assert
            Assert.IsTrue(multval.Equals(8));
        }

        [Test]
        public void Mock_DoCalc_Verify_Exception_Thrown_Calc()
        {
            //Arrange
            var sampleClass = new Mock<ISampleClass>();
            sampleClass.Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()))
                       .Returns((Int32 a, Int32 b) => a * b);

            ISampleCalc sampleCalc = new SampleCalc(sampleClass.Object);

            //Act
            int toPower = -1;

            //Assert
            Assert.Throws<ArgumentException>(()=> sampleCalc.CalcToPower(2, toPower));
        }

        [Test]
        public void Mock_DoCalc_Mock_Exception_DivideByZero()
        {
            //Arrange
            var sampleClass = new Mock<ISampleClass>();
            sampleClass.Setup(x => x.DoDivide(It.IsAny<Int32>(), It.IsAny<Int32>()))
                .Throws<DivideByZeroException>();

            ISampleCalc sampleCalc = new SampleCalc(sampleClass.Object);

            //Act
            //Assert
            Assert.Throws<DivideByZeroException>(() => sampleCalc.CallingCalcDivide(10, 2));
        }

    }
}