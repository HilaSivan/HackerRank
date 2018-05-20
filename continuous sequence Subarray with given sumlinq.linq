<Query Kind="Program" />

/*
Given an unsorted array of non-negative integers, find a continous subarray which adds to a given number.

*/
void Main()
{
	int[]A = {1,2, 3, 4 ,5 ,6, 7 ,8 ,9 ,10};
	int T = 15;
	
	Console.WriteLine(Position(A,T));

}

 public static bool Position(int[] A, int T) 
 {
    int start = 0;
    int end = 0;
    int sum = 0;

    while( start < A.Length )
    {
        if( sum < T )
        {
            if( end >= A.Length )
                break;
            sum += A[end];
            end++;
        }
        else if( sum > T )
        {
            sum -= A[start];
            start++;
        }
        else if( sum == T )
		{
			Console.WriteLine($"{start +1} {end}");
            return true;       
			
		}
    }

    return false;
}
	