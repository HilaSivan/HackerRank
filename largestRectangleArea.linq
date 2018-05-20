<Query Kind="Program" />

void Main()
{
	int[] a= {2,1,5,6,2,3};
	Console.WriteLine(largestRectangleArea(a));
}

public int largestRectangleArea(int[] height) 
{
	if (height == null || height.Length == 0) 
	{
		return 0;
	}
 
	Stack<int> stack = new Stack<int>();
 
	int max = 0;
	int i = 0;
 
	while (i < height.Length) 
	{
		//push index to stack when the current height Is larger than the previous one
		if (stack.Count == 0 || height[i] >= height[stack.Peek()]) 
		{
			stack.Push(i);
			i++;
		} else 
		{
		//calculate max value when the current height Is less than the previous one
			int p = stack.Pop();
			int h = height[p];
			int w = stack.Count == 0  ? i : i - stack.Peek() - 1;
			Console.WriteLine($"w ={w}");
			max = Math.Max(h * w, max);
		}
 
	}
 
	while (stack.Count > 0) 
	{
		int p = stack.Pop();
		int h = height[p];
		int w = stack.Count == 0 ? i : i - stack.Peek() - 1;			
		max = Math.Max(h * w, max);
	}
 
	return max;
}