<Query Kind="Program" />

/*1.	Given a pointer to the head of a singly linked list, 
iterate it backwards printing the values in reverse. 
Give 2 implementations - a recursive one, and an iterative one.  
Given a singly linked list: 1->2->3->4->5 Change it to 5->4->3->2->1 
O(n)
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
	SingleLinkedList reverse = listOperations.Reversed(root);
		Console.WriteLine("reversed list is ->");
	listOperations.printLinkedlist(reverse);	
	
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
	
	public SingleLinkedList Reversed(SingleLinkedList root)
	{	
		SingleLinkedList current = root.getNext();	
		SingleLinkedList prev = root;	
		SingleLinkedList temp = null;
		while (current.getNext() != null)
		{			
			temp = current.getNext();	
			current.setNext(prev);
			prev = current;
			current= temp;				
		}
	
		current.setNext(prev);		
		root.setNext(null);
	
		return current;
	}

}