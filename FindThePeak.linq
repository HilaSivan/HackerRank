<Query Kind="Program" />

/*Given an array, find the peak:
	char[] array = {'a','b','c','d','e','f','g','h','i'}; 
	position 2 is a peak iff b>=a and b>=c. i this example: 9 is a peak iff i>=h
	find the peak if exist (if it is always >= it will always exist
	But what will happen if it needs to b b>a and b>c ???
	FindPeak and FindPeak2 is in O(n) complexity
*/

/*
	 Divide and Conquer algo - O(logn) - FindPeak3 recursive
*/

void Main()
{
	char[] array = {'z','b','c','d','e','f','g','h','i'}; 
	
	Console.WriteLine($"{FindPeak3(array)}");
}


public static int FindPeak(char []arr)
{
	int peakIndex = -1;
	char peak = '0';
	char prev = arr[0];
	
	for (int i=0; i< arr.Length; i++)
	{
		char next = arr[i];
		if ( i+1 < arr.Length)
		{
			next = arr[i+1];
		}
		if (arr[i] >= prev && arr[i] >= next&& arr[i]>= peak)
		{
			peak = arr[i];	
			peakIndex = i+1;
		}
		prev = arr[i];
	}

	return peakIndex;
}

//Only gearter
public static int FindPeak2(char []arr)
{
	int peakIndex = -1;
	char peak = '0';
	char prev = '1';
	
	for (int i=0; i< arr.Length; i++)
	{
		char next = arr[i];
		if ( i+1 < arr.Length)
		{
			next = arr[i+1];
		}
		else
		{
			next = '1';
		}
		Console.WriteLine($"char: {arr[i]} prev: {prev} next: {next}");
		if (arr[i] > prev && arr[i] > next && arr[i]> peak)
		{
			
			peak = arr[i];	
			peakIndex = i+1;
			Console.WriteLine($"Peak is: {peak} and index: {peakIndex}");
		}
		prev = arr[i];
	}

	return peakIndex;
}
 

public static int FindPeak3(char []arr)
{	
	
	return Recursisve(arr, 0, arr.Length-1)+1;
}



static int Recursisve(char[] a,int l,int r)
{
	if (l==r) 
	{ 
	 	return l; //trivial case, if there is only one value in the array return it
	}
		
	int m=(l+r)/2; //find value halfway into the array
	int u=Recursisve(a,l,m); //find the maximum value for the lower part of the array
	int v=Recursisve(a,m+1,r); //find the maximum value for the top part of the array
	return a[u]>a[v]?u:v; //return the highest value of them.
}
// Define other methods and classes here
