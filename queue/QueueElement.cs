namespace DataStructures
{
    public class QueueElement<T>
    {
        public QueueElement(T value)
        {
            Value = value;
            Previous = null;
        }  

        public T Value { get; set; }

        public QueueElement<T> Previous { get; set; }
    }
}

