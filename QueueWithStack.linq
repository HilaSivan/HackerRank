<Query Kind="Program" />

/*
Method 2 is definitely better than method 1.
Method 1 moves all the elements twice in enQueue operation, while method 2 (in deQueue operation) moves the elements once and moves elements only if stack2 empty.
Implementation of method 2:

*/

void Main()
{
	QueueStackFast queue = new QueueStackFast();
	/*
		10
1 76
1 33
2
1 23
1 97
1 21
3
3
1 74
3
	
	*/
	queue.Enqueue(76);
	queue.Enqueue(33);
	queue.Dequeue();
	queue.Enqueue(23);
	queue.Enqueue(97);
	queue.Enqueue(21);
	queue.Print();	//33
	queue.Enqueue(74);
	queue.Print();//33
	queue.Dequeue();
	queue.Enqueue(1);
	queue.Print();//23
	queue.Dequeue();
	queue.Print();
}    


/*
	enQueue(q,  x)
  1) Push x to stack1 (assuming size of stacks is unlimited).

deQueue(q)
  1) If both stacks are empty then error.
  2) If stack2 is empty
       While stack1 is not empty, push everything from stack1 to stack2.
  3) Pop the element from stack2 and return it.
*/
public class QueueStackFast
{
	private Stack<long> stack1 = new Stack<long> ();
    private Stack<long> stack2 = new Stack<long> ();
	private long head;
  
    public void Enqueue(long num)
    {       
		if (stack1.Count == 0 && stack2.Count == 0)
		{
			head = num;
		}
        stack1.Push(num);           
    }

    public long Dequeue()
    {		
		long num;
        if (stack1.Count == 0 && stack2.Count ==0)
            throw new Exception("Error");
		if (stack2.Count == 0)
		{
			while(stack1.Count > 0)
			{
				num = stack1.Pop();
				if (stack1.Count ==1)
				{	
					head = num; // the head				
				}
				stack2.Push(num);			
			}
		}
				
		num =stack2.Pop();
		if (stack2.Count == 0)
		{
			head = -1;
		}
		else
		{
			head = stack2.Peek();
		}
		return num;
    }

    public void Print()
    {
		if (head == -1)
      	{			
			long num;
			if (stack1.Count > 0)
			{
				while (stack1.Count > 0)
				{
					num = stack1.Pop();
					stack2.Push(num);
					if (stack1.Count ==0)
					{	
						head = num; // the head				
					}
						
				}
			}
			else
			{
				if (stack2.Count > 0)
				{
					head = stack2.Peek();
				}
			}
		}
		Console.WriteLine($"{head}");	
    }

}
