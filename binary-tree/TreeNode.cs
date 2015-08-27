using System;

namespace DataStructures
{
    public class TreeNode<T>
        where T : IComparable<T>
    {
        public TreeNode(T value)
        {
            Value = value;
            LeftChild = null;
            RightChild = null;
            Parent = null;
        }

        public T Value { get; set; }

        public TreeNode<T> LeftChild { get; set; }

        public TreeNode<T> RightChild { get; set; }

        public TreeNode<T> Parent { get; set; }
    }
}
