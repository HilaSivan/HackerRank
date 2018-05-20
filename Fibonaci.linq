<Query Kind="Program" />

//	Write a program which stores the results of the numbers in a Fibonancci sequence in an array 

void Main()
{
	Fibonacci_Iterative(20);
	Console.WriteLine();
	Fibonacci_Recursive(20);
	Console.WriteLine();
	Console.WriteLine($"{GetNthFibonacci_Ite(8)}");
}


public static void Fibonacci_Iterative(int len)
{
    int a = 0, b = 1, c = 0;
    Console.Write("{0} {1}", a,b);

    for (int i = 2; i < len; i++)
    {
        c= a + b;
        Console.Write(" {0}", c);
        a= b;
        b= c;
    }
}

public static void Fibonacci_Recursive(int len)
{
   Fibonacci_Rec_Temp(0, 1, 1, len);
}

private static void Fibonacci_Rec_Temp(int a, int b, int counter, int len)
{
    if (counter <= len)
    {
        Console.Write("{0} ", a);
       Fibonacci_Rec_Temp(b, a + b, counter+1, len);
    }
}

public static int GetNthFibonacci_Ite(int n)
{
    int number = n - 1; //Need to decrement by 1 since we are starting from 0
    int[] Fib = new int[number + 1];
    Fib[0]= 0;
    Fib[1]= 1;

    for (int i = 2; i <= number;i++)
    {
       Fib[i] = Fib[i - 2] + Fib[i - 1];
    }
    return Fib[number];
}
// Define other methods and classes here
