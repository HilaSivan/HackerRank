<Query Kind="Program" />

//Write a function that given a string, returns all nearby words.

void Main()
{
	 // Console.WriteLine(NearbyWords("gi"));
	  Console.WriteLine(NearbyWords(""));
	  
}

static List<String> NearbyWords(String input) 
{
    char[] letters = input.ToCharArray();
    List<String> nearbyPermutations = NearbyPermutations(letters, 0);
    List<String> words = new List<string>();
    foreach (String pw in nearbyPermutations) 
	{
        if (IsWord(pw)) {
            words.Add(pw);
        }
    }
    return words;
}

private static List<String> NearbyPermutations(char[] letters, int index)
{
    if (index >= letters.Length) 
	{
        List<String> strings = new List<String>();
        strings.Add("");
        return strings;
    }

    List<String> subWords = NearbyPermutations(letters, index + 1);
    List<Char> nearbyLetters = GetNearbyChars(letters[index]);
	
    return Permutations(subWords, nearbyLetters);
}

private static List<string> Permutations(List<String> subWords, List<Char> nearbyLetters) 
{
    List<string> permutations = new List<string> ();

    foreach (String subWord in subWords) 
	{
        foreach (Char letter in nearbyLetters)
		{
            permutations.Add(letter + subWord);
        }
    }
    return permutations;
}

private static bool IsWord(String word)
{
    return word.Equals("go") || word.Equals("hi");
}


 private static List<Char> GetNearbyChars(Char character)
 {
    List<Char> characters = new  List<Char>();
    if (character == 'g')
	{
        characters.Add('g');
        characters.Add('h');
        characters.Add('f');
    } 
	else 
	{
        characters.Add('i');
        characters.Add('o');
        characters.Add('k');
    }
    return characters;
}

