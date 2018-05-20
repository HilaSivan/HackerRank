<Query Kind="Program" />

void Main()
{
	//int[]A = {4,2,-1,1,-5,6,-4};
	//int[]A = {0};
	
	//int []A = {4, 3, -1, 2, 5,10};
	int[]A = {-5,1,10};
	int T = 0;
	Array.Sort(A); //O(nlog(N)) in averege. worst case- O(N^2)	
	for (int i = 0; i < A.Length; i++)
        Console.WriteLine(A[i]);
 	Console.WriteLine(Sum3(A,T));
}  

//	O(N)
public static bool Sum2(int[] A, int T, int start) 
{
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
			Console.WriteLine($"{A[start]} + {A[end]} + (-{T})");
            return true;         
			
		}
    }

    return false;
}

public static bool Sum3(int[] A, int T) 
{
	for (int i=0; i< A.Length; i++)
	{
		if (A[i] == 0)
		{
			Console.WriteLine($"0 + 0 + 0 = 0");
			return true;
		}
		int num = -A[i];		
		/*if (Sum2(A, num, i+1))  //with no duplicate numbers
		{
			return true;
		}	*/
		
		if (Sum2(A, num, 0))  //with duplicate numbers
		{
			return true;
		}
	}
	return false;
}