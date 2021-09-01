using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson12
{
    public class LinkedList<T> : IEnumerable<T> where T : class
    {
        public int Count { get; private set; }
        public LinkedListElement<T> Head { get; private set; }

        public LinkedList()
        {
            //Head = new LinkedListElement<T>
            //{
            //    Value = default
            //};
            //Count = 1;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                var el = Head;
                for (int i = 0; i < index; i++)
                {
                    el = el.Next;
                }
                return el.Value;
            }
        }

        public void Add(T value)
        {
            var newElement = new LinkedListElement<T>
            {
                Value = value,
                Prev = Last()
            };
            if (Head == null)
            {
                Head = newElement;
                Count++;
                return;
            }
            Last().Next = newElement;
            Count++;
        }

        public LinkedListElement<T> Last()
        {
            var current = Head;

            while (current?.Next != null)
            {
                current = current.Next;
            }

            return current;
        }

        public void Reverse()
        {
            Head = Last();
            var current = Last();
            Swap(current);
            while (current.Next != null)
            {
                current = current.Next;
                Swap(current);
            }
        }

        private void Swap(LinkedListElement<T> element)
        {
            var prev = element.Prev;
            element.Prev = element.Next;
            element.Next = prev;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public LinkedListEnum<T> GetEnumerator()
        {
            return new LinkedListEnum<T>(Head);
        }
    }
}
