<Query Kind="Program" />

/*GCD - Given 2 non negative integers m and n, find gcd(m, n)

GCD of 2 integers m and n is defined as the greatest integer g such that g is a divisor of both m and n.
Both m and n fit in a 32 bit signed integer.
*/
void Main()
{
	int m= 2;
	int n = 3;
	
	Console.WriteLine(GCD(m,n));
}

public static int GCD(int m, int n)
{
	if (m ==0 )
		return n;
	if (n ==0 )
		return m;
	if (m==n)
	{
		return n;
	}
	if (m > n)
	{
		return FindGcd(n,m, n);
	}
	return FindGcd(m, n, m);
}


public static int FindGcd(int small, int big, int gcd)
{	
	//Console.WriteLine($"small- {small}, big- {big}, gcd- {gcd}");
	if (big % gcd  == 0)
	{
		return gcd;
	}
	
	while (gcd > 1)
	{
		gcd = gcd -1;
		if (small % gcd == 0)
			break;
	}
	return FindGcd(small, big, gcd);
	
}