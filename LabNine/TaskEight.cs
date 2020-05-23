using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static LabNine.Matrix;

namespace LabNine
{
    class TaskEight
    {
        internal static void Execute()
        {
            MatrixList matrixList = new MatrixList();
            int[,] matrix = new int[3, 3];
            FillMatricies(ref matrix, ref matrixList);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            matrixList.PrintMatrix();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("==========");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintArrayMatrix(matrix);
            Console.ForegroundColor = ConsoleColor.White;
            PrintArrayMatrix(TransposeMatrix(matrix));

        }
        static void FillMatricies(ref int[,] matrix, ref MatrixList matrixList)
        {
            Random r = new Random();
            for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(matrix.Length); j++)
                {
                    matrix[i, j] = r.Next(0, 2);
                }
            }
            matrixList = MatrixFromArray(matrix);
        }
        static void PrintArrayMatrix(int[,] matrix)
        {
            for (int i = 0; i < Math.Sqrt(matrix.Length); i++) {
                for (int j = 0; j < Math.Sqrt(matrix.Length); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        internal static int[,] AddMatricies(int[,] A, int[,] B)
        {
            int[,] C = new int[3, 3];
            for (int i = 0; i < Math.Sqrt(A.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(A.Length); j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }
            return C;
        }
        internal static MatrixList AddMatricies(MatrixList A, MatrixList B)
        {
            int[,] C = new int[A.Count, A.Count];
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A.Count; j++)
                {
                    C[i, j] = A.ItemAt(i, j) + B.ItemAt(i, j);
                }
            }
            return MatrixFromArray(C);
        }
        internal static int[,] MultiplyMatricies(int[,] a, int[,] b)
        {
            int m = a.GetLength(0);
            int n = b.GetLength(1);
            int[,] c = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return c;
        }
        internal static MatrixList MultiplyMatricies(MatrixList a, MatrixList b)
        {
            int m = a.Count;
            int n = b.Length;
            int[,] c = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        c[i, j] += a.ItemAt(i, k) * b.ItemAt(k, j);
                    }
                }
            }
            return MatrixFromArray(c);
        }
        internal static int[,] TransposeMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int[,] c = new int[m, m];
            for(int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    c[i, j] = matrix[j, i];
                }
            }
            return c;
        }
        internal static MatrixList TransposeMatrix(MatrixList matrix)
        {
            int m = matrix.Count;
            int[,] c = new int[m, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    c[i, j] = matrix.ItemAt(j, i);
                }
            }
            return MatrixFromArray(c);
        }

    }
}
