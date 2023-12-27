﻿namespace DataStructures.DataStructureLibrary;

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

    private void RemoveNode(TreeNode<T> target, TreeNode<T>? parent)
    {
        // If the node has a duplicate value, just decrement the count
        if (target.IsDuplicate)
        {
            target.Count--;
        }
        // If the node has no left child, replace it with its right child
        else if (target.Left == null)
        {
            ReplaceNode(target, target.Right, parent);
        }
        // If the node has no right child, replace it with its left child
        else if (target.Right == null)
        {
            ReplaceNode(target, target.Left, parent);
        }
        // If the node has both children, replace it with the smallest value in its right subtree
        else
        {
            TreeNode<T> current = target.Right;

            // Find right child's leftmost child
            while (current.Left != null)
            {
                current = current.Left;
            }

            current.Left = target.Left;
            current.Right = target.Right;
            ReplaceNode(target, current, parent);
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