namespace DataStructures.DataStructureLibrary.Contracts;

public interface IQueue<T>
{
    void Enqueue(T item);
    T Dequeue();
    T Peak();
    bool IsEmpty();
}