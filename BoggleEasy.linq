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
	
	Console.WriteLine($"{BoggleGame.IsExist(board,size, "ag")}");
}


public class BoggleGame
{
	private static int[] x = new int[]{ -1, -1, -1, 0, 0, 1, 1, 1 };
	private static int[] y = new int[]{ -1, 0, 1, -1, 1, -1, 0, 1 };
	
	// Searches given word in a given matrix in all 8 directions
	public static bool IsExist(char[,] board,  int size, string word)
	{
		for (int row = 0; row<size; row++)
		{
			for (int col = 0; col < size ; col++)
			{
				if (Search(board, size, row, col, word))
				{
					return true;
				}
			}		
		}		
		
		return false;
	}
	
	// This function searches in all 8-direction from point
	// (row, col) in board
	public static bool Search(char[,] board,  int size, int row, int col, string word)
	{	
		if (board[row,col] != word[0])
		{
			return false;
		}
		
		int len = word.Length;

		int index = 1;
		for (int dir = 0; dir < 8; dir++)
    	{
       	 // Initialize starting point for current direction
		 	int rowDir = row + x[dir];
			int colDir = col + y[dir];	  
 		
	        // First character is already checked, match remaining
	        // characters
	        for (index = 1; index < len; index++)
	        {					
	            // If out of bound break
	            if (rowDir >= size || rowDir < 0 || colDir >= size || colDir < 0)
				{					
	                break;
	 			}
	            // If not matched,  break			
	            if (board[rowDir,colDir] != word[index])
				{					
				      break;
				}
				
	            //  Moving in particular direction
				rowDir += x[dir];
				colDir += y[dir];
			}
			if (index == len)
			{
            	return true;
			}
        }
 
        		
		return false;
	}

}
