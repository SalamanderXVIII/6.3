using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3
{
    public class LinkedList<T> : IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
            count++;
        }
        public Node<T> GetNode(LinkedList<T> list, int index)
        {
            count = 0;
            Node<T> current = head;
            for (int l = 0; l < index; l++)
            {
                current = current.Next;
                count++;
            }
            return current;
        }
        public string GetNodeString(Node<T> current)
        {
            var sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetError(sw);
            if (current != null)
            {
                Console.WriteLine(current.Data);
                return sw.ToString();
            }
            else
            {
                return "";
            }
        }
        public void Remove(T Data)
        {
            Node<T> current = head;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(Data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                }
                previous = current;
                current = current.Next;
            }
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public LinkedList<T> Next { get; private set; }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
