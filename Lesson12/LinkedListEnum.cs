using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson12
{
    public class LinkedListEnum<T> : IEnumerator<T> where T : class
    {
        LinkedListElement<T> Head;
        LinkedListElement<T> Cur;
        public LinkedListEnum(LinkedListElement<T> head)
        {
            Head = head;
            Cur = new LinkedListElement<T> { Next = head};         
        }
        public T Current { get { return Cur.Value; } private set { } }

        object IEnumerator.Current { get { return Current; } }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (Cur?.Next != null)
            {
                Cur = Cur.Next;
                Current = Cur.Value;
                return true;
            }
            return false;
            
        }

        public void Reset()
        {
            Cur = Head;
            Current = Cur.Value;
        }
    }
}
