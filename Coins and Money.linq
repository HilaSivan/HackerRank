<Query Kind="Program" />

/*
Dynamic Programming - Coin Change 
Integer partition - Number of ways of representing an integer as addtion od positive integer
O(n) space and O(m*n) time
*/
void Main() 
{
	int[] coins = {1,2, 3};
	int money = 3;
	/*
		1111
		112
		22
		13	
	*/
	Console.WriteLine(IntegerPartition(coins, money));

}

public static long IntegerPartition(int[] coins, int money) 
{
    long[] DP = new long[money + 1]; // O(N) space.
    DP[0] = (long)1;	
	
    for(int i = 0 ; i < coins.Length; i++) 
	{
        int coin = coins[i];
        for(int j = coin; j < DP.Length; j++) 
		{
        /*
			This line calculates the number of ways to get j amount of money by using coins. 
			The number is calculated by adding number of ways it can be done without using coin "coin" plus the number of ways it can be done with the coin "coin".
			The number of ways to get j without using "coin" is DP[j] which was already calculated while looping through other coins.
			The other way to get j is to add "coin" to j-coin.
			So, it's just a matter of finding how many ways there are to get j-coin. 
			It is actually DP[j-coin] that was already calculated while looping through smaller j values.
		*/
            DP[j] += DP[j - coin];
        }
    }       
    return DP[money]; //with the option of zero+the number itself
	//return DP[money]; //without the option of zero+the number itself
 }