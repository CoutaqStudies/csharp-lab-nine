using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyAttemptAtADoubleList
{
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        DoublyNode<T> head; 
        DoublyNode<T> tail; 
        int count; 
        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public bool Remove(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    break;
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous;
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;
                count--;
                return true;
            }
            return false;
        }
        public void UpdateAtIndex(T newData, int index)
        {
            if (index >= count)
                throw new IndexOutOfRangeException("List does not contain an item at such index.");
            if (index < 0)
                throw new IndexOutOfRangeException("Index cannot be negative.");
            DoublyNode<T> current = head;
            for (int i = 0; current != null; i++)
            {
                if (i == index)
                    current.Data = newData;
                else
                    current = current.Next;
            }
        }
        public T[] ToArray()
        {
            DoublyNode<T> current = head;
            T[] array = new T[count];
            for (int i = 0; i<array.Length; i++)
            {
                array[i] = current.Data;
                current = current.Next;
            }
            return array;
        }
        public int Count { get { return count; } }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        internal void InsertAtIndex(int index, T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> prevNode = NodeAt(index - 1);
            DoublyNode<T> nextNode = NodeAt(index);
            node.Next = nextNode;
            node.Next = prevNode;
            prevNode.Next = node;
            nextNode.Previous = node;
        }
        public T ItemAt(int index)
        {
            if (index >= count)
                throw new IndexOutOfRangeException("List is smaller than the index.");
            if (index < 0)
                throw new IndexOutOfRangeException("Index cannot be negative.");
            DoublyNode<T> current = head;
            for(int i =0; current!=null; i++)
            {
                if (i == index)
                    return current.Data;
                else
                    current = current.Next;
            }
            return default;
        }
        private DoublyNode<T> NodeAt(int index)
        {
            if (index >= count)
                throw new IndexOutOfRangeException("List is smaller than the index.");
            if (index < 0)
                throw new IndexOutOfRangeException("Index cannot be negative.");
            DoublyNode<T> current = head;
            for (int i = 0; current != null; i++)
            {
                if (i == index)
                    return current;
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
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}