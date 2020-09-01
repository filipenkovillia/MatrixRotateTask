using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MatrixTestTask
{
    /// <summary>
    /// Create a matrix with random size and random values 
    /// </summary>
    public static class MatrixProcessor
    {
        public static int[][] CreateRandomMatrix(out int size)
        {
            Random random = new Random();
            size = random.Next(2, 10);
            int[][] matrix = new int[size][];
            for(int i = 0; i < size; i++)
            {
                matrix[i] = new int[size];
                for(int j = 0; j < size; j++)
                {
                    matrix[i][j] = random.Next(1, 10);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Read matrix from a file
        /// Input stadart for the file:
        /// Matrix size is in the first line, then rows with values delimited by the space
        /// </summary>
        /// <param name="size"></param>
        /// <param name="streamReader"></param>
        /// <returns></returns>
        public static int[][] ReadMatrixFromFile(out int size, StreamReader streamReader)
        {
            size = int.Parse(streamReader.ReadLine());
            int[][] matrix = new int[size][];
            for(int i = 0; i < size; i++)
            {
                string valuesString = streamReader.ReadLine();
                string[] values = valuesString.Split(' ');
                matrix[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    matrix[i][j] = int.Parse(values[j]);
                }
            }

            return matrix;
        }

        /// <summary>
        /// Output matrix and it's size to the console
        /// </summary>
        /// <param name="size"></param>
        /// <param name="matrix"></param>
        public static void ConsoleOutputMatrix(int size, int[][] matrix)
        {
            if (size != 0)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(matrix[i][j].ToString() + " ");
                    }
                    Console.WriteLine();
                }
            }
            else Console.WriteLine("Matrix is empty");
        }

        /// <summary>
        /// Output matrix and it's size to the file
        /// </summary>
        /// <param name="size"></param>
        /// <param name="matrix"></param>
        /// <param name="streamWriter"></param>
        public static void FileOutputMatrix(int size, int[][] matrix, StreamWriter streamWriter)
        {
            streamWriter.WriteLine();
            streamWriter.WriteLine(size);
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    streamWriter.Write(matrix[i][j].ToString() + " ");
                }
                streamWriter.WriteLine();
            }
        }

        /// <summary>
        /// Output rotated matrix and it's size to a file. This method doesn't rotate the original matrix, only displays it
        /// </summary>
        /// <param name="size"></param>
        /// <param name="matrix"></param>
        /// <param name="streamWriter"></param>
        public static void FileOutputRotatedMatrix(int size, int[][] matrix, StreamWriter streamWriter)
        {
            streamWriter.WriteLine();
            streamWriter.WriteLine(size);
            for (int j = size - 1; j >= 0; j--)
            {
                for (int i = 0; i < size; i++)
                {
                    streamWriter.Write(matrix[i][j].ToString() + " ");
                }
                streamWriter.WriteLine();
            }
        }

        /// <summary>
        /// Output rotated matrix and it's size to console. This method doesn't rotate the original matrix, only displays it
        /// </summary>
        /// <param name="size"></param>
        /// <param name="matrix"></param>
        public static void ConsoleOutputRotatedMatrix(int size, int[][] matrix)
        {
            if (size != 0)
            {
                for (int j = size - 1; j >= 0; j--)
                {
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write(matrix[i][j].ToString() + " ");
                    }
                    Console.WriteLine();
                }
            }
            else Console.WriteLine("Matrix is empty");
        }

        /// <summary>
        /// Rotate matrix
        /// </summary>
        /// <param name="size"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[][] RotateMatrix(int size, int[][] matrix)
        {
            int temp;
            for (int i = 0; i < size / 2; i++)
            {
                for (int j = i; j < size - 1 - i; j++)
                {
                    temp = matrix[i][j];
                    matrix[i][j] = matrix[j][size - 1 - i];
                    matrix[j][size - 1 - i] = matrix[size - 1 - i][size - 1 - j];
                    matrix[size - 1 - i][size - 1 - j] = matrix[size - 1 - j][i];
                    matrix[size - 1 - j][i] = temp;
                }
            }
            return matrix;
        }
    }
}
