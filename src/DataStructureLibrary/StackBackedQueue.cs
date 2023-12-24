using System.Text;

namespace DataStructures.DataStructureLibrary;

public class StackBackedQueue<T> : IQueue<T>
{
    private readonly Stack<T> stack1 = new();
    private readonly Stack<T> stack2 = new();

    public T? Front { get; private set; }
    public T? Rear { get; private set; }

    public void Enqueue(T item)
    {
        if (IsEmpty())
        {
            Front = item;
        }
        Rear = item;

        stack1.Push(item);
    }

    public T Dequeue()
    {
        MoveTo2ndStack();
        T item = stack2.Pop();

        if (IsEmpty())
        {
            Front = Rear = default;
        }
        else
        {
            Front = stack2.Peek();
        }

        ReturnBackToOriginalStack();
        return item;
    }

    public T Peak()
    {
        MoveTo2ndStack();
        T item = stack2.Peek();
        ReturnBackToOriginalStack();
        return item;
    }

    public bool IsEmpty() => stack1.Count == 0;

    public int Count => stack1.Count;

    private void MoveTo2ndStack()
    {
        while (stack1.Count > 0)
        {
            stack2.Push(stack1.Pop());
        }
    }

    private void ReturnBackToOriginalStack()
    {
        while (stack2.Count > 0)
        {
            stack1.Push(stack2.Pop());
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append("[");
        foreach (var item in stack1)
        {
            sb.Append($"{item},");
        }
        sb.Append("]");
        return sb.ToString();
    }
}