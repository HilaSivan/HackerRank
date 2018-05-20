<Query Kind="Program" />

void Main()
{
  	string[] magazine = "o l x imjaw bee khmla v o v o imjaw l khmla imjaw x".Split(' ');
    string[] ransom = "imjaw l khmla x imjaw o l l o khmla v bee o o imjaw imjaw o".Split(' ');
    
    if (IsUntraceableReplica(magazine, ransom))
        Console.WriteLine("Yes");
    else
        Console.WriteLine("No");
}

public static bool IsUntraceableReplica(string[] magazine, string[] ransom) 
{   
    Dictionary<string,int> wordDic = new Dictionary<string,int>();
  
    foreach (var word in magazine)   
    {
        if (word.Length>=1 && word.Length <= 5)
        {
           if (!wordDic.ContainsKey(word))
           {
                wordDic.Add(word, 0);    
           }
           wordDic[word]++; 
        }
    }
    
    foreach (var word in ransom)
    {   
        if (word.Length>=1 && word.Length <= 5)
        {
            if (!wordDic.ContainsKey(word))
            {
                return false;
            }
			if (wordDic[word] > 0)
			{	
				wordDic[word]--;
			}
			else
			{
				return false;
			}
        }
    }
    return true;
}