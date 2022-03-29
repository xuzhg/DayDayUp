// Define a stack which includes a Min method can return the min item in the stack.
// the time complexity of Min, Push, Pop are O(1)
using System;
using System.Collections.Generic;

public class StackWithMin<T>
{
    private Stack<T> _stack = new Stack<T>();
    private Stack<T> _minStack = new Stack<T>();

    private Func<T, T, bool> _predicate;
    public StackWithMin(Func<T,T,bool> predicate){
        _predicate = predicate;
    }

    public T Min()
    {
        return _minStack.Peek();
    }

    public T Pop()
    {
        _minStack.Pop();
        return _stack.Pop();
    }

    public void Push(T item){

        _stack.Push(item);

        if (_minStack.Count > 0)
        {
            T topMin = _minStack.Peek();
            if (_predicate(item,topMin)){
                _minStack.Push(item);
            }
            else {
                _minStack.Push(topMin);
            }
        }
        else
        {
            _minStack.Push(item);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        StackWithMin<int> stack = new StackWithMin<int>((a, b) => a < b);

        stack.Push(3);
        Console.WriteLine(stack.Min());

        stack.Push(4);
        Console.WriteLine(stack.Min());

        stack.Push(2);
        Console.WriteLine(stack.Min());

        stack.Push(1);
        Console.WriteLine(stack.Min());

        stack.Pop();
        Console.WriteLine(stack.Min());

        stack.Pop();
        Console.WriteLine(stack.Min());

        stack.Push(0);
        Console.WriteLine(stack.Min());
    }
}