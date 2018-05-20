<Query Kind="Program" />

//Given a list of integers and a target number, list all pairs that sum up to that number

void Main()
{
	int[]A = {4,2,-1,1,-5,6,-4};
	int T = 1;
	Array.Sort(A); //O(nlog(N)) in averege. worst case- O(N^2)
	
 	Sum2(A,T);
}  

//	O(N)
public static void Sum2(int[] A, int T) 
{
    int start = 0;
    int end = A.Length - 1;
 	int sum;
    while( start < A.Length && end > 0 && start < end)
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
         	start++;
			end--;			
		}
    }
}
	