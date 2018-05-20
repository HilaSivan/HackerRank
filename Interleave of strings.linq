<Query Kind="Program" />

void Main()
{
	string s1 = "eZCHXr0CgsB4O3TCDlitYI7kH38rEElI";
	string s2 = "UhSQsB6CWAHE6zzphz5BIAHqSWIY24D";
	string s3 = "eUZCHhXr0SQsCgsB4O3B6TCWCDlAitYIHE7k6H3z8zrphz5EEBlIIAHqSWIY24D";
	
	Console.WriteLine(IsInterleave(s1,s2,s3));
}

public static bool IsInterleave(string s1, string s2, string s3)
{
	int len1 = s1.Length;
	int len2 = s2.Length;
	int len3 = s3.Length;
	
	if (len3 != (len1 +len2))
	{
		return false;
	}
	
	return CheckIsInterleave(s1,s2,s3, 0,0,0);
}

public static bool CheckIsInterleave(string s1, string s2, string s3, int index1, int index2, int index3)
{
	if (index3 == s3.Length)
	{		
		return true;
	}

	if (index1 <s1.Length && index2< s2.Length && s1[index1] == s2[index2] && s2[index2] == s3[index3])
	{
		int i1 = index1 +1;
		int i2 = index2 +1;
		index3 = index3 + 1;
		return CheckIsInterleave(s1, s2,s3, i1, index2, index3) || CheckIsInterleave(s1, s2,s3, index1, i2, index3);
	
	}
	if (index1< s1.Length && s1[index1] == s3[index3])
	{	
		index1 = index1 + 1;
		index3 = index3 + 1;
	
		return CheckIsInterleave(s1, s2,s3, index1, index2, index3);
	}
	
	if (index2< s2.Length && s2[index2] == s3[index3])
	{		
		index2 = index2 + 1;
		index3 = index3 + 1;
	
		return CheckIsInterleave(s1, s2,s3, index1, index2, index3);
	}
	
	return false;
}
