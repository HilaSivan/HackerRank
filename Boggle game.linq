<Query Kind="Program" />

void Main()
{
	int size = 5;
	char[,] board = new char[size,size];
	
	board[0,0] = 'k';
	board[0,1] = 'u';
	board[0,2] = 'b';
	board[0,3] = 'a';
	board[0,4] = 'v';
	
	board[1,0] = 'i';
	board[1,1] = 'e';
	board[1,2] = 'e';
	board[1,3] = 'a';
	board[1,4] = 'z';

	board[2,0] = 'l';
	board[2,1] = 'e';
	board[2,2] = 'g';
	board[2,3] = 'g';
	board[2,4] = 'd';

	board[3,0] = 'r';
	board[3,1] = 'h';
	board[3,2] = 'o';
	board[3,3] = 's';
	board[3,4] = 'w';
		
	board[4,0] = 't';
	board[4,1] = 'i';
	board[4,2] = 'd';
	board[4,3] = 'o';
	board[4,4] = 'g';

/*
	board[0,0] = 'a';
	board[0,1] = 'b';
	board[0,2] = 'b';
	
	board[1,0] = 'k';
	board[1,1] = 'h';
	board[1,2] = 'i';

	board[2,0] = 't';
	board[2,1] = 'r';
	board[2,2] = 's';

*/
	Node root = AddWordsToTrie(board, size);
	Console.WriteLine($"{root.FindCount("hi")}");
	Console.WriteLine($"{root.FindCount("ri")}");
}



public static Node AddWordsToTrie(char[,]  board, int size)  
{
	Node root = new Node();
	
	//Run all the rows and add the words;
	for (int row= 0; row < size; row++)
	{				
		string word = string.Empty;
		for (int col=0; col< size; col++)
		{
			word += board[row,col];		
		}	
		if (!word.Equals(string.Empty))	
		{
			//Console.WriteLine($"debug1: {word}");		
			AddWord(root, word);
		}			
	}
	//Run all te columns and add the words
	for (int col= 0; col < size; col++)
	{		
		string word = string.Empty;
		for (int row=0; row< size; row++)
		{
			word += board[row,col];		
		}	
		if (!word.Equals(string.Empty))	
		{
			//Console.WriteLine($"debug2: {word}");	
			AddWord(root, word);
		}		
	}
	
	//the biggest - Diagonals bottom right to up left
	for (int row=size-1; row>=0; row--)
	{	
		int index = row;
		
		do
		{
			int rowIndex = row;
			string word = string.Empty;
			for (int col = index; col<= row && rowIndex>=0; col++)
			{
				word +=  board[rowIndex,col];	
				rowIndex--;
			}		
			if (!word.Equals(string.Empty))	
			{
				AddWord(root, word);
			}
			
			index--;
		}while (index >=0);
	}
	
	//the biggest - Diagonals up left to bottom right	
	for (int row=0; row< size; row++)
	{		
		int rowIndex = size-1 - row;	
		int index = 0;
		do
		{
			string word = string.Empty;
			for (int col = index; col<= row && rowIndex < size; col++)
			{
				word +=  board[rowIndex,col];	
				rowIndex++;
			}
			if (!word.Equals(string.Empty))	
			{			
				AddWord(root, word);
			}
			index++;
		}while (index < size);
	}
	
	//the biggest - Diagonals up left to bottom right	
	for (int row=0; row<size; row++)
	{		
		int rowIndex = row;		
		int index = size-1;
		do
		{
			string word = string.Empty;
			for (int col = index; col<=size && rowIndex>=0; col--)
			{
				word +=  board[rowIndex,col];	
				rowIndex--;
			}
			if (!word.Equals(string.Empty))	
			{			
				AddWord(root, word);
			}
			index++;
		}while (index < size);
	}
	
	return root;
}

private static void AddWord(Node root, string word)
{
	root.Add(word);
	if (word.Length == 1)
	{
		return;
	}
	
	AddWord(root,word.Substring(1));	
}

public static string ReverseWord( string s )
{
    char[] charArray = s.ToCharArray();
    Array.Reverse( charArray );
    return new string( charArray );
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
		string reversePrefix = ReverseWord(prefix);
		return FindCount(prefix,0, this) + FindCount(reversePrefix,0, this);
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
