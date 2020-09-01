using System;
using System.IO;

namespace MatrixTestTask
{
    class Program
    {
        const string fileName = "input.txt";

        static int[][] TryReadMatrixFromFile(ref int size)
        {
            StreamReader streamReader = null;
            int[][] matrix;
            try
            {
                streamReader = File.OpenText(fileName);
                matrix = MatrixProcessor.ReadMatrixFromFile(out size, streamReader);
                if (matrix.Length == 0)
                    throw new Exception("Input matrix is empty");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Creating a random matrix...");
                matrix = MatrixProcessor.CreateRandomMatrix(out size);
            }
            finally
            {
                if(streamReader != null)
                {
                    streamReader.Close();
                }
            }
            return matrix;
        }

        static void TryWriteMatrixToFile(int size, int[][] matrix)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(fileName, true))
                {
                    MatrixProcessor.FileOutputMatrix(size, matrix, streamWriter);
                }
            }
            catch
            {
                Console.WriteLine("Error occured while writing to file");
            }
        }

        static void Main(string[] args)
        {
            int size = 0;
            int[][] matrix = TryReadMatrixFromFile(ref size);

            MatrixProcessor.ConsoleOutputRotatedMatrix(size, matrix);
            Console.WriteLine();
            matrix = MatrixProcessor.RotateMatrix(size, matrix);
            TryWriteMatrixToFile(size, matrix);
            Console.WriteLine("Matrix was written to the file");
        }
    }
}
