namespace DataStructures.UnitTests;

public class BinarySearchTreeTests : TestBase
{
    [Fact]
    public void Add_WhenPassingANumber_ShouldStoreIt()
    {
        // Arrange
        int num1 = GetRandomNumber();

        ITree<int> sut = new BinarySearchTree<int>();

        // Act
        sut.Add(num1);

        // Assert
        sut.IsEmpty.Should().BeFalse();
        sut.Count.Should().Be(1);
        sut.Contains(num1).Should().BeTrue();
    }

    [Fact]
    public void Add_WhenPassingTwoNumbers_ShouldStoreThem()
    {
        // Arrange
        int num1 = GetRandomNumber();
        int num2 = GetRandomNumber();

        ITree<int> sut = new BinarySearchTree<int>();

        // Act
        sut.Add(num1);
        sut.Add(num2);

        // Assert
        sut.IsEmpty.Should().BeFalse();
        sut.Count.Should().Be(2);
        sut.Contains(num1).Should().BeTrue();
        sut.Contains(num2).Should().BeTrue();
    }

    [Fact]
    public void Add_WhenPassingMultipleNumbers_ShouldStoreThem()
    {
        // Arrange
        int num1 = GetRandomNumber();
        int num2 = GetRandomNumber();
        int num3 = GetRandomNumber();

        ITree<int> sut = new BinarySearchTree<int>();

        // Act
        sut.Add(num1);
        sut.Add(num2);
        sut.Add(num3);

        // Assert
        sut.IsEmpty.Should().BeFalse();
        sut.Count.Should().Be(3);
        sut.Contains(num1).Should().BeTrue();
        sut.Contains(num2).Should().BeTrue();
        sut.Contains(num3).Should().BeTrue();
    }

    [Fact]
    public void IsEmpty_WhenTreeIsEmpty_ShouldReturnTrue()
    {
        // Arrange
        ITree<int> sut = new BinarySearchTree<int>();

        // Act
        bool isEmpty = sut.IsEmpty;

        // Assert
        isEmpty.Should().BeTrue();
    }

    [Fact]
    public void IsEmpty_WhenTreeIsNotEmpty_ShouldReturnFalse()
    {
        // Arrange
        ITree<int> sut = new BinarySearchTree<int>();
        sut.Add(GetRandomNumber());

        // Act
        bool isEmpty = sut.IsEmpty;

        // Assert
        isEmpty.Should().BeFalse();
    }

    [Fact]
    public void IsEmpty_WhenAllItemsHaveBeenRemoved_ShouldReturnTrue()
    {
        // Arrange
        int num1 = GetRandomNumber();

        ITree<int> sut = new BinarySearchTree<int>();
        sut.Add(num1);
        sut.Remove(num1);

        // Act
        bool isEmpty = sut.IsEmpty;

        // Assert
        isEmpty.Should().BeTrue();
    }

    [Fact]
    public void Count_WhenTreeIsEmpty_ShouldReturnZero()
    {
        // Arrange
        ITree<int> sut = new BinarySearchTree<int>();

        // Act
        int count = sut.Count;

        // Assert
        count.Should().Be(0);
    }

    [Fact]
    public void Count_WhenTreeIsNotEmpty_ShouldReturnNumberOfItems()
    {
        // Arrange
        ITree<int> sut = new BinarySearchTree<int>();
        sut.Add(GetRandomNumber());
        sut.Add(GetRandomNumber());
        sut.Add(GetRandomNumber());

        // Act
        int count = sut.Count;

        // Assert
        count.Should().Be(3);
    }

    [Fact]
    public void Count_WhenAllItemsHaveBeenRemoved_ShouldReturnZero()
    {
        // Arrange
        int num1 = GetRandomNumber();

        ITree<int> sut = new BinarySearchTree<int>();
        sut.Add(num1);
        sut.Remove(num1);

        // Act
        int count = sut.Count;

        // Assert
        count.Should().Be(0);
    }

    [Fact]
    public void Contains_WhenTreeIsEmpty_ShouldReturnFalse()
    {
        // Arrange
        ITree<int> sut = new BinarySearchTree<int>();

        // Act
        bool contains = sut.Contains(GetRandomNumber());

        // Assert
        contains.Should().BeFalse();
    }

    [Fact]
    public void Contains_WhenTreeIsNotEmptyAndItemIsNotInTree_ShouldReturnFalse()
    {
        // Arrange
        ITree<int> sut = new BinarySearchTree<int>();
        sut.Add(GetRandomNumber());

        // Act
        bool contains = sut.Contains(GetRandomNumber());

        // Assert
        contains.Should().BeFalse();
    }

    [Fact]
    public void Contains_WhenTreeIsNotEmptyAndItemIsInTree_ShouldReturnTrue()
    {
        // Arrange
        int num1 = GetRandomNumber();

        ITree<int> sut = new BinarySearchTree<int>();
        sut.Add(num1);

        // Act
        bool contains = sut.Contains(num1);

        // Assert
        contains.Should().BeTrue();
    }

