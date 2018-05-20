<Query Kind="Program" />

void Main()
{
	Node root = new Node();

/*
	root.Add("hack");
	root.Add("hackerrank");
	Console.WriteLine($"FindCount: {root.FindCount("hac")}");
	Console.WriteLine($"FindCount: {root.FindCount("hak")}");
	
	*/
	
	root.Add("sa");
	root.Add("ss");	
	root.Add("sss");
	root.Add("ssss");
	root.Add("sssss");


	Console.WriteLine($"FindCount: {root.FindCount("s")}");
	Console.WriteLine($"FindCount: {root.FindCount("ss")}");
	Console.WriteLine($"FindCount: {root.FindCount("sss")}");
	Console.WriteLine($"FindCount: {root.FindCount("ssss")}");
	Console.WriteLine($"FindCount: {root.FindCount("sssss")}");
	
	
}

public class Node
{	
	public Dictionary<char, Node> Children {set;get;} = new Dictionary<char, Node>();
	public bool IsCompletedWord {set;get;}
	public int NumberOfChildren {set;get;}

	private Node GetNode(char c)
	{
		if (Children.ContainsKey(c))
			return Children[c];
		return null;
	}
	
	private void SetNode(char c, Node node)
	{
		if (!Children.ContainsKey(c))
		{			
			Children.Add(c,node);
		}		
	}
	
	public void Add(string word)
	{
		Add(word,0, this);
	}
	
	private void Add(string word, int index, Node node)
	{	
		node.NumberOfChildren++;
		if (index == word.Length)
		{			
			node.IsCompletedWord =true;
			return;
		}
		char childChar = word[index];
		Node child = node.GetNode(childChar);
		if (child == null)
		{
			child = new Node();
			node.SetNode(childChar, child);
		}
		index++;
		Add(word, index, child);
	}
	
	public int FindCount(string prefix)
	{
		return FindCount(prefix,0, this);
	}
	
	private int FindCount(string prefix, int index, Node node)
	{
		if (index == prefix.Length)
		{
			return node.NumberOfChildren;
		}
		Node child = node.GetNode(prefix[index]);
		if (child == null)
		{
			return 0;
		}
		index++;
		return FindCount(prefix,index, child); 
	}
}


