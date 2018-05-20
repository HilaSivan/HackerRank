<Query Kind="Program" />

/* Given an array of integers, write an in-place function to bring all the non-zero elements
to the left of the array keeping the original order. 
*/

void Main()
{
	int[] arr = {5,4,0,3,0,2,0,0,2,1,6,7,0,6,0,0,9};
	
	
	//Move all zeroes to end of array
	ZeroesAfter(arr);
	foreach (var n in arr)
		Console.Write($"{n},");
	
	Console.WriteLine();
	//Move all zeroes to start of array
	ZeroBefore(arr);
	foreach (var n in arr)
		Console.Write($"{n},");
	
	//Expected Result:
	// 0,0,0,0,0,0,0,5,4,3,2,2,1,6,7,6,9
	
}

public static void ZeroesAfter(int[] arr)
{
	int countNoZero = 0;
	for (int i = 0; i<arr.Count(); i++)
	{
		if (arr[i] != 0)
		{
			arr[countNoZero++] = arr[i];
		}
	}

	for (int i = countNoZero; i < arr.Count(); i++)
	{
		arr[countNoZero++] = 0;	
	}	
}

public static void ZeroBefore(int[] arr)
{
	int index = arr.Length-1;
	for (int i = index; i>= 0; i--)
	{
		if (arr[i] != 0)
		{
			arr[index--] = arr[i];
		}
	}

	for (int i = 0; i <= index; i++)
	{
		arr[i] = 0;	
	}	
}