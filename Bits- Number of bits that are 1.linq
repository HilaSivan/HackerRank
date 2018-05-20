<Query Kind="Program" />

void Main()
{
	long a= 11;
	Console.WriteLine(numSetBits(a));
}

public static int numSetBits(long a) 
{
    int count = 0;
    for (int i= 0; i< 32; i++)
    {
        long num = (a>>i)&1;
		//Console.WriteLine(a>>1);
        if (num == 1)
        {
            count++;
        }
    }
    return count;
}
