<Query Kind="Program" />

//Count all distinct pairs with difference equal to k
//Given an integer array and a positive integer k, count all distinct pairs with 
//difference equal to k.


void Main()
{
	int[]A = {8, 12, 16, 4, 0, 20};
	int T = 4;
	Array.Sort(A); //O(nlog(N)) in averege. worst case- O(N^2)
	
	   for (int i = 0; i <A.Length; i++)
                Console.WriteLine(A[i]);
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
		sum = A[end] - A[start];
        if( sum < T )
        {
           start++;
        }
        else if( sum > T )
        {                
            end--;
        }
        else if( sum == T )
		{
			Console.WriteLine($"({A[end]},{A[start]}) = {T}");
			if (end < A.Length)
			{	
				end++;
			}
			if (start < A.Length)
			{	
				start++;
			}			
		}
    }
}
	

// Define other methods and classes here