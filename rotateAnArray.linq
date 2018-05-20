<Query Kind="Program" />

//Rotate a 2D array without using extra space

//http://www.geeksforgeeks.org/array-rotation/ - do single array

void Main()
{
	int[,] array = new int[4,4] {
								    { 1,2,3,4 },
								    { 5,6,7,8 },
								    { 9,0,1,2 },
								    { 3,4,5,6 }
								};
	printRotatedArray(array, 4);	
	int[,] rotated = RotateMatrix(array, 4);
	Console.WriteLine("");
	printRotatedArray(rotated, 4);	
	
	rotateMatrixInplace(array, 4);
	Console.WriteLine("");
	printRotatedArray(array, 4);	
}

// O(n^2) memory and O(n^2) complexity
static int[,] RotateMatrix(int[,] matrix, int n) {
    int[,] ret = new int[n, n];

    for (int i = 0; i < n; ++i) 
	{
        for (int j = 0; j < n; ++j)
		{
            ret[i, j] = matrix[n - j - 1, i];
        }
    }

    return ret;
}

// O(1) memory and O(n^2) complexity:
//http://k2code.blogspot.co.il/2014/03/rotate-n-n-matrix-by-90-degrees.html
 public static void rotateMatrixInplace(int[,] matrix, int N) 
 {
 
    for(int i = 0; i < N/2; ++i) 
	{
        for(int j = 0; j < (N+1)/2; ++j) 
		{
            int temp = matrix[i,j];  // save the top element;
            matrix[i,j] = matrix[N-1-j,i];  // right -> top;
            matrix[N-1-j,i] = matrix[N-1-i,N-1-j]; // bottom -> right;
            matrix[N-1-i,N-1-j] = matrix[j,N-1-i];// left -> bottom;
            matrix[j,N-1-i] = temp;                // top -> left;
        }
    }
}

public static void printRotatedArray(int[,] array , int n)
{
    for (int i = 0; i < n; i++) 
	{
        for (int j = 0; j < n; j++) 
		{
            Console.Write(array[i,j]);
        }      
		Console.WriteLine("");
    }
}   