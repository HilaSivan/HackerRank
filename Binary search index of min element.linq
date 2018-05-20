<Query Kind="Program" />

/*
	the array rotated to the right
	Number of routation == index of min element
*/

void Main()
{
	int[]array = {4,5,6,7,0,1,2};
	
	Console.WriteLine(PrintMinimumIndex(array));
}


public static int PrintMinimumIndex(int[]array)
{
	int right = array.Length-1;
	return  (PrintMinimumIndex(array, 0, right)).Item2;
}

private static Tuple<int,int> PrintMinimumIndex(int[] a,int left, int right)
{	
	if (right - left == 0)
	{
		return Tuple.Create(a[left], left);
	}
	if (right - left == 1)
	{
		if (a[left]<a[right])
			return  Tuple.Create(a[left], left);
		return Tuple.Create(a[right], right);
	}
	int mid = (right+ left)/2;
	var leftResult = PrintMinimumIndex(a, left, mid);
	var rightResult = PrintMinimumIndex(a, mid+1, right);
	
	if (leftResult.Item1 <rightResult.Item1)
	{
		return leftResult;
	}
	else
	{	
		return rightResult;
	}
}


public static int PrintMinimum(int[]array)
{
	int right = array.Length-1;
	return  PrintMinimum(array, 0, right);
}

private static int PrintMinimum(int[] a,int left, int right)
{	
	if (right - left == 0)
	{
		return a[left];
	}
	if (right - left == 1)
	{
		return Math.Min(a[left],a[right]);
	}
	int mid = (right+ left)/2;
	return Math.Min(PrintMinimum(a, left, mid),PrintMinimum(a, mid+1, right) );
}