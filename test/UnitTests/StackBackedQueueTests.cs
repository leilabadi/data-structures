namespace DataStructures.UnitTests;

public class StackBackedQueueTests
{
    private readonly Faker faker;

    public StackBackedQueueTests()
    {
        faker = new Faker();
    }

    private int GetRandomNumber()
    {
        return faker.Random.Int(1, 1000);
    }

    [Fact]
    public void Enqueue_ShouldStoreCorrectNumber_WhenPassingANumber()
    {
        // Arrange
        int num1 = GetRandomNumber();

        IQueue<int> sut = new StackBackedQueue<int>();

        // Act
        sut.Enqueue(num1);

        // Assert
        sut.IsEmpty().Should().BeFalse();
        sut.Peak().Should().Be(num1);
    }

    [Fact]
    public void Dequeue_ShouldReturnInFirstInFirstOutOrder_WhenPassingMultipleNumbers()
    {
        // Arrange
        int num1 = GetRandomNumber();
        int num2 = GetRandomNumber();
        int num3 = GetRandomNumber();

        IQueue<int> sut = new StackBackedQueue<int>();
        sut.Enqueue(num1);
        sut.Enqueue(num2);
        sut.Enqueue(num3);

        // Act
        int returnNum1 = sut.Dequeue();
        int returnNum2 = sut.Dequeue();
        int returnNum3 = sut.Dequeue();


        // Assert
        returnNum1.Should().Be(num1);
        returnNum2.Should().Be(num2);
        returnNum3.Should().Be(num3);
    }

    [Fact]
    public void IsEmpty_PassingMultipleNumbers_ShouldReturnACorrectValueInEachStep()
    {
        // Arrange
        int num1 = GetRandomNumber();
        int num2 = GetRandomNumber();
        int num3 = GetRandomNumber();

        IQueue<int> sut = new StackBackedQueue<int>();

        // Act and Assert
        sut.IsEmpty().Should().BeTrue();

        sut.Enqueue(num1);
        sut.IsEmpty().Should().BeFalse();
        sut.Enqueue(num2);
        sut.IsEmpty().Should().BeFalse();
        sut.Enqueue(num3);
        sut.IsEmpty().Should().BeFalse();

        sut.Dequeue();
        sut.IsEmpty().Should().BeFalse();
        sut.Dequeue();
        sut.IsEmpty().Should().BeFalse();
        sut.Dequeue();
        sut.IsEmpty().Should().BeTrue();
    }

    [Fact]
    public void Peak_ShouldThrowException_WhenQueueHasNoItems()
    {
        // Arrange
        var sut = new StackBackedQueue<int>();

        // Act
        Action action = () => sut.Peak();

        // Assert
        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Peak_ShouldThrowException_WhenAllItemsHaveBeenRemoved()
    {
        // Arrange
        var sut = new StackBackedQueue<int>();
        sut.Enqueue(GetRandomNumber());
        sut.Dequeue();

        // Act
        Action action = () => sut.Peak();

        // Assert
        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrue_WhenQueueHasNoItems()
    {
        // Arrange
        var sut = new StackBackedQueue<int>();

        // Act
        var result = sut.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrue_WhenAllItemsHaveBeenRemoved()
    {
        // Arrange
        var sut = new StackBackedQueue<int>();
        sut.Enqueue(GetRandomNumber());
        sut.Dequeue();

        // Act
        var result = sut.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }
}