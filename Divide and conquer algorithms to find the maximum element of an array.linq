<Query Kind="Program" />

//Divide and conquer algorithms to find the maximum element of an array
void Main()
{
	 int[] numbers = { 3,8, 7, 5, 2, 1, 9, 6, 4 };
            int len = 9;
 
      Console.WriteLine($"{Maxsimum(numbers,0,len-1)}");
 
}
static int Maxsimum(int[] a,int l,int r)
{
	if (l==r) 
	{ 
	 	return a[l]; //trivial case, if there is only one value in the array return it
	}
		
	int m=(l+r)/2; //find value halfway into the array
	int u=Maxsimum(a,l,m); //find the maximum value for the lower part of the array
	int v=Maxsimum(a,m+1,r); //find the maximum value for the top part of the array
	return u>v?u:v; //return the highest value of them.
}
 
   
