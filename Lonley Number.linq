<Query Kind="Program" />

//Find the lonely number
//Gven an array and in the array each elemnets apears number time except of 1 element.
//return this 1 element
void Main()
{
	int[] a= {5,5,4,8,4,5,8,9,4,8};
	int number = 3;
	
	Console.WriteLine(BetterFindLonley(a, number));
}

//Time comple complexity is O(n), space complexity is O(1)
public static int FindLonley(int[] a, int number)
{
	int n = a.Count(); //the size of the array
	int[] bitSum = new int[32];
	int bitMask =1;
	for (int i=0; i< n; i++)
	{
		bitMask = 1;
		for (int j=0; j<32; j++)
		{
			int bit = a[i] & bitMask;
			if(bit != 0) 
			{
               bitSum[j] += 1;
            }
			bitMask = bitMask << 1;
		}	
	}	
	
	int result = 0;
	bitMask = 1; 
	for (int j=0; j<32; j++)
	{		
		if (bitSum[j] % number != 0)
		{
			result = result | bitMask;
		}
		bitMask = bitMask << 1;
	}
	return result;
}



public static int BetterFindLonley(int[] a, int number)
{
	int n = a.Count(); //the size of the array
	int[] bitSum = new int[32];
	int bitMask =1;
	int result = 0;
	
	for (int i=0; i<32; i++)
	{
		int sum = 0;
		bitMask =1 <<i;
		for (int j=0; j< n; j++) //ask about the i-th bit of each number
		{
			sum += a[j] & bitMask;
		}
		if (sum % number !=0)
		{
			result = result | bitMask;
		}
	}	
	
	return result;
}