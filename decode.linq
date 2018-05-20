<Query Kind="Program" />

/*
A top secret message containing letters from A-Z is being encoded to numbers using the following mapping:
You are an FBI agent. You have to determine the total number of ways that message can be decoded.

Example :
Given encoded message "123",  it could be decoded as "ABC" (1 2 3) or "LC" (12 3) or "AW"(1 23).
So total ways are 3.

Input:
First line contains the test cases T.  1<=T<=500
Each test case have two lines
First is length of string N.  1<=N<=40
Second line is string S of digits from '0' to '9' of N length.


*/
void Main()
{
	Solution s = new Solution();
	Console.WriteLine(s.numDecodings("2563"));
}

public class Solution 
{
    Dictionary<String, int> mmap = new Dictionary<String, int>();
   
    
    public Solution()
    {
      mmap.Add("0",0);
      mmap.Add("10",1);
      mmap.Add("20",1);
    }
    
    
    
    public int numDecodings(String s) {
        
        if(mmap.ContainsKey(s))
		{
			int decode;
            mmap.TryGetValue(s,  out decode);
			return decode;
		}
        
        if(s.Count()==0)
        	return 0;
        
        int fch=s[0]-'0';
        
        if(fch==0)
        return 0;
       
        if(s.Length==1)
            return 1;
            
        int result=0;
        
        if(fch==1 || (fch==2 && (s[1]-'0')<7))
        {
            if(s.Length==2)
            {
                result=2;
            }
            else 
            result=numDecodings(s.Substring(1))+numDecodings(s.Substring(2));
        }
        else
            result=numDecodings(s.Substring(1));
        
        if(!mmap.ContainsKey(s))
            mmap.Add(s,result);
        
        return result;
            
    }
}