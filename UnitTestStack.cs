using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestProject1;

/*
Design a stack class that supports push, pop, top, and retrieving the maximum element.

The stack stores integers only.

push(int x) -- Push element x onto stack.
pop() -- Removes the element on top of the stack.
top() -- Get the top element.
getMax() -- Retrieve the maximum element in the stack.
*/

public class UnitTestStack
{
    private Stack _stack;

    [SetUp]
    public void Setup()
    {
        _stack = new Stack();
    }

    [Test]
    public void Test_Top_Numbers_One()
    {
        _stack.Push(1);
        Assert.AreEqual(1, _stack.Top());
    }

    [Test]
    public void Test_Top_Numbers_Multi()
    {
        _stack.Push(1);
        _stack.Push(3);
        _stack.Push(2);
        Assert.AreEqual(2, _stack.Top());
    }

    [Test]
    public void Test_After_Pop()
    {
        _stack.Push(1);
        _stack.Push(3);
        _stack.Push(2);
        _stack.Pop();
        Assert.AreEqual(3, _stack.Top());
    }

    [Test]
    public void Test_GetMax()
    {
        _stack.Push(1);
        _stack.Push(3);
        _stack.Push(2);
        Assert.AreEqual(3, _stack.GetMax());
    }

    [Test]
    public void Test_GetMax_After_Pop()
    {
        _stack.Push(1);
        _stack.Push(2);
        _stack.Push(3);
        _stack.Pop();
        Assert.AreEqual(2, _stack.GetMax());
    }
}

public class Stack
{
    private readonly Stack<int> _stack;
    private readonly Stack<int> _maxStack;

    public Stack()
    {
        _stack = new Stack<int>();
        _maxStack = new Stack<int>();
    }

    public void Push(int x)
    {
        _stack.Push(x);
        _maxStack.Push(_maxStack.Count == 0 ? x : Math.Max(_maxStack.Peek(), x));
    }

    public void Pop()
    {
        _stack.Pop();
        _maxStack.Pop();
    }

    public int Top()
    {
        return _stack.Peek();
    }

    public int GetMax()
    {
        return _maxStack.Peek();
    }
}