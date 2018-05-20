<Query Kind="Program" />

/*
Print the resultant string after adding given two binary strings

*/

void Main()
{
	string b1 = "1101";
	string b2 = "111";
	
	Console.WriteLine(SumBinaryStrings(b1, b2));
}

public static string SumBinaryStrings(string b1, string b2)
{	
	if (b1.Length < b2.Length)
	{
		for (int i = 0 ; i <  b2.Length - b1.Length  ; i++)
        {
			b1 = '0' + b1;
		}
	}
	
	if (b2.Length < b1.Length)
	{
		for (int i = 0 ; i <  b1.Length - b2.Length  ; i++)
        {
			b2 = '0' + b2;
		}
	} 
	
	string result=""; 
	int carry = 0;  // Initialize carry
 
    // Add all bits one by one
    for (int i = b1.Length-1 ; i >= 0 ; i--)
    {
        int firstBit = b1[i] - '0';
        int secondBit = b2[i] - '0';
 
        // boolean expression for sum of 3 bits
        int sum = (firstBit ^ secondBit ^ carry)+'0';
 
        result = (char)sum + result;
 
        // boolean expression for 3-bit addition
        carry = (firstBit & secondBit) | (secondBit & carry) | (firstBit & carry);
    }
 
    // if overflow, then add a leading 1
    if (carry == 1)
    {
		result = '1' + result;
	}
	
	return result;
}
