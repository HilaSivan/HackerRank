<Query Kind="Program" />

void Main()
{
	int[] a= {1,2,3,4,5};
	int n = a.Length;
	int k= 4;
	
	RotateLeftQuicker(a, n, k);
        foreach(var num in a)
           Console.Write($"{num} ");
}


//O(n*k)
public static void RotateLeft(int[] a, int n, int k)  
{
    for (int j=0; j< k; j++)
    {
        int temp = a[0];
        for (int i =n-1 ; i>=0; i-- )    
        { 
            int current = a[i];           
            a[i] = temp; 
            temp = current;
        }
    }
}

//O(n) complaxity O(n)memory
public static void RotateLeftQuicker(int[] a, int n, int k)  
{
   List<int> b = new List<int>();
	
	for (int i=0; i < n; i++)
	{
		int index = k + i;	
		if (index > (n-1))
		{
			index = index % n;
		}
		
		b.Add(a[index]);
	}
		
	Array.Copy(b.ToArray(),a,n);
}



// Define other methods and classes here
