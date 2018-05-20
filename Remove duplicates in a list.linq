<Query Kind="Program" />

/*
	Given a sorted linked list, delete all duplicates such that each element appear only once.

For example,
Given 1->1->2, return 1->2.
Given 1->1->2->3->3, return 1->2->3.


*/
void Main()
{
	LinkedList.Node head = new LinkedList.Node(1);
    LinkedList ll = new LinkedList(head);

    LinkedList.Node node2 = new LinkedList.Node(1);
    LinkedList.Node node3 = new LinkedList.Node(1);
    LinkedList.Node node4 = new LinkedList.Node(2);
    LinkedList.Node node5 = new LinkedList.Node(2);
   // LinkedList.Node node6 = new LinkedList.Node(6);

    head.NextNode = node2;
    node2.NextNode = node3;
    node3.NextNode = node4;
    node4.NextNode = node5;
    node5.NextNode = null;
   // node6.NextNode = node2;
	var h = ll.RemoveDuplicate(head);
    ll.PrintLinkedlist(h);
   
}

public class LinkedList
{
    public Node Head;

    public class Node
    {
        public int value;
        public Node NextNode;

        public Node(int value)
        {
            this.value = value;
        }
    }

    public LinkedList(Node head)
    {
        this.Head = head;
    }

	public void PrintLinkedlist(Node root)
	{
		while(root!=null)
		{
			Console.WriteLine(root.value);
			root= root.NextNode;
		}		
	}

    public Node RemoveDuplicate(Node head)
    {
	 	if (head == null || head.NextNode == null)
        {
            return head;  
        }
			
        Node current = head;
		
        Node next = current.NextNode;
        while(current!=null && next!=null)
		{
            while (current!=null && next!=null && current.value == next.value)
			{
                current.NextNode = next.NextNode;
				next = current.NextNode;
            }
			
			current = current.NextNode;
			if (current!= null)
            	next = current.NextNode;
        }

        return head;
    }
}