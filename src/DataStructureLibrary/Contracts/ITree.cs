namespace DataStructures.DataStructureLibrary.Contracts;

public interface ITree<T>
{
    void Add(T value);
    void Remove(T value);
    bool Contains(T value);
    int Count { get; }
    bool IsEmpty { get; }
    IEnumerable<T> TraversePreOrder();
    IEnumerable<T> TraverseInOrder();
    IEnumerable<T> TraversePostOrder();
    IEnumerable<T> TraverseLevelOrder();

    /*T Min { get; }
    T Max { get; }
    IEnumerable<T> TraverseReverseLevelOrder();
    IEnumerable<T> TraverseZigZagLevelOrder();
    IEnumerable<T> TraverseSpiralLevelOrder();
    IEnumerable<T> TraverseLeftView();
    IEnumerable<T> TraverseRightView();
    IEnumerable<T> TraverseTopView();
    IEnumerable<T> TraverseBottomView();
    IEnumerable<T> TraverseDiagonalView();
    IEnumerable<T> TraverseBoundaryView();
    IEnumerable<T> TraverseVerticalView();
    IEnumerable<T> TraverseHorizontalView();
    IEnumerable<T> TraverseCornerView();
    IEnumerable<T> TraversePerimeterView();
    IEnumerable<T> TraversePerimeterClockwiseView();
    IEnumerable<T> TraversePerimeterCounterClockwiseView();
    IEnumerable<T> TraversePerimeterOutsideInClockwiseView();
    IEnumerable<T> TraversePerimeterOutsideInCounterClockwiseView();
    IEnumerable<T> TraversePerimeterInsideOutClockwiseView();
    IEnumerable<T> TraversePerimeterInsideOutCounterClockwiseView();
    IEnumerable<T> TraversePerimeterClockwiseSpiralView();
    IEnumerable<T> TraversePerimeterCounterClockwiseSpiralView();
    IEnumerable<T> TraversePerimeterOutsideInClockwiseSpiralView();
    IEnumerable<T> TraversePerimeterOutsideInCounterClockwiseSpiralView();
    IEnumerable<T> TraversePerimeterInsideOutClockwiseSpiralView();
    IEnumerable<T> TraversePerimeterInsideOutCounterClockwiseSpiralView();
    IEnumerable<T> TraversePerimeterClockwiseZigZagView();
    IEnumerable<T> TraversePerimeterCounterClockwiseZigZagView();
    IEnumerable<T> TraversePerimeterOutsideInClockwiseZigZagView();
    IEnumerable<T> TraversePerimeterOutsideInCounter();*/
}