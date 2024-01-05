namespace DataStructures.DataStructureLibrary.Trees;

public class TreeNode<T>
{
    public T Value { get; set; }
    public int Count { get; set; } = 1;
    public TreeNode<T>? Left { get; set; }
    public TreeNode<T>? Right { get; set; }

    public bool IsLeaf => Left == null && Right == null;

    public bool IsDuplicate => Count > 1;

    public TreeNode(T value, TreeNode<T>? left = null, TreeNode<T>? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(Value);

        sb.Append(" (");
        if (Left != null)
        {
            sb.Append(Left.Value);
        }
        else
        {
            sb.Append("_");
        }
        sb.Append(",");
        if (Right != null)
        {
            sb.Append(Right.Value);
        }
        else
        {
            sb.Append("_");
        }
        sb.Append(") ");

        for (int i = 1; i < Count; i++)
        {
            sb.Append("*");
        }

        return sb.ToString();
    }
}