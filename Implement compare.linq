<Query Kind="Program" />

void Main()
{
	
}

class Player{
    String name;
    int score;
    
    Player(String name, int score){
        this.name = name;
        this.score = score;
    }
}


// Write your Checker class here
class Checker: Comparator<Player> 
{
  
    public int compare(Player player1, Player player2)
    {       
        if (player1 == null || player2 == null)
                throw new NullPointerException();
        
        if (player1.score < player2.score)
        {
            return 1;
        }
        if (player2.score < player1.score)
            return -1;
        if (player1.score == player2.score)
        {
            return player1.name.compareTo(player2.name);
        }
        throw new ClassCastException();
    }
    
    
}
// Define other methods and classes here
