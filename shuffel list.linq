<Query Kind="Program" />

//Given a singly linked list: 1->2->3->4->5 Change it to 1->5->2->4->3 using O(1) space
//Answer:
/*
attach the last to the first then 1 -> 2 -> 3-> 4-> 5 becomes 
1->5 -> 2 -> 3-> 4, do the same procedure for the rest of the chain (2-> 3-> 4)

*/
void Main()
{
		SingleLinkedList lastNode = new SingleLinkedList("5", null);
		SingleLinkedList singleLinkedList = new SingleLinkedList("4", lastNode);
		singleLinkedList = new SingleLinkedList("3", singleLinkedList);
		singleLinkedList = new SingleLinkedList("2", singleLinkedList);
		SingleLinkedList root = new SingleLinkedList("1", singleLinkedList);
	
	
		ListOperations listOperations = new ListOperations();
		listOperations.printLinkedlist(root);		
		SingleLinkedList shuffledroot = listOperations.LastWillBeFirst(root, 0);
			Console.WriteLine("Shuffled list is ->");
		listOperations.printLinkedlist(root);
			
		shuffledroot = listOperations.LastWillBeFirst(root, 2); //jump 2
		Console.WriteLine("Shuffled list is ->");
		listOperations.printLinkedlist(shuffledroot);
}


public class SingleLinkedList {
	
	private String value;
	private SingleLinkedList next;
	
	public SingleLinkedList(String value, SingleLinkedList next){
		this.value = value;
		this.next = next;
	}

	public String getValue() {
		return value;
	}

	public void setValue(String value) {
		this.value = value;
	}

	public SingleLinkedList getNext() {
		return next;
	}

	public void setNext(SingleLinkedList next) {
		this.next = next;
	}

}

public class ListOperations {
	
	/* print the single linked list */
	public void printLinkedlist(SingleLinkedList root){
		while(root!=null){
			Console.WriteLine(root.getValue());
			root= root.getNext();
		}
		
	}
	
	public SingleLinkedList LastWillBeFirst(SingleLinkedList root, int jump)
	{	
		SingleLinkedList head = root;
		SingleLinkedList second = root.getNext();
		SingleLinkedList current = root.getNext();
		SingleLinkedList prev = null;
		
		if (jump > 0)
		{
			int index = 0;
			while (index < jump && head.getNext() != null && head.getNext().getNext() != null)
			{
				head= head.getNext();			
				second = head.getNext();
				current = second;
				index ++;				
			}
		}

		while (current.getNext() != null)
		{
			prev = current;
			current = current.getNext();
		}
	
		if (prev != null)
		{
			head.setNext(current);
			prev.setNext(null);		
			current.setNext(second);
		}
		return root;
	}

}

