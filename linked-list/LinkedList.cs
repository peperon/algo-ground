namespace DataStructures
{
    using System;

    public class LinkedList<T>
        where T : IEquatable<T>
    {
        private ListNode<T> _head;

        public LinkedList()
        {
            _head = null;
        }

        public ListNode<T> Search(T value)
        {
            ListNode<T> current = _head;
            while (current != null && !current.Value.Equals(value))
            {
                current = current.NextNode;
            }

            return current;
        }

        public void Add(T value)
        {
            var newNode = new ListNode<T>(value);
            if (_head != null)
            {
                _head.PreviousNode = newNode;
            }

            newNode.NextNode = _head;
            _head = newNode;
        }

        public void Delete(T value)
        {
            ListNode<T> forDelete = Search(value);
            if (forDelete != null)
            {
                if (forDelete.PreviousNode != null)
                {
                    forDelete.PreviousNode.NextNode = forDelete.NextNode;
                }
                else
                {
                    _head = forDelete.NextNode;
                }

                if (forDelete.NextNode != null)
                {
                    forDelete.NextNode.PreviousNode = forDelete.PreviousNode;
                }
            }
        }
    }
}
