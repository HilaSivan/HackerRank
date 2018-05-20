<Query Kind="Program" />

void Main()
{
	//int[]A = {1,5 ,4 ,1 ,2};
	int[]A = 	{1, 1, 1};
	int T = 0;
	Array.Sort(A); //O(nlog(N)) in averege. worst case- O(N^2)
	
	/*for (int i = 0; i < A.Length; i++)
        Console.WriteLine(A[i]);*/
 	Sum2(A,T);
}  

//	O(N)
public static void Sum2(int[] A, int T) 
{
    int start = 0;
    int end = A.Length - 1;
 	int sum;
     while( start < A.Length && end > 0 && start< end && end < A.Length )
    {
		sum = Math.Abs( A[start] - A[end]);
	
        if( sum < T )
        {
           start++;
        }
        else if( sum > T )
        {                
            end--;
        }
        else if( sum == T  )
		{
			Console.WriteLine($"{A[start]} - {A[end]} = {T}");
            start++;   
			end++;
		}
    }

   
}
	
// Define other methods and classes here
