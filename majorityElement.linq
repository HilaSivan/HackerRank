<Query Kind="Program" />

/*Given an array of size n, find the majority element. The majority element is the element that appears more than floor(n/2) times.

You may assume that the array is non-empty and the majority element always exist in the array.

Example :

Input : [2, 1, 2]
Return  : 2 which occurs 2 times which is greater than 3/2. 
*/
void Main()
{
	
}

 public static int majorityElement(List<int> A) 
 {
    int majorityElement = A.Count()/2;
    Dictionary<int, int> dic = new Dictionary<int,int>();
    
    for (int i=0; i< A.Count(); i++)
    {
        if (!dic.ContainsKey(A[i]))
        {
            dic.Add(A[i],0);
        }
        dic[A[i]]++;
    }
    
    foreach (var item in dic)
    {
        if (item.Value > majorityElement)
        {
            return item.Key;
        }
        
    }
    return -1;
}