namespace DataStructures.DataStructureLibrary;

public interface IQueue<T>
{
    void Enqueue(T item);
    T Dequeue();
    T Peak();
    bool IsEmpty();
    int Count { get; }
    T? Front { get; }
    T? Rear { get; }
}