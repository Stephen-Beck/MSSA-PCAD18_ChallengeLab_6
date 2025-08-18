/*
You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).

You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. 
    DO NOT allocate another 2D matrix and do the rotation.

Example 1:
    Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
    Output: [[7,4,1],[8,5,2],[9,6,3]]

        1 2 3       7 4 1
        4 5 6 ----> 8 5 2
        7 8 9       9 6 3

Example 2:
    Input: matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
    Output: [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]

         5  1  9 11       15 13  2  5
         2  4  8 10 ----> 14  3  4  1
        13  3  6  7       12  6  8  9
        15 14 12 16       16  7 10 11
*/
namespace ChallengeLab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine($"--- Matrix Size: {matrix.GetLength(0)} ---");
            DisplayMatrix(matrix);
            Console.WriteLine();
            RotateMatrix(matrix);
            DisplayMatrix(matrix);

            matrix = new int[,] { { 5, 1, 9, 11 }, { 2, 4, 8, 10 }, { 13, 3, 6, 7 }, { 15, 14, 12, 16 } };
            Console.WriteLine($"\n--- Matrix Size: {matrix.GetLength(0)} ---");
            DisplayMatrix(matrix);
            Console.WriteLine();
            RotateMatrix(matrix);
            DisplayMatrix(matrix);

            matrix = new int[,] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };
            Console.WriteLine($"\n--- Matrix Size: {matrix.GetLength(0)} ---");
            DisplayMatrix(matrix);
            Console.WriteLine();
            RotateMatrix(matrix);
            DisplayMatrix(matrix);

            matrix = new int[,] { { 1, 2, 3, 4, 5, 6 }, { 7, 8, 9, 10, 11, 12 }, { 13, 14, 15, 16, 17, 18 }, { 19, 20, 21, 22, 23, 24 }, { 25, 26, 27, 28, 29, 30 }, { 31, 32, 33, 34, 35, 36 } };
            Console.WriteLine($"\n--- Matrix Size: {matrix.GetLength(0)} ---");
            DisplayMatrix(matrix);
            Console.WriteLine();
            RotateMatrix(matrix);
            DisplayMatrix(matrix);

            matrix = new int[,] { { 1, 2, 3, 4, 5, 6, 7 }, { 1, 2, 3, 4, 5, 6, 7 }, { 1, 2, 3, 4, 5, 6, 7 }, { 1, 2, 3, 4, 5, 6, 7 }, { 1, 2, 3, 4, 5, 6, 7 }, { 1, 2, 3, 4, 5, 6, 7 }, { 1, 2, 3, 4, 5, 6, 7 } };
            Console.WriteLine($"\n--- Matrix Size: {matrix.GetLength(0)} ---");
            DisplayMatrix(matrix);
            Console.WriteLine();
            RotateMatrix(matrix);
            DisplayMatrix(matrix);

            matrix = new int[,] { { 1, 2, 3, 4, 5, 6, 7, 8 }, { 1, 2, 3, 4, 5, 6, 7, 8 }, { 1, 2, 3, 4, 5, 6, 7, 8 }, { 1, 2, 3, 4, 5, 6, 7, 8 }, { 1, 2, 3, 4, 5, 6, 7, 8 }, { 1, 2, 3, 4, 5, 6, 7, 8 }, { 1, 2, 3, 4, 5, 6, 7, 8 }, { 1, 2, 3, 4, 5, 6, 7, 8 } };
            Console.WriteLine($"\n--- Matrix Size: {matrix.GetLength(0)} ---");
            DisplayMatrix(matrix);
            Console.WriteLine();
            RotateMatrix(matrix);
            DisplayMatrix(matrix);
        }

        static void RotateMatrix(int[,] matrix)
        {
            /*
             5  1  9 11       15 13  2  5    [0,0] [0,1] [0,2] [0,3]            
             2  4  8 10 ----> 14  3  4  1 == [1,0] [1,1] [1,2] [1,3]      a 1 2 3 b     7 4 1
            13  3  6  7       12  6  8  9    [2,0] [2,1] [2,2] [2,3]        4 5 6 ----> 8 5 2
            15 14 12 16       16  7 10 11    [3,0] [3,1] [3,2] [3,3]      d 7 8 9 c     9 6 3
            */

            int size = matrix.GetLength(0);
            //int size1 = size - 1;

            //for (int row = 0; row < (size / 2); row++)
            //{
            //    for (int col = row; col < size1 - row; col++) // col = row so it works with inner "rings"
            //    {
            //        #region Original code, kind of hard to follow: swap element [row,col] in place three times via tuples to rotate through matrix

            //        //(matrix[row, col], matrix[col, size1 - row]) = (matrix[col, size1 - row], matrix[row, col]);
            //        //(matrix[row, col], matrix[size1 - row, size1 - col]) = (matrix[size1 - row, size1 - col], matrix[row, col]);
            //        //(matrix[row, col], matrix[size1 - col, row]) = (matrix[size1 - col, row], matrix[row, col]);

            //        #endregion

            //        #region Refactored so it's easier to follow (and maybe better performance by not using tuples? unsure)
            //        // set variables
            //        int a = matrix[row, col];
            //        int b = matrix[col, size1 - row];
            //        int c = matrix[size1 - row, size1 - col];
            //        int d = matrix[size1 - col, row];

            //        // swap variables to "rotate matrix"
            //        int temp = a;
            //        a = d;
            //        d = c;
            //        c = b;
            //        b = temp;

            //        // reassign variables back to matrix
            //        matrix[row, col] = a;
            //        matrix[col, size1 - row] = b;
            //        matrix[size1 - row, size1 - col] = c;
            //        matrix[size1 - col, row] = d;
            //        #endregion

            //        // move to next col
            //    }
            //    // move to next row
            //}


            #region Transpose and Reverse
            /* Transpose (swap rows and columns)
            1 2 3     1 4 7     Row 1 = Col 1 (top-to-bottom)
            4 5 6 --> 2 5 8     Row 2 = Col 2
            7 8 9     3 6 9     Row 3 = Col 3
            */
            for (int row = 0; row < size; row++)
            {
                for (int col = row + 1; col < size; col++)
                {
                    (matrix[row, col], matrix[col, row]) = (matrix[col, row], matrix[row, col]);
                }
            }

            /* Reverse (each row)
            1 4 7     7 4 1
            2 5 8 --> 8 5 2
            3 6 9     9 6 3
            */
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size / 2; col++)
                {
                    int temp = matrix[row, col];
                    matrix[row, col] = matrix[row, size - 1 - col];
                    matrix[row, size - 1 - col] = temp;
                }
            }

            /* The array is now rotated:
            1 2 3     7 4 1
            4 5 6 --> 8 5 2
            7 8 9     9 6 3
            */
            #endregion
        }

        static void DisplayMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            int max = 0;

            // find largest number in matrix
            foreach (int num in matrix)
                if (num > max) max = num;

            // get number of digits in largest number
            // set to max simply to reuse variable
            max = max.ToString().Length;

            // print each element in correct row/col order
            // pad each number by number of digits of max number to keep everything aligned
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col].ToString().PadLeft(max) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
