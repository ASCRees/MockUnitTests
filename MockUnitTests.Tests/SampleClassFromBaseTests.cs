using Moq;
using NUnit.Framework;
using System;

namespace MockUnitTests.Tests
{
    [TestFixture]
    public class MockingUnitTest1
    {
        [Test]
        public void Mock_DoMultiply()
        {
            //Arrange
            Mock<ISampleClass> sampleClass = new Mock<ISampleClass>();
            sampleClass.Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>())).Returns((Int32 a, Int32 b) => a * b);
            //Act
            var multval = sampleClass.Object.DoMultiply(3, 2);

            //Assert
            Assert.IsTrue(multval.Equals(6));
        }

        [Test]
        public void Mock_DoCalc()
        {
            //Arrange
            var sampleClass = new Mock<SampleClassFromBase>();
            sampleClass.CallBase = true;
            sampleClass.Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>())).Returns((Int32 a, Int32 b) => a * b);
            //Act
            var multval = sampleClass.Object.CallingCalc(3, 2);

            //Assert
            sampleClass.Verify(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>()), Times.Exactly(2));
        }

        [Test]
        public void Mock_DoCalc2()
        {
            //Arrange
            var sampleClass = new Mock<SampleClassFromBase>();
            sampleClass.CallBase = true;
            sampleClass.Setup(x => x.DoMultiply(It.IsAny<Int32>(), It.IsAny<Int32>())).Returns((Int32 a, Int32 b) => a * b);
            //Act
            var multval = sampleClass.Object.CallingCalc(3, 2);

            //Assert
            Assert.IsTrue(multval.Equals(112));
        }
    }
}