// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
// Implement the MinStack class:
// MinStack() initializes the stack object.
// void push(int val) pushes the element val onto the stack.
// void pop() removes the element on the top of the stack.
// int top() gets the top element of the stack.
// int getMin() retrieves the minimum element in the stack.

using System;
using System.Collections.Generic;

public class MinStack
{
    private Stack<int> stack;
    private Stack<int> minStack;
    public MinStack()
    {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }

    public void Push(int val) 
    {
        stack.Push(val);

        if (minStack.Count <= 0) {
            minStack.Push(val);
        }
        else
        {
            int minVal = minStack.Peek();
            minVal = minVal < val ? minVal : val;
            minStack.Push(minVal);
        }
    }

    public void Pop()
    {
        stack.Pop();
        minStack.Pop();
    }

    public int Top()
    {
        return stack.Peek();
    }

    public int GetMin()
    {
        return minStack.Peek();
    }
}

public class Solution
{
    public static void Main(){
        MinStack stack = new MinStack();

        stack.Push(3);
        Console.WriteLine(stack.GetMin());

        stack.Push(4);
        Console.WriteLine(stack.GetMin());

        stack.Push(2);
        Console.WriteLine(stack.GetMin());

        stack.Push(1);
        Console.WriteLine(stack.GetMin());

        stack.Pop();
        Console.WriteLine(stack.GetMin());

        stack.Pop();
        Console.WriteLine(stack.GetMin());

        stack.Push(0);
        Console.WriteLine(stack.GetMin());
    }
}