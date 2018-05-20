<Query Kind="Program" />

void Main()
{
	string a = "aac";
	string b = "cde";
	
	
	Console.WriteLine($"{Need2Delete(a,b)}");
	
}

public static int Need2Delete(string a, string b)
{
	int[] ca = new int[26];
	int[] cb = new int[26];

	Array.Clear(ca, 0, ca.Length);
	for (int i =0 ; i < a.Count(); i++)
	{
		ca[a[i]- 'a']++;		
	}
	
	Array.Clear(cb, 0, cb.Length);
	for (int i =0 ; i < b.Count(); i++)
	{
		cb[b[i] - 'a']++;		
	}
	
	
	for (int i =0 ; i < ca.Count(); i++)
	{
		Console.Write($" {ca[i]} ");
		
	}
	
	Console.WriteLine(" ");
	for (int i =0 ; i < cb.Count(); i++)
	{
		Console.Write($" {cb[i]} ");
		
	}
	
	Console.WriteLine(" ");
	int sum = 0;
	
	for (int i=0; i< ca.Count() ; i++)
	{
		sum += Math.Abs(ca[i] - cb[i]);			
	}
	
	
	
	return sum;
}