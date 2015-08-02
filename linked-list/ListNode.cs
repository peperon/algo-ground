namespace DataStructures
{
    using System;

    public class ListNode<T>
        where T : IEquatable<T>
    {
        public ListNode(T value)
        {
            Value = value;
            PreviousNode = null;
            NextNode = null;
        }

        public T Value { get; set; }

        public ListNode<T> PreviousNode { get; set; }

        public ListNode<T> NextNode { get; set; }
    }
}
