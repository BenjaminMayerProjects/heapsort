using System;

class HeapSortArraySolution
{
    public static void HeapSortArray<T>(T[] arr) where T : IComparable<T>
    {
        int arrayLength = arr.Length;

        for (int i = arrayLength / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, arrayLength, i);
        }

        for (int i = arrayLength - 1; i >= 0; i--)
        {
            T temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            Heapify(arr, i, 0);
        }
    }

    private static void Heapify<T>(T[] arr, int n, int i) where T : IComparable<T>
    {
        int largestNumber = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left].CompareTo(arr[largestNumber]) > 0)
        {
            largestNumber = left;
        }

        if (right < n && arr[right].CompareTo(arr[largestNumber]) > 0)
        {
            largestNumber = right;
        }

        if (largestNumber != i)
        {
            T swap = arr[i];
            arr[i] = arr[largestNumber];
            arr[largestNumber] = swap;

            Heapify(arr, n, largestNumber);
        }
    }

    static void Main(string[] args)
    {
        int[] array = { 12, 11, 13, 5, 6, 7 };

        Console.WriteLine("Input Array:");
        printTheArray(array);

        HeapSortArray(array);

        Console.WriteLine("Sorted Array:");
        printTheArray(array);
    }

    static void printTheArray<T>(T[] arr)
    {
        foreach (T item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

