<Query Kind="Program" />

void Main()
{
	int[]A = {4,2,-1,1,-5,6,-4};
	int T = 0;
	Array.Sort(A); //O(nlog(N)) in averege. worst case- O(N^2)
	
	   for (int i = 0; i < A.Length; i++)
                Console.WriteLine(A[i]);
 	Console.WriteLine(Sum2(A,T));
}  

//	O(N)
public static bool Sum2(int[] A, int T) 
{
    int start = 0;
    int end = A.Length - 1;
 	int sum;
     while( start < A.Length && end > 0 && start< end )
    {
		sum = A[start] + A[end];
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
			Console.WriteLine($"{A[start]} + {A[end]} = {T}");
            return true;         
			
		}
    }

    return false;
}
	

// Define other methods and classes here
