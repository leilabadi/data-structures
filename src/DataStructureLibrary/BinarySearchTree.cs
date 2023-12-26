namespace DataStructures.DataStructureLibrary;

public class BinarySearchTree<T> : ITree<T> where T : IComparable<T>
{
    private TreeNode<T>? root;

    private int count;

    public void Add(T value)
    {
        root ??= new TreeNode<T>(value);
        root.Count = 0;

        TreeNode<T> current = root;
        while (true)
        {
            if (value.CompareTo(current.Value) < 0)
            {
                if (current.Left == null)
                {
                    current.Left = new TreeNode<T>(value);
                    break;
                }
                current = current.Left;
            }
            else if (value.CompareTo(current.Value) > 0)
            {
                if (current.Right == null)
                {
                    current.Right = new TreeNode<T>(value);
                    break;
                }
                current = current.Right;
            }
            else
            {
                current.Count++;
                break;
            }
        }

        count++;
    }

    public void Remove(T value)
    {
        if (root == null)
        {
            throw new InvalidOperationException("Tree is empty");
        }

        if (root.IsLeaf && value.CompareTo(root.Value) == 0)
        {
            root = null;
            count--;
            return;
        }

        TreeNode<T>? deleteTarget = null;
        TreeNode<T>? parent = null;
        TreeNode<T>? current = root;
        while (current != null)
        {
            if (value.CompareTo(current.Value) == 0)
            {
                deleteTarget = current;
                break;
            }

            if (value.CompareTo(current.Value) < 0)
            {
                parent = current;
                current = current.Left;
            }
            else if (value.CompareTo(current.Value) > 0)
            {
                parent = current;
                current = current.Right;
            }
        }

        if (deleteTarget == null)
        {
            throw new InvalidOperationException("Value not found");
        }

        if (parent == null)
        {
            throw new ApplicationException("Parent should only be null when we are deleting root node which is handled earlier! If this is happening, it means the algorithm is wrong!");
        }

        count--;

        if (deleteTarget.Count > 1)
        {
            deleteTarget.Count--;
        }
        else if (deleteTarget.IsLeaf)
        {
            RemoveNode(deleteTarget, null, parent);
        }
        else if (deleteTarget.Left == null)
        {
            RemoveNode(deleteTarget, deleteTarget.Right, parent);
        }
        else if (deleteTarget.Right == null)
        {
            RemoveNode(deleteTarget, deleteTarget.Left, parent);
        }
        else
        {
            current = deleteTarget.Right;
            if (current == null)
            {
                RemoveNode(deleteTarget, current, parent);
            }
            else
            {
                while (current.Left != null)
                {
                    current = current.Left;
                }

                current.Left = deleteTarget.Left;
                current.Right = deleteTarget.Right;
                RemoveNode(deleteTarget, current, parent);
            }
        }
    }

    private void RemoveNode(TreeNode<T> deleteTarget, TreeNode<T>? replacmentNode, TreeNode<T> parent)
    {
        if (deleteTarget == parent.Left)
        {
            parent.Left = replacmentNode;
        }
        else
        {
            parent.Right = replacmentNode;
        }
    }

    public bool Contains(T value)
    {
        return Find(value) != null;
    }

    private TreeNode<T>? Find(T value)
    {
        if (root == null)
        {
            return null;
        }

        TreeNode<T>? current = root;
        while (current != null)
        {
            if (value.CompareTo(current.Value) < 0)
            {
                current = current.Left;
            }
            else if (value.CompareTo(current.Value) > 0)
            {
                current = current.Right;
            }
            else return current;
        }

        return null;
    }

    public int Count => count;

    public bool IsEmpty => count == 0;

    public IEnumerable<T> TraverseBreadthFirst()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> TraverseDepthFirst()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> TraverseInOrder()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> TraverseLevelOrder()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> TraversePostOrder()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> TraversePreOrder()
    {
        throw new NotImplementedException();
    }
}