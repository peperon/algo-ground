using System;

namespace DataStructures
{
    public class Queue<T>
    {
        private QueueElement<T> _head;
        private QueueElement<T> _tail;

        public Queue()
        {
            _head = null;
            _tail = null;
        }

        public bool IsEmpty()
        {
            return _head == null;
        }

        public void Enqueue(T value)
        {
            var newElement = new QueueElement<T>(value);
            if (IsEmpty())
            {
                _head = _tail = newElement;
            }
            else
            {
                _tail.Previous = newElement;
                _tail = newElement;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The queue is empty.");

            T value = _head.Value;

            _head = _head.Previous;
            if (_head == null)
            {
                _tail = null;
            }

            return value;
        }
    }
}

