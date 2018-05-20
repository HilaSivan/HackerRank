<Query Kind="Program" />

void Main()
{
	string expression = "[([{{}}]{[[][][([[]]){[]}{}]]}[]{{}}{})[[]]]{{}}(()[[[[[(){}[]]({}{[]})[][[][]]]]{}]{[{}]{[{[][](()({{()}}){([]({({{[]}([([()]{()[[([({{{[]{(){}}[][]({{[([])()](())([{[]([()]";
	Console.WriteLine(expression.Length);
    if (IsBalancedBrackets(expression))
       Console.WriteLine("YES");
    else
        Console.WriteLine("NO");
}

public static bool IsBalancedBrackets(string expression)
{
    Stack<char> stack = new Stack<char>();
    
    if (string.IsNullOrEmpty(expression) || !IsOpen(expression[0]) || expression.Length ==1 || IsOpen(expression[expression.Length-1]) || expression.Length>1000)
    {
        return false;   
        
    }
    for(int i=0; i < expression.Length; i++) 
    {       
        if(IsOpen(expression[i]))
        {
            stack.Push(expression[i]);
        }
        else
        {
            if(stack.Count> 0 && stack.Peek() == Opposite(expression[i]))
                stack.Pop();
            else
                return false;	
        }
    }
    return stack.Count == 0;
}


public static bool IsOpen(char c)
{
	if (c == '{' || c=='[' || c=='(')
	{
		return true;
	}
	return false;	
}
public static char Opposite(char c)
{
    if (c=='}')   
    {
        return '{';
    }
    if (c==']')   
    {
        return '[';
    }
    if (c==')')   
    {
       return '(';
    }
    return '0';
}