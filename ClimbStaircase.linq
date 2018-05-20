<Query Kind="Program" />

/*Davis has s staircases in his house and he likes to climb each staircase , {1,2,3} steps at a time.
Being a very precocious child, he wonders how many ways there are to reach the top of the staircase.

Given the respective heights for each of the s staircases in his house, 
find and print the number of ways he can climb each staircase on a new line.

	A(1) = 1
	A(3) = 4, why?
	1+1+1 =3
	1+2 =3
	2+1 =3
	3+0 = 3
	
	Solving this problem is like solving the following recursion:
	A(n) = A(n - 1) + A(n - 2) + A(n - 3)
	A(1)=1; A(2)=2; A(3)=4.
	So:
	A(7) = 44
*/


void Main()
{
	int s=7;
	int max = 36;
	int[] array = new int[max];
	 
	Console.WriteLine(Climb(s, array));
}

//Better performance- O(m) memory space, while m=36, and O(n) run time
public static int Climb(int n, int[] array)
{   
    if (n == 1) {
        return 1;
    }
    else if(n == 2) {
        return 2;
    }
    else if(n == 3) {
        return 4;
    }
    array[0] = 1;
    array[1] = 2;
    array[2] = 4;
    for (int i = 3; i < n; i++) 
	{
        array[i] = array[i-1] + array[i-2] + array[i-3];		
    }
    return array[n-1];
}

//Les Good Performance
public static int ClimbRec(int n, int[] array) 
{
    if(n < 0)
        return 0;

    if(n == 0) 
        return 1;

    if(array[n] == 0) 
	{
        array[n] = ClimbRec(n-1, array) + ClimbRec(n-2,array) + ClimbRec(n-3,array);
    }
    return array[n];
}