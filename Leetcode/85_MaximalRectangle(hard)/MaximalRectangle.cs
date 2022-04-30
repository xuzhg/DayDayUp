/*
Given a rows x cols binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.
*/

using System;
public class Solution {
    public static int MaximalRectangle(char[][] matrix) {
        int max = 0;
        int maxCol = matrix[0].Length;
        int maxRow = matrix.Length;
        int area;
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == '0') continue;

                int CanTouchCol = maxCol;
                int currRow = row;

                for (; currRow < maxRow; currRow++)
                {
                    int currCol = col;
                    if (matrix[currRow][currCol] == '0')
                    {
                        break;
                    }

                    for (; currCol < CanTouchCol; currCol++)
                    {
                        if (matrix[currRow][currCol] == '0')
                        {
                            break;
                        }
                    }

                    if (currCol < CanTouchCol)
                    {
                        CanTouchCol = currCol;
                    }

                    area = (CanTouchCol - col) * (currRow - row + 1);
                    if (area > max)
                        max = area;
                }
            }
        }

        return max;
    }

    public static void Main(string[] args){
        char[][] matrix = new char[][]{
           new char[]{'1','0','1','0','0'}, 
           new char[]{'1','0','1','1','1'}, 
           new char[]{'1','1','1','1','1'}, 
           new char[]{'1','0','0','1','0'},
        };

        Console.WriteLine($"{MaximalRectangle(matrix)}"); // output 6

        char[][] matrix2 = new char[][]
        {
            new char[] {'1','1','1','1','1','1','1','1' },
            new char[] {'1','1','1','1','1','1','1','0' },
            new char[] {'1','1','1','1','1','1','1','0' },
            new char[] {'1','1','1','1','1','0','0','0' },
            new char[] {'0','1','1','1','1','0','0','0' }
        };

        Console.WriteLine($"{MaximalRectangle(matrix2)}"); // output 21

        char[][] matrix3 = new char[][]
        {
            new char[] {'1','1','1','1','1','1','1','1' },
            new char[] {'1','1','1','1','1','1','1','0' },
            new char[] {'1','1','1','1','1','1','1','0' },
            new char[] {'1','1','1','1','1','0','0','0' },
            new char[] {'1','1','1','1','1','0','0','0' },
            new char[] {'0','1','1','1','1','0','0','0' }
        };

        Console.WriteLine($"{MaximalRectangle(matrix3)}"); // output 25
    }
}