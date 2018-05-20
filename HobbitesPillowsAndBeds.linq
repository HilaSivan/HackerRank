<Query Kind="Program" />

/*
 hobbits are planning to spend the night at Frodo's house. Frodo has n beds standing in a row and m pillows (n ≤ m). Each hobbit needs a bed and at least one pillow to sleep, however, everyone wants as many pillows as possible. Of course, it's not always possible to share pillows equally, but any hobbit gets hurt if he has at least two pillows less than some of his neighbors have.
Frodo will sleep on the k-th bed in the row. What is the maximum number of pillows he can have so that every hobbit has at least one pillow, every pillow is given to some hobbit and no one is hurt?
Input:
The only line contain three integers n, m and k (1 ≤ n ≤ m ≤ 109, 1 ≤ k ≤ n) — the number of hobbits, the number of pillows and the number of Frodo's bed.
Output:
Print single integer — the maximum number of pillows Frodo can have so that no one is hurt.

Examples-
input
4 6 2
output
2

input-
3 10 3
output-
4

input
3 6 1
output
3

*/
void Main()
{
	Console.WriteLine(HowManyPillows(7,21,6));
}

public static int HowManyPillows(int beds, int pillows, int indexBed)
{
	if (indexBed == 1 || indexBed == beds)
	{
		double left = ((double)pillows % (double)beds) / (double)beds;
		//Console.WriteLine("{0:0.0}", left);
		if (left <0.5)
			return (pillows /beds) +1;			
		return 	(pillows /beds) +2;	
	}
	if (pillows % beds != 0 )
	{
		return (pillows /beds) +2;	
	}

	return (pillows /beds) +1;		
}