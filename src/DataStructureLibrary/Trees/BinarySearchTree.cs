namespace DataStructures.DataStructureLibrary.Trees;

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
        // If the tree is empty, throw an exception
        if (root == null)
        {
            throw new InvalidOperationException("Tree is empty");
        }

        TreeNode<T>? parent = null;
        TreeNode<T>? current = root;

        // Search for the value in the tree
        while (current != null)
        {
            // If the value is less than the current node's value, search left subtree
            if (value.CompareTo(current.Value) < 0)
            {
                parent = current;
                current = current.Left;
            }
            // If the value is greater than the current node's value, seach right subtree
            else if (value.CompareTo(current.Value) > 0)
            {
                parent = current;
                current = current.Right;
            }
            // If the value is equal to the current node's value, perform the removal
            else if (value.CompareTo(current.Value) == 0)
            {
                RemoveNode(current, parent);
                return;
            }
        }

        // If we get here, the value has not been found
        throw new InvalidOperationException("Value not found");
    }

    private void RemoveNode(TreeNode<T> deleteTarget, TreeNode<T>? deleteParent)
    {
        // If the node has a duplicate value, just decrement the count
        if (deleteTarget.IsDuplicate)
        {
            deleteTarget.Count--;
        }
        // If the node has no left child, replace it with its right child
        else if (deleteTarget.Left == null)
        {
            ReplaceNode(deleteTarget, deleteTarget.Right, deleteParent);
        }
        // If the node has no right child, replace it with its left child
        else if (deleteTarget.Right == null)
        {
            ReplaceNode(deleteTarget, deleteTarget.Left, deleteParent);
        }
        // If the node has both children, replace it with the smallest value in its right subtree
        else
        {
            TreeNode<T>? leftmostParent = null;
            TreeNode<T> leftmost = deleteTarget.Right;

            // Find right child's leftmost child
            while (leftmost.Left != null)
            {
                leftmostParent = leftmost;
                leftmost = leftmost.Left;
            }

            // If leftmost node has parent and a right subtree, replace leftmost node with right subtree
            if (leftmostParent != null)
            {
                leftmostParent.Left = leftmost.Right;
            }

            leftmost.Left = deleteTarget.Left;
            leftmost.Right = deleteTarget.Right;
            ReplaceNode(deleteTarget, leftmost, deleteParent);
        }

        count--;
    }

    private void ReplaceNode(TreeNode<T> deleteTarget, TreeNode<T>? replacmentNode, TreeNode<T>? parent)
    {
        // If the node to be deleted is the root, just assign the replacement node to the root
        if (parent == null)
        {
            root = replacmentNode;
        }
        // If the node to be deleted is the parent's left child, assign the replacement node to the parent's left
        else if (deleteTarget == parent.Left)
        {
            parent.Left = replacmentNode;
        }
        // The node to be deleted is the parent's right child, so assign the replacement node to the parent's right
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

    /// <summary>
    /// Depth first pre-order traversal
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<T> TraversePreOrder()
    {
        if (root == null) return Enumerable.Empty<T>();

        return TraversePreOrderInternal(root);

    }

    /// <summary>
    /// Depth first in-order traversal
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<T> TraverseInOrder()
    {
        if (root == null) return Enumerable.Empty<T>();

        return TraverseInOrderInternal(root);

    }

    /// <summary>
    /// Depth first post-order traversal
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<T> TraversePostOrder()
    {
        if (root == null) return Enumerable.Empty<T>();

        return TraversePostOrderInternal(root);

    }

    /// <summary>
    /// Breadth first traversal
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<T> TraverseLevelOrder()
    {
        if (root == null) return Enumerable.Empty<T>();

        List<T> list = [];
        Queue<TreeNode<T>> queue = new([root]);
        while (queue.Any())
        {
            TreeNode<T> current = queue.Dequeue();
            list.Add(current.Value);
            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }
            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }

        return list;
    }

    private IEnumerable<T> TraversePreOrderInternal(TreeNode<T> current)
    {
        List<T> list = [current.Value];

        if (current.IsLeaf)
        {
            return list;
        }

        if (current.Left != null)
        {
            list.AddRange(TraversePreOrderInternal(current.Left));
        }
        if (current.Right != null)
        {
            list.AddRange(TraversePreOrderInternal(current.Right));
        }

        return list;
    }

    private IEnumerable<T> TraverseInOrderInternal(TreeNode<T> current)
    {
        if (current.IsLeaf)
        {
            return [current.Value];
        }

        List<T> list = new();
        if (current.Left != null)
        {
            list.AddRange(TraverseInOrderInternal(current.Left));
        }
        list.Add(current.Value);
        if (current.Right != null)
        {
            list.AddRange(TraverseInOrderInternal(current.Right));
        }

        return list;
    }

    private IEnumerable<T> TraversePostOrderInternal(TreeNode<T> current)
    {
        if (current.IsLeaf)
        {
            return [current.Value];
        }

        List<T> list = new();
        if (current.Left != null)
        {
            list.AddRange(TraversePostOrderInternal(current.Left));
        }
        if (current.Right != null)
        {
            list.AddRange(TraversePostOrderInternal(current.Right));
        }
        list.Add(current.Value);

        return list;
    }
}