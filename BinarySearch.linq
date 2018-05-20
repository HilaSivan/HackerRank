<Query Kind="Program" />

void Main()
{
	int[] a = {2,4,6,8,9};
	
	Console.WriteLine(BinarySearch(a,9));
	
}

public static bool BinarySearch(int[] a, int num)
{
	return BinarySearch(a,num,0,a.Length);

}

private static bool BinarySearch(int[] a, int num, int left, int right)
{
	if (left>right)
	{
		return false;
	}
	
	int mid = (left+right)/2;
	if (a[mid] == num)
	{
		return true;
	}

	if (num < a[mid])
		return BinarySearch(a,num, left,mid-1) ;
	return BinarySearch(a, num, mid+1, right);
}