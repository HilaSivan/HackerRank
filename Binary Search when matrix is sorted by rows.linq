<Query Kind="Program" />

//Binary Search- when matrix is sorted by rows

void Main()
{
	int MAX = 5;
	int[,] a = new int[,] {{1,4,7,11,15},{2,5,8,12,19},{3,6,9,16,22},{10,13,14,17,24},{18,21,23,26,30}};
    
	Console.WriteLine($"{binaryPartition(a,MAX,MAX,12)}"); 
   
}

public static bool binaryPartition(int[,] a,int r, int c, int R, int C, int target)
{
    if(c>C || r>R) 
	{
		return false;
	}
    if(target<a[r,c] || target>a[R,C]) return false;
    int mid = c + (C-c)/2;
    int row = r;
    // Binary search position where a[i] < target < a[i+1]
    while(row<=R && a[row,mid]<=target)
    {
        if(a[row,mid]==target) return true;
        row++;
    }
    // Divide into 2 parts
    return binaryPartition(a,row,c,R,mid-1,target) || binaryPartition(a,r,mid+1,row-1,C,target);
}
public static bool binaryPartition(int[,] a, int M, int N, int target)
{
	return binaryPartition(a,0,0,M-1,N-1,target);   
}

// Define other methods and classes here