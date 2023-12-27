// See https://aka.ms/new-console-template for more information

using DataStructures.DataStructureLibrary;

var tree = new BinarySearchTree<int>();

int[] numbers = [5, 3, 9, 7, 6, 2, 4, 1, 12, 8, 13, 10, 11];

foreach (int number in numbers)
{
    tree.Add(number);
}

tree.Remove(9);

Console.WriteLine();