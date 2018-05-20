<Query Kind="Program" />

void Main()
{
	string  n1 = "218765";
	NextGreaterNumber(n1);
	//Output: "251678"
	Console.WriteLine("");
	string  n2 = "1234";
	NextGreaterNumber(n2);
	//Output: "1243"
	Console.WriteLine("");
	string n3 = "4321";
	NextGreaterNumber(n3);
	//Output: "Not Possible"
	Console.WriteLine("");
	string n4 = "534976";
	NextGreaterNumber(n4);
	//Output: "536479"
	Console.WriteLine("");
}

public static int[] ConvertToArray(string s)
{
	List<int> list = new List<int>();

	for (int i= 0 ; i < s.Length; i++)
	{
		
		list.Add(Convert.ToInt32(s[i]) - 48);
	}
	
	return list.ToArray();
}
public static void NextGreaterNumber(string s)
{
	int[] arr = ConvertToArray(s);
	Array.Sort(arr);
	if (CheckIfSorted(arr, s))
	{
		SwitchLower(arr, s);
		return;
	}
	Array.Reverse(arr);
	if (CheckIfSorted(arr, s))
	{
		Console.WriteLine("Not Possible");
		return;
	}
	
	arr = ConvertToArray(s);
	NextGreaterNumber(arr);
}

public static void NextGreaterNumber(int[] arr)
{
	int idx = arr.Length - 1;
	while (idx > 0)
	{
		if (arr[idx] < arr[ idx- 1])
		{
			idx--;
		}
	}
}
public static bool CheckIfSorted(int[] arr, string s)
{
	var result = string.Join("", arr);
	//Console.WriteLine($"{result}");
	return result.Equals(s);	
}

public static void SwitchLower(int[] arr, string s)
{	
	int Length = s.Length;
	if (Length > 1)
	{
		int temp = arr[Length-1];
		arr[Length-1] = arr[Length-2];
		arr[Length-2] = temp;
	}
	for (int i = 0; i <arr.Length; i++)
        Console.Write(arr[i]);
}