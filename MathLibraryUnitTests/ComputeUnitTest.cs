using MathLibrary;

using Moq;

using NUnit.Framework;

namespace Tests
{
    public class ComputeUnitTest
    {
        private Compute _compute;

        private Mock<IOperations> _operationsMock;
        
        [SetUp]
        public void Setup()
        {
            _operationsMock = new Mock<IOperations>();
            _compute = new Compute(_operationsMock.Object);
        }

        [Test]
        public void PerformOperationsReturnsExpectedResult()
        {
            // Arrange
            int expected = 30;
            int complexOperationResult = 12;
            int basicOperationResult = 18;
            int a = 20;
            int b = 15;
            int c = 78;

            _operationsMock.Setup(x => x.DoBasicOperation(a, b)).Returns(basicOperationResult);
            _operationsMock.Setup(x => x.DoComplexOperation(b, c)).Returns(complexOperationResult);

            // Act
            int actual = _compute.PerformOperations(a, b, c);
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PerformOperationsReturnsCallsExpectedServices()
        {
            // Arrange
            int complexOperationResult = 12;
            int basicOperationResult = 18;
            int a = 20;
            int b = 15;
            int c = 78;

            _operationsMock.Setup(x => x.DoBasicOperation(a, b)).Returns(basicOperationResult);
            _operationsMock.Setup(x => x.DoComplexOperation(b, c)).Returns(complexOperationResult);

            // Act
            _compute.PerformOperations(a, b, c);

            // Assert
            _operationsMock.Verify(x => x.DoBasicOperation(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            _operationsMock.Verify(x => x.DoBasicOperation(a, b), Times.Once);

            _operationsMock.Verify(x => x.DoComplexOperation(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            _operationsMock.Verify(x => x.DoComplexOperation(b, c), Times.Once);
        }
    }
}
