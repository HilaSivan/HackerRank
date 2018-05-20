<Query Kind="Program" />

/*
Write a basic Regex engine implementing the "." (any character) and "*" (previous rule, 0 to many).
The function receives a string (letters only, no need for escaping) and a string pattern. 
It returns a bool whether the string matches the pattern. 
For example, the pattern "AB.*E" should match both "ABCDE" and "ABEEE
*/


void Main()
{
	string st = "ABCDE";//Length = n
	string pattern = "AB.*E"; //Length = m
	Console.WriteLine($"{CleanPattern("a..c****")}");  //O(m)
	
	Console.WriteLine($"{IsMatch(pattern,st )}"); //O(mn)
}

public static bool IsMatch(string pattern, string st)
{
	pattern = CleanPattern(pattern);
	return IsMatchPattern(pattern,st);
}

private static string CleanPattern(string pattern)
{
	//*********a
	//.*.*.*.*.*a
	int i = 0;	
	string clean = string.Empty;
	while (i < pattern.Length)
	{
		if ( pattern[i] == '*')
		{
			int j = i;
			while ( j < pattern.Length && (pattern[j] == '*' ||  pattern[j] == '.' ))
			{
				j++;
			}
			
			if ( i < j)
			{
				i = j;
			}
			else
			{
				i++;
			}
			clean += '*';
		}
		else
		{
			clean += pattern[i];
			i++;
		}	
	}
	
	return clean;	
}

public static bool IsMatchPattern(string pattern, string st)
{
    // Empty pattern will always return false
    if (string.IsNullOrEmpty(pattern))
    {
        return false;
    }
    else
    {
        if (pattern[0] == '*')
        {
            // Last * matches everything
            if (pattern.Length == 1)
            {
                return true;
            }
            else
            {
                return matchStar(pattern.Substring(1), st);
            }
        }
        // Return false if text is empty but pattern is not *
        else if (string.IsNullOrEmpty(st))
        {
            return false;
        }
        else if (pattern[0] == '.' || pattern[0] == st[0])
        {
            // If the last pattern matches the last text
            if (pattern.Length == 1 && st.Length == 1)
            {
                return true;
            }
            // If hasn't reached the end, try to match the rest strings
            else
            {
                return IsMatchPattern(pattern.Substring(1), st.Substring(1));
            }
        }
        else
        {
            return false; 
        }
    }
}

    // Otherwise skip as many chars as required
private static bool matchStar(string pattern, string st)
{
    for (int i = 0; i < st.Length; i++)
    {
        if (IsMatchPattern(pattern, st.Substring(i)))
        {
            return true;
        }
        else
        {
            continue;
        }
    }

    return false;
}