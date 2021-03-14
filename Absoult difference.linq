<Query Kind="Program" />

/*
Given an array of integers, 
find out whether there are two distinct indices i and j in the array such
that the absolute difference between nums[i] and nums[j] 
is at most t and the absolute difference between i and j is at most k.


*/

void Main()
{
	int[] nums = {1,5,9,1,5,9};

	int k = 2;
	int t = 3;
	
	Console.WriteLine(	ContainsNearbyAlmostDuplicate (nums, k,t));
}

public int insertSorted(int[] arr, int startPos ,int n, int key, int capacity)
{
    // Cannot insert more elements if n is already
    // more than or equal to capcity
    if (n >= capacity)
        return n;
 
    int i;
    for (i = n - 1; (i >= startPos && arr[i] > key); i--)
        arr[i + 1] = arr[i];
 
    arr[i + 1] = key;
 
    return (n + 1);
}

 

 public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
         int[] tempArray = new int[2*k];
	         
        for (int i=0; i< nums.Length ; i++)
        {
			long firstNumber = nums[i];
			Console.WriteLine(firstNumber);
			if (i ==0)
			{
				int index = 0;
	            for (var j = i+1; j <= i + k && j< nums.Length; j++)
	            {
					insertSorted(tempArray, 0, index, nums[j],k);	            
					index++;
	            }           
	            		
			}
			else
			{
				 if (i+k < nums.Length)
				 {
					int sizeOfTempArray = tempArray.Count();
					var n = insertSorted(tempArray, i,sizeOfTempArray+1, nums[i+k],2*k);
					Console.WriteLine($"n= {n}");
				}
			}
		
			Console.WriteLine(tempArray);
            for (var j = i; j < tempArray.Count() ; j++)
            {
				long secondNumber = tempArray[j];			
			
				long result = firstNumber -secondNumber;
				Console.WriteLine(result);
				result = Math.Abs((long) result);
				
				if (Math.Abs(result) <=t)
				{				
              		return true;				
				}	
				if (result < t)
				{
					break;
				}
            }
        }
        
        return false;
    }

// Define other methods, classes and namespaces here
