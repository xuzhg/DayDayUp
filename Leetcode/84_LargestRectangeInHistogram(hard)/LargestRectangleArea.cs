/*
Given an array of integers heights representing the histogram's bar height where the width of each bar is 1,
 return the area of the largest rectangle in the histogram.
*/

using System;

public class Solution {
    public static int LargestRectangleArea(int[] heights) {
        if (heights == null || heights.Length == 0) return 0;
        if (heights.Length == 1) return heights[0];

        int max = 0;
        for (int i = 0; i < heights.Length; i++) {
            if (i > 0 && heights[i] == heights[i - 1])
                continue;

            int iHeight = heights[i];
            int j = i - 1;
            for (; j >=0; --j) {
                if (heights[j] < iHeight) break;
            }

            int k = i + 1;
            for (; k < heights.Length; k++) {
                if (heights[k] < iHeight) break;
            }

            int width = k - j - 1;
            int area = iHeight * width;
            if (area > max) max = area;
        }

        return max;
    }

    public static void Main(string[] args){
        int[] heights = {2,1,5,6,2,3};
        Console.WriteLine($"Test 1 Height: {LargestRectangleArea(heights)}");

        int[] heights2 = {2,4};
        Console.WriteLine($"Test 2 Height: {LargestRectangleArea(heights2)}");
    }
}