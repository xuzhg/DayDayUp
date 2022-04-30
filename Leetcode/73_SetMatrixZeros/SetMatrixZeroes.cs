/*
Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.

You must do it in place.
*/

using System;
using System.Collections.Generic;

public class Solution {
    public static void SetZeroes(int[][] matrix) {

        ISet<int> rows = new HashSet<int>();
        ISet<int> cols = new HashSet<int>();

        for (int row = 0; row < matrix.Length; row++) {
            for (int col = 0; col < matrix[row].Length; col++) {
                if (matrix[row][col] == 0) {
                    rows.Add(row);
                    cols.Add(col);
                }
            }
        }

        foreach(int row in rows) {
            for (int col = 0; col < matrix[row].Length; col++) {
                matrix[row][col] = 0;
            }
        }

        foreach(int col in cols) {
            for (int row = 0; row < matrix.Length; row++) {
                matrix[row][col] = 0;
            }
        }
    }

    public static void Main(string[] args){

    }
}