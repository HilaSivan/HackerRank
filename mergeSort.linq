<Query Kind="Program" />

//Merge sort- nlog(n)
void Main()
{
	int[] numbers = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
 
    Console.WriteLine("MergeSort By Recursive Method");
    MergeSort_Recursive(numbers, 0, numbers.Length-1);
    for (int i = 0; i < numbers.Length; i++)
        Console.WriteLine(numbers[i]);
	
}


static public void DoMerge(int [] numbers, int left, int mid, int right)
{
    int [] temp = new int[numbers.Length];
    int i, left_end, num_elements, tmp_pos;

    left_end = (mid - 1);
    tmp_pos = left;
    num_elements = (right - left + 1);

    while ((left <= left_end) && (mid <= right))
    {
        if (numbers[left] <= numbers[mid])
            temp[tmp_pos++] = numbers[left++];
        else
            temp[tmp_pos++] = numbers[mid++];
    }

    while (left <= left_end)
        temp[tmp_pos++] = numbers[left++];

    while (mid <= right)
        temp[tmp_pos++] = numbers[mid++];

    for (i = 0; i < num_elements; i++)
    {
        numbers[right] = temp[right];
        right--;
    }
}

static public void MergeSort_Recursive(int [] numbers, int left, int right)
{
  int mid;

  if (right > left)
  {
	    mid = (right + left) / 2;
	    MergeSort_Recursive(numbers, left, mid);
	    MergeSort_Recursive(numbers, (mid + 1), right);

    	DoMerge(numbers, left, (mid+1), right);
  }
}        
 
     