    [Fact]
    public void Remove_WhenTreeIsEmpty_ShouldThrowException()
    {
        // Arrange
        ITree<int> sut = new BinarySearchTree<int>();

        // Act
        Action act = () => sut.Remove(GetRandomNumber());

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Remove_WhenTreeIsNotEmptyAndItemIsNotInTree_ShouldThrowException()
    {
        // Arrange
        ITree<int> sut = new BinarySearchTree<int>();
        sut.Add(GetRandomNumber());

        // Act
        Action act = () => sut.Remove(GetRandomNumber());

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Remove_WhenTreeHasASingleItemAndItIsBeingRemoved_ShouldRemoveIt()
    {
        // Arrange
        int num1 = GetRandomNumber();

        ITree<int> sut = new BinarySearchTree<int>();
        sut.Add(num1);

        // Act
        sut.Remove(num1);

        // Assert
        sut.IsEmpty.Should().BeTrue();
        sut.Count.Should().Be(0);
        sut.Contains(num1).Should().BeFalse();
    }

    [Fact]
    public void Remove_WhenTreeHasMultipleItemsAndOneIsBeingRemoved_ShouldRemoveIt()
    {
        // Arrange
        int num1 = GetRandomNumber();
        int num2 = GetRandomNumber();
        int num3 = GetRandomNumber();

        ITree<int> sut = new BinarySearchTree<int>();
        sut.Add(num1);
        sut.Add(num2);
        sut.Add(num3);

        // Act
        sut.Remove(num2);

        // Assert
        sut.IsEmpty.Should().BeFalse();
        sut.Count.Should().Be(2);
        sut.Contains(num1).Should().BeTrue();
        sut.Contains(num2).Should().BeFalse();
        sut.Contains(num3).Should().BeTrue();
    }

    [Fact]
    public void Remove_WhenRemovingRootAndItHasNoChildren_ShouldRemoveIt()
    {
        // Arrange
        int num1 = GetRandomNumber();

        ITree<int> sut = new BinarySearchTree<int>();
        sut.Add(num1);

        // Act
        sut.Remove(num1);

        // Assert
        sut.IsEmpty.Should().BeTrue();
        sut.Count.Should().Be(0);
    }

    [Fact]
    public void Remove_WhenRemovingRootAndItHasChildren_ShouldReplaceRootWithOneOfItsChildren()
    {
        // Arrange
        int num1 = 2;
        int num2 = 1;
        int num3 = 3;

        ITree<int> sut = new BinarySearchTree<int>();

        sut.Add(num1);
        sut.Add(num2);
        sut.Add(num3);

        // Act
        sut.Remove(num1);

        // Assert
        sut.Count.Should().Be(2);
        sut.Contains(num1).Should().BeFalse();
        sut.Contains(num2).Should().BeTrue();
        sut.Contains(num3).Should().BeTrue();
    }

    [Fact]
    public void Remove_WhenRemovingANodeContainingSubtree_ShouldReplaceItWithTheSmallestValueInTheRightSubtree()
    {
        // Arrange
        int num1 = 5;
        int num2 = 3;
        int num3 = 7;
        int num4 = 2;
        int num5 = 4;
        int num6 = 6;
        int num7 = 8;

        ITree<int> sut = new BinarySearchTree<int>();

        sut.Add(num1);
        sut.Add(num2);
        sut.Add(num3);
        sut.Add(num4);
        sut.Add(num5);
        sut.Add(num6);
        sut.Add(num7);

        // Act
        sut.Remove(num3);

        // Assert
        sut.Count.Should().Be(6);
        sut.Contains(num1).Should().BeTrue();
        sut.Contains(num2).Should().BeTrue();
        sut.Contains(num3).Should().BeFalse();
        sut.Contains(num4).Should().BeTrue();
        sut.Contains(num5).Should().BeTrue();
        sut.Contains(num6).Should().BeTrue();
        sut.Contains(num7).Should().BeTrue();
    }

    [Fact]
    public void Remove_WhenRemovingANodeContainingRightSubtreeV1_ShouldReplaceItWithTheSmallestValueInTheRightSubtree()
    {
        // Arrange
        int[] numbers = [5, 3, 9, 7, 6, 2, 4, 1, 12, 8, 13, 11, 10];

        ITree<int> sut = new BinarySearchTree<int>();

        foreach (int number in numbers)
        {
            sut.Add(number);
        }

        // Act
        sut.Remove(9);

        // Assert
        sut.Count.Should().Be(numbers.Length - 1);
        sut.Contains(9).Should().BeFalse();
        foreach (int number in numbers.Except([9]))
        {
            sut.Contains(number).Should().BeTrue();
        }
    }

    [Fact]
    public void Remove_WhenRemovingANodeContainingRightSubtreeV2_ShouldReplaceItWithTheSmallestValueInTheRightSubtree()
    {
        // Arrange
        int[] numbers = [5, 3, 9, 7, 6, 2, 4, 1, 13, 8, 14, 11, 10, 12];

        ITree<int> sut = new BinarySearchTree<int>();

        foreach (int number in numbers)
        {
            sut.Add(number);
        }

        // Act
        sut.Remove(9);

        // Assert
        sut.Count.Should().Be(numbers.Length - 1);
        sut.Contains(9).Should().BeFalse();
        foreach (int number in numbers.Except([9]))
        {
            sut.Contains(number).Should().BeTrue();
        }
    }

    [Fact]
    public void Remove_WhenRemovingANodeContainingRightSubtreeV3_ShouldReplaceItWithTheSmallestValueInTheRightSubtree()
    {
        // Arrange
        int[] numbers = [5, 3, 9, 7, 6, 2, 4, 1, 12, 8, 13, 10, 11];

        ITree<int> sut = new BinarySearchTree<int>();

        foreach (int number in numbers)
        {
            sut.Add(number);
        }

        // Act
        sut.Remove(9);

        // Assert
        sut.Count.Should().Be(numbers.Length - 1);
        sut.Contains(9).Should().BeFalse();
        foreach (int number in numbers.Except([9]))
        {
            sut.Contains(number).Should().BeTrue();
        }
    }
}