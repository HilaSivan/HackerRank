<Query Kind="Program" />

//Find all the promotiations of s
void Main()
{
	//string s = "xacxzaa";
	Dictionary<string, int> permutations = new Dictionary<string, int>();
	string s = "AABC";
	WordPermuatation(string.Empty,s,permutations);
	foreach (var p in permutations)
	{
		Console.WriteLine(p);
	}
	Console.WriteLine(permutations.Count());
}

public static void WordPermuatation(string prefix, string word, Dictionary<string, int> permutations)
{
    int n = word.Length;
    if (n == 0) 
	{ 
		if (!permutations.ContainsKey(prefix))
			permutations.Add(prefix,1);	
		//Console.WriteLine(prefix); 
	}
    else
    {
        for (int i = 0; i < n; i++)
        {
            WordPermuatation(prefix + word[i],word.Substring(0, i) + word.Substring(i + 1, n - (i+1)), permutations);
        }
    }
}