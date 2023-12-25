namespace DataStructures.DataStructureLibrary;

public class StackBackedQueue<T> : IQueue<T>
{
    private readonly Stack<T> stack1 = new();
    private readonly Stack<T> stack2 = new();
    private T? front;

    public void Enqueue(T item)
    {
        if (IsEmpty())
        {
            front = item;
        }

        stack1.Push(item);
    }

    public T Dequeue()
    {
        MoveTo2ndStack();
        T item = stack2.Pop();

        if (IsEmpty())
        {
            front = default;
        }
        else
        {
            front = stack2.Peek();
        }

        ReturnBackToOriginalStack();
        return item;
    }

    public T Peak()
    {
        if (IsEmpty() || front == null)
        {
            throw new InvalidOperationException("Can not call peak on a empty queue.");
        }

        return front;
    }

    public bool IsEmpty() => stack1.Count == 0;

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