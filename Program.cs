using System;

public class MaxHeap<E> where E : IComparable<E>
{
    private E[] heap;
    private int size;

    public MaxHeap(int capacity)
    {
        heap = new E[capacity];
        size = 0;
    }

    public int Size => size;

    public void Add(E element)
    {
        if (size == heap.Length)
            throw new InvalidOperationException("MaxHeap is full.");

        heap[size] = element;
        HeapifyUp(size);
        size++;
    }

    public E Peek()
    {
        if (size == 0)
            throw new InvalidOperationException("MaxHeap is empty.");

        return heap[0];
    }

    private void HeapifyUp(int currentIndex)
    {
        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;

            if (heap[currentIndex].CompareTo(heap[parentIndex]) > 0)
            {
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void Swap(int index1, int index2)
    {
        E temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }
}

public class Program
{
    public static void Main()
    {
        // Пример использования MaxHeap
        MaxHeap<int> maxHeap = new MaxHeap<int>(5);

        maxHeap.Add(5);
        maxHeap.Add(2);
        maxHeap.Add(8);

        Console.WriteLine("Peek: " + maxHeap.Peek()); // Вывод: 8
        Console.WriteLine("Size: " + maxHeap.Size); // Вывод: 3
    }
}
