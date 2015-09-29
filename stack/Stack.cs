using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Stack<T>
    {
        private readonly List<T> _innerStack;

        public Stack()
        {
            _innerStack = new List<T>();
        }

        public bool IsEmpty()
        {
            return _innerStack.Count == 0;
        }

        public void Push(T element)
        {
            _innerStack.Add(element);
        }

        public T Pop()
        {
            if(IsEmpty())
                throw new InvalidOperationException("The stack is empty.");

            int lastIndex = _innerStack.Count - 1;
            T lastElement = _innerStack[lastIndex];
            _innerStack.RemoveAt(lastIndex);

            return lastElement;
        }

        public T Peek()
        {
            if(IsEmpty())
                throw new InvalidOperationException("The stack is empty.");

            return _innerStack[_innerStack.Count - 1];
        }
    }
}
