using System;
using Xunit;

namespace MatrixTestTaskTests
{
    public class MatrixProcessorTests
    {
        [Fact]
        public void CreateRandomMatrix_Test()
        {
            int size = 0;
            int expected = 0;
            int[][] matrix = MatrixTestTask.MatrixProcessor.CreateRandomMatrix(out size);
            Assert.NotEqual(size, expected);
            Assert.NotEmpty(matrix);
        }

        [Fact]
        public void RotateMatrix_7Rows_Test()
        {
            int size = 7;
            int expected = 7;

            int[] matrix1 = { 3, 8, 6, 6, 3, 6, 7 };
            int[] matrix2 = { 2, 6, 3, 7, 6, 3, 4 };
            int[] matrix3 = { 2, 1, 7, 9, 4, 2, 2 };
            int[] matrix4 = { 7, 4, 8, 4, 9, 6, 5 };
            int[] matrix5 = { 8, 6, 9, 6, 5, 7, 2 };
            int[] matrix6 = { 5, 8, 1, 8, 1, 6, 5 };
            int[] matrix7 = { 1, 1, 6, 8, 5, 1, 4 };
            int[][] matrix = { matrix1, matrix2, matrix3, matrix4, matrix5, matrix6, matrix7 };

            int[] matrixExpected1 = { 7, 4, 2, 5, 2, 5, 4 };
            int[] matrixExpected2 = { 6, 3, 2, 6, 7, 6, 1 };
            int[] matrixExpected3 = { 3, 6, 4, 9, 5, 1, 5 };
            int[] matrixExpected4 = { 6, 7, 9, 4, 6, 8, 8 };
            int[] matrixExpected5 = { 6, 3, 7, 8, 9, 1, 6 };
            int[] matrixExpected6 = { 8, 6, 1, 4, 6, 8, 1 };
            int[] matrixExpected7 = { 3, 2, 2, 7, 8, 5, 1 };
            int[][] matrixExpected = { matrixExpected1, matrixExpected2, matrixExpected3, matrixExpected4, matrixExpected5, matrixExpected6, matrixExpected7 };

            int[][] matrixActual = MatrixTestTask.MatrixProcessor.RotateMatrix(size, matrix);

            Assert.Equal(size, expected);
            Assert.Equal(matrixActual, matrixExpected);
        }
    }
}
