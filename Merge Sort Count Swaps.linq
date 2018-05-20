<Query Kind="Program" />

//Merge sort- nlog(n)
void Main()
{
	//int[] numbers = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
 	//int[] numbers = {2, 4, 1};
 	int[] numbers = new int[]{6, 2, 1, 4, 5, 3};
	//int[] numbers = new int[]{1, 1, 1, 2, 2};
	//int[] numbers = {2, 1, 3,1,2};
	
   // Console.WriteLine("MergeSort By Recursive Method");
	IntWrapper numOfSwaps = new  IntWrapper();
    MergeSort.MergeSort_Recursive(numbers, 0, numbers.Length-1, numOfSwaps);
    /*
	for (int i = 0; i < numbers.Length; i++)
        Console.Write($"{numbers[i]} ");

	Console.WriteLine($"numOfSwaps- {numOfSwaps.Val}");	
	*/
}

public class IntWrapper{
   public long Val {set; get;} = 0;   
}

public class MergeSort
{

    static public void DoMerge(int [] numbers, int left, int mid, int right,  IntWrapper numOfSwaps)
    {
        int [] temp = new int[numbers.Length];
        int i, left_end, num_elements, tmp_pos;

        left_end = (mid - 1);
        tmp_pos = left;
        num_elements = (right - left + 1);

        while ((left <= left_end) && (mid <= right))
        {				
            if (numbers[left] <= numbers[mid])
            {					
                temp[tmp_pos++] = numbers[left++];				
            }
            else
            {	
				//Console.WriteLine($"switch:{tmp_pos} and {mid}: {numbers[left]} and {numbers[mid]}");
                	
                temp[tmp_pos++] = numbers[mid++];
				numOfSwaps.Val += left_end+1 - left;		
            }	
        }
		   	
        while (left <= left_end)
        {
            temp[tmp_pos++] = numbers[left++];
        }
        while (mid <= right)
        {		
            temp[tmp_pos++] = numbers[mid++];
        }

        for (i = 0; i < num_elements; i++)
        {
            numbers[right] = temp[right];
            right--;
        }
    }

    static public void MergeSort_Recursive(int [] numbers, int left, int right, IntWrapper numOfSwaps)
    {
		int mid;
		
		if (right > left)
		{
		    mid = (right + left) / 2;
		    MergeSort_Recursive(numbers, left, mid, numOfSwaps);
		    MergeSort_Recursive(numbers, (mid + 1), right, numOfSwaps);
		
		    DoMerge(numbers, left, (mid+1), right, numOfSwaps);
		}
    }
}