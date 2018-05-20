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
	
	BoggleGame boggle = new BoggleGame();
	boggle.BuildBoard(board,size);
	Console.WriteLine(boggle.Search("wdz"));
}

public class BoggleGame
{		
	private class Point
	{
		public int X {set; get;}
		public int Y {set; get;}
		
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
	
	public Node Trie {set; get;} = new Node();
	
	public void BuildBoard(char[,] board, int size)
	{
		Dictionary<char, List<Point>> wordsDic = InitDic(board, size);
		BuildTrie(board, size, wordsDic);
	}
	
	public bool Search(string word)
	{
		string reverseWord = ReverseWord(word);
		return ((Trie.FindCount(word) > 0) || (Trie.FindCount(reverseWord) > 0));	
	}
	
	private string ReverseWord(string word)
	{
	    char[] charArray = word.ToCharArray();
	    Array.Reverse( charArray );
	    return new string( charArray );
	}

	private Dictionary<char, List<Point>> InitDic(char[,] board, int size)
	{
		Dictionary<char, List<Point>> wordsDic = new  Dictionary<char, List<Point>>();
		
		for (int row=0; row<size; row++)
		{
			for (int col=0; col<size; col++)
			{
				if (!wordsDic.ContainsKey(board[row,col]))
				{
					wordsDic.Add(board[row,col], new List<Point>());
				}
				wordsDic[board[row,col]].Add(new Point(row, col));
			}
		}
		
		return wordsDic;
	}

	private void BuildTrie(char[,] board,int size,Dictionary<char, List<Point>> wordsDic)
	{
		foreach (var letter in wordsDic.Keys)
		{
			foreach(var point in wordsDic[letter])
			{
				InsertAllWords(board, size,point );
			}	
		}
	}

	private void InsertAllWords(char[,] board, int size, Point point)
	{
		int[] x = new int[]{ -1, -1, -1, 0, 0, 1, 1, 1 };
		int[] y = new int[]{ -1, 0, 1, -1, 1, -1, 0, 1 };
	
	
		int index = 1;
		for (int dir = 0; dir < 8; dir++)
		{   
			string word = ""+ board[point.X, point.Y];
	      
		 	int rowDir = point.X + x[dir];
			int colDir = point.Y + y[dir];	  
			
	        for (index = 1; index < size; index++)
	        {					
	            // If out of bound break
	            if (rowDir >= size || rowDir < 0 || colDir >= size || colDir < 0)
				{					
	                break;
	 			}
	           	
	           	word += board[rowDir, colDir];
	          
				rowDir += x[dir];
				colDir += y[dir];
			}	
			
			Trie.Add(word);
	    } 
	}
}

public class Node
{
	
	private Dictionary<char, Node> Children {set; get;} = new Dictionary<char, Node>();
	private bool IsCompleteWord {set; get;}
	private int NumberOfChildren {set; get;}
	
	private Node GetNode(char c)
	{
		if (Children.ContainsKey(c))
		{
			return Children[c];
		}
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
		Add(word, 0, this);
	}
	
	private void Add(string word, int index, Node node)
	{
		node.NumberOfChildren++;
		
		if (index == word.Length)
		{
			node.IsCompleteWord = true;
			return;
		}
		
		Node child = node.GetNode(word[index]);
		if (child == null)
		{
			child = new Node();
			node.SetNode(word[index], child);
		}
		index++;
		Add(word, index, child);
	}
	
	public int FindCount(string prefix)
	{
		return FindCount(prefix, 0, this);
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
		return FindCount(prefix, index, child);
	}
	

}