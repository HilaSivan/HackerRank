<Query Kind="Program" />


//use bit operations to write a function that will determine   if a number is a power of 2 
void Main()
{
	int num = 16;
	
	Console.WriteLine($"{IsPower2B(num)}");
}

// Define other methods and classes here

public static bool IsPower2(int num)
{
	int count = 0;
	while (num > 0)
	{
		  if((num & 1 )== 1)
            count++;
		num = num >> 1;		
	}
	if(count == 1)
        return true;
    else
		return false;
	
}


public static bool IsPower2B(int num)
{
	return num > 0 && ( num & (num -1)) == 0 ? true: false;
}
