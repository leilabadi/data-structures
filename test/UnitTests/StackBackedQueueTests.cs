namespace DataStructures.UnitTests;

public class StackBackedQueueTests
{
    [Fact]
    public void Test1()
    {
        // Arrange
        IQueue<int> sut = new StackBackedQueue<int>();

        // Act
        sut.Enqueue(23);

        // Assert
        sut.IsEmpty().Should().BeFalse();
        sut.Count.Should().Be(1);
        sut.Front.Should().Be(23);
    }
}