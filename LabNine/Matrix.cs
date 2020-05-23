using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LabNine
{
    public class Matrix
    {
        //i : rows
        //j: col
        public class MatrixNode
        {
            public MatrixNode(int[] data)
            {
                Data = data;
            }
            public int[] Data { get; set; }
            public MatrixNode Next { get; set; }
        }

        public class MatrixList : IEnumerable
        {
            MatrixNode head;
            MatrixNode tail;
            int count;
            public void Add(int[] data)
            {
                MatrixNode node = new MatrixNode(data);
                if (head == null)
                    head = node;
                else
                {
                    tail.Next = node;
                }
                tail = node;
                count++;
            }
            public void UpdateAtIndex(int newData, int i, int j)
            {
                if (i >= count)
                    throw new IndexOutOfRangeException("List does not contain an item at such index.");
                if (i < 0)
                    throw new IndexOutOfRangeException("Index cannot be negative.");
                MatrixNode current = head;
                for (int k = 0; current != null; k++)
                {
                    if (k == j)
                        current.Data[i] = newData;
                    else
                        current = current.Next;
                }
            }

            public int Count { get { return count; } }
            public int Length { get { return head.Data.Length; } }
            public int ItemAt(int i, int j)
            {
                if (i >= count)
                    throw new IndexOutOfRangeException("List is smaller than the index.");
                if (i < 0)
                    throw new IndexOutOfRangeException("Index cannot be negative.");
                MatrixNode current = head;
                for (int k = 0; current != null; k++)
                {
                    if (i == k)
                        return current.Data[j];
                    else
                        current = current.Next;
                }
                return default;
            }
            public void PrintMatrix()
            {
                MatrixNode current = head;
                for(int i =0;i< count; i++)
                {
                    for (int j = 0; j<current.Data.Length; j++)
                    {
                        Console.Write(ItemAt(i, j) + " ");
                    }
                    Console.WriteLine();
                }
            }
           
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }
        }
        public static MatrixList MatrixFromArray(int[,] array)
        {
            MatrixList matrixList = new MatrixList();
            for (int j = 0; j < Math.Sqrt(array.Length); j++)
            {
                int[] ints = new int[(int)Math.Sqrt(array.Length)];
                for (int i = 0;i < ints.Length; i++)
                {
                   ints[i] = array[j, i];
                }
                matrixList.Add(ints);
            }
            return matrixList;
        }
    }
}
