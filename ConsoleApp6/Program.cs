using System;

public class Stack<T>
{
    private T[] items;
    private int count;

    public Stack()
    {
        items = new T[4];
        count = 0;
    }

    public void Push(T obj)
    {
        if (count == items.Length)
        {
            Array.Resize(ref items, items.Length * 2); 
        }

        items[count++] = obj;
    }

    public T Pop()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("Empty");
        }

        T poppedItem = items[--count];
        items[count] = default(T);
        return poppedItem;
    }

    public void Clear()
    {
        Array.Clear(items, 0, count);
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    public T Peek()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("Empty");
        }

        return items[count - 1];
    }

    public void CopyTo(T[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.Length < count)
        {
            throw new ArgumentException("Empty");
        }

        Array.Copy(items, 0, array, 0, count);
    }
    static void Main()
    {
        Stack<int> myStack = new Stack<int>();

        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);

        Console.WriteLine("Count: " + myStack.Count);

        int poppedItem = myStack.Pop();
        Console.WriteLine("Popped item: " + poppedItem);

        Console.WriteLine("Peek: " + myStack.Peek());

        int[] array = new int[myStack.Count];
        myStack.CopyTo(array);

        Console.WriteLine("Stack contents copied to array:");
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }

        myStack.Clear();
        Console.WriteLine("Count after clear: " + myStack.Count);
    }
}
