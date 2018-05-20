<Query Kind="Program" />

//Find all the promotiations of s in a
void Main()
{
	string s = "xacxzaa";	
	string a = "fxaazxacaaxzoecazxaxaz";
		
	Dictionary<char,int> dicChars = CharCount(s);
	int result= CheckHowMuchPermutation(a, dicChars, s.Length);	
	Console.WriteLine($"The result is = {result}");
}

public static void PrintDic(Dictionary<char,int> dic)
{
	foreach (var item in dic)
	{
		Console.Write($"({item.Key}, {item.Value})");
	}
	
	Console.WriteLine(" ");
}

public static Dictionary<char,int> CharCount(string s)
{
	Dictionary<char,int> dic = new Dictionary<char,int>();
	
	foreach(var c in s)  //O(|S|)
	{
		if (!dic.ContainsKey(c))
		{
			dic.Add(c,0);
		}
		dic[c]++;
	}
	//PrintDic(dic);
	return dic;
}

public static int CheckHowMuchPermutation(string a, Dictionary<char,int> dicChars, int size)
{
	int countPermutation = 0;
	for (int i=0; i < a.Count()-size; i++)
	{
		var checkString = a.Substring(i,size);
		//Console.WriteLine($"Checking string: {checkString}");
		if (IsPermutation(checkString, dicChars))
		{
			countPermutation++;
		}	
	}
	
	return countPermutation;
}

public static bool IsPermutation(string checkString, Dictionary<char,int> dicChars)
{
	Dictionary<char,int> strDic = CharCount(checkString);	
	
	foreach (var item in strDic)
	{
		if (!dicChars.ContainsKey(item.Key))
		{
			return false;
		}
		if (!dicChars[item.Key].Equals(item.Value))
		{
			return false;
		}			
	}
	return true;
}