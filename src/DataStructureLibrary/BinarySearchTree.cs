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

        TreeNode<T>? parent = null;
        TreeNode<T>? current = root;
        while (current != null)
        {
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
            else if (value.CompareTo(current.Value) == 0)
            {
                RemoveNode(current, parent);
                return;
            }
        }

        // If we get here, the value has not been found
        throw new InvalidOperationException("Value not found");
    }

    private void RemoveNode(TreeNode<T> target, TreeNode<T>? parent)
    {
        if (target.Count > 1)
        {
            target.Count--;
        }
        else if (target.Left == null)
        {
            ReplaceNode(target, target.Right, parent);
        }
        else if (target.Right == null)
        {
            ReplaceNode(target, target.Left, parent);
        }
        else
        {
            TreeNode<T>? current = target.Right;
            if (current == null)
            {
                ReplaceNode(target, current, parent);
            }
            else
            {
                while (current.Left != null)
                {
                    current = current.Left;
                }

                current.Left = target.Left;
                current.Right = target.Right;
                ReplaceNode(target, current, parent);
            }
        }

        count--;
    }

    private void ReplaceNode(TreeNode<T> deleteTarget, TreeNode<T>? replacmentNode, TreeNode<T>? parent)
    {
        if (parent == null)
        {
            root = replacmentNode;
        }
        else if (deleteTarget == parent.Left)
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