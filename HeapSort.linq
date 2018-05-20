<Query Kind="Program" />

//A Sort Heap a very easy way to sort desc (min heap) and regular sort (max heap)

void Main()
{
	int[] arr = new int[] {7,5,8,3,2,4,9,1};		
    int size =arr.Count();
 
    HeapSort.Sort(arr, size);
    HeapSort.Print(arr);
}

public class HeapSort
{
	static int total;
	
	private static void HeapifyMax(int[] arr, int i)
	{
	    int left = i * 2;
	    int right = left + 1;
	    int parent = i;
		
	    if (left <= total && arr[left] > arr[parent]) parent = left;
	    if (right <= total && arr[right] > arr[parent]) parent = right;
	    if (parent != i) {
	        Swap(arr, i, parent);
	        HeapifyMax(arr, parent);
	    }
	}
	
	private static void HeapifyMin(int[] arr, int i)
	{
	    int left = i * 2;
	    int right = left + 1;
	    int parent = i;
		
	    if (left <= total && arr[left] < arr[parent]) parent = left;
	    if (right <= total && arr[right] < arr[parent]) parent = right;
	    if (parent != i) {
	        Swap(arr, i, parent);
	        HeapifyMin(arr, parent);
	    }
	}
	
	private static void Swap(int[] arr, int index1, int index2)
	{
		int temp = arr[index1];
		arr[index1] = arr[index2];
		arr[index2] = temp;
	}
		
	
	public static void SortDesc(int[] arr, int size)
	{
	    total = size - 1;
	
	    for (int i = total / 2; i >= 0; i--)
		{
	        HeapifyMin(arr, i);
			Console.WriteLine("Build A Min Heap"); 
		}
		
		Print(arr);
		Console.WriteLine("Sort the Heap desc"); 
	    for (int i = total; i > 0; i--)
		{
	        Swap(arr, 0, i);		  
	        total--;
	        HeapifyMin(arr, 0);
	    }
	}
	
	public static void Sort(int[] arr, int size)
	{
	    total = size - 1;
	
	    for (int i = total / 2; i >= 0; i--)
		{
	        HeapifyMax(arr, i);
			Console.WriteLine("Build A Mac Heap"); 
		}
		
		Print(arr);
		Console.WriteLine("Sort the Heap"); 
	    for (int i = total; i > 0; i--)
		{
	        Swap(arr, 0, i);		  
	        total--;
	        HeapifyMax(arr, 0);
	    }
	}
	public static void Print(int[] arr)
    {
		Console.WriteLine("");
        for (int i = 0; i < arr.Length; i++)
        { Console.Write("[{0}]", arr[i]); }
		Console.WriteLine("");
    }
}