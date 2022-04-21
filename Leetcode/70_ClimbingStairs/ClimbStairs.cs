/*
You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
*/
using System;
public class Solution {

    // using memory O(n)
    public static int ClimbStairs(int n) {
        if (n <= 0) return 0;
        if (n == 1) return 1;
        if (n == 2) return 2;

        int[] data = new int[n + 1];
        data[1] = 1;
        data[2] = 2;
        for (int i = 3; i <= n; ++i){
            data[i] = data[i-1] + data[i-2];
        }

        return data[n];
    }

    // not use the memory: O(1)
    public static int ClimbStairs_2(int n) {
        if (n <= 0) return 0;
        if (n == 1) return 1;
        if (n == 2) return 2;

        int previous = 1;
        int current = 2;
        for (int i = 3; i <= n; ++i){
            int temp = current;
            current = previous + current;
            previous = temp;
        }

        return current;
    }

    private static void Main(string[] args) {
        Console.WriteLine($"Climb Stair 1: {ClimbStairs(1)}");
        Console.WriteLine($"Climb Stair 2: {ClimbStairs(2)}");
        Console.WriteLine($"Climb Stair 3: {ClimbStairs(3)}");
        Console.WriteLine($"Climb Stair 4: {ClimbStairs(4)}");
        Console.WriteLine($"Climb Stair 5: {ClimbStairs(5)}");
        Console.WriteLine($"Climb Stair 10: {ClimbStairs(10)}");
        Console.WriteLine($"Climb Stair 30: {ClimbStairs(30)}");

        Console.WriteLine($"Climb Stair-----");
        Console.WriteLine($"Climb Stair 1: {ClimbStairs_2(1)}");
        Console.WriteLine($"Climb Stair 2: {ClimbStairs_2(2)}");
        Console.WriteLine($"Climb Stair 3: {ClimbStairs_2(3)}");
        Console.WriteLine($"Climb Stair 4: {ClimbStairs_2(4)}");
        Console.WriteLine($"Climb Stair 5: {ClimbStairs_2(5)}");
        Console.WriteLine($"Climb Stair 10: {ClimbStairs_2(10)}");
        Console.WriteLine($"Climb Stair 30: {ClimbStairs_2(30)}");
    }
}