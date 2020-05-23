using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabNine
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class CircularLinkedList<T> : IEnumerable<T>  // кольцевой связный список
    {
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            // если список пуст
            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
            count++;
        }

        public T ItemAtIndex(int index)
        {
            if (index < 0)
                throw new IndexOutOfRangeException("no.");
            Node<T> current = head;
            for(int i =0; i <= index; i++)
            {
                if (i == index)
                    return current.Data;
                else
                    current = current.Next;
            }
            return default;
        }
        public Node<T> NodeAtIndex(int index)
        {
            if (index < 0)
                throw new IndexOutOfRangeException("no.");
            Node<T> current = head;
            for (int i = 0; i <= index; i++)
            {
                if (i == index)
                    return current;
                else
                    current = current.Next;
            }
            return default;
        }
        public T ItemAtIndexButWithCoolGraphics(String[] array, int start)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Node<T> current = NodeAtIndex(start);
            int currentWord = 0;
            for (int i = start; i <= array.Length-1+start; i++)
            {
                Console.WriteLine(array[currentWord] +"--->"+current.Data.ToString());
                currentWord++;
                if (i == (array.Length - 1 + start))
                    return current.Data;
                else
                    current = current.Next;
            }
            return default;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

