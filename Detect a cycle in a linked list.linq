<Query Kind="Program" />


void Main()
{
	LinkedList.Node head = new LinkedList.Node(1);
    LinkedList ll = new LinkedList(head);

    LinkedList.Node node2 = new LinkedList.Node(2);
    LinkedList.Node node3 = new LinkedList.Node(3);
    LinkedList.Node node4 = new LinkedList.Node(4);
    LinkedList.Node node5 = new LinkedList.Node(5);
   // LinkedList.Node node6 = new LinkedList.Node(6);

    head.NextNode = node2;
    node2.NextNode = node3;
    node3.NextNode = node4;
    node4.NextNode = node5;
    node5.NextNode = node2;
   // node6.NextNode = node2;

    Console.WriteLine(ll.hasLoop());
   
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



    public Boolean hasLoop()
    {
	 	 if (Head == null || Head.NextNode == null)
        {
            return false;  
        }
			
        Node jump1 = Head;
		
        Node jump2 = Head.NextNode;
        while(jump1!=null && jump2!=null)
		{
            if(jump1.Equals(jump2))
			{
                return true;
            }

            if ((jump2.NextNode != null) && (jump1.NextNode != null))
            {
                jump2 = jump2.NextNode.NextNode;
                jump1 = jump1.NextNode;
            }
            else
            {
                return false;
            }
        }

        return false;
    }
}