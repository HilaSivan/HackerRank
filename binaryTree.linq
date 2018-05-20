<Query Kind="Program" />

void Main()
{
	BinaryTree bt = new BinaryTree();
	Node root = new Node (6);
	bt.InsertIntoBST(root, 4);
	bt.InsertIntoBST(root, 8);
	bt.InsertIntoBST(root, 3);
	bt.InsertIntoBST(root, 5);
	bt.InsertIntoBST(root, 7);	
	bt.InsertIntoBST(root, 9);
	Console.WriteLine(bt.GetHeight(root)); 
	Console.WriteLine(bt.GetNumberOfNodes(root));	
	Console.WriteLine(bt.IsExist(root, 5));
	Console.WriteLine(bt.PreOrderString(root));
	Console.WriteLine(bt.InOrderString(root));
	Console.WriteLine(bt.PostOrderString(root));
	bt.PrintLevelOrder(root);// O(n^2)
	Console.WriteLine();
	bt.PrintByLevelOrder(root); // O(n) 	
	
	Console.WriteLine(bt.CheckBST(root));
}

public class Node
{
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Data { get; set; }
    public Node(int data)
    {
        this.Data = data;
    }
}
     


class BinaryTree 
{
	
	public void InsertIntoBST(Node root, int data)
    {
        Node _newNode = new Node(data);
        Node _current = root;
        Node _previous = _current;
        while (_current != null)
        {
            if (data < _current.Data)
            {
                _previous = _current;
                _current = _current.Left;
            }
            else if (data > _current.Data)
            {
                _previous = _current;
                _current = _current.Right;
            }
        }
        if (data < _previous.Data)
            _previous.Left = _newNode;
        else
            _previous.Right = _newNode;
    }

 

  public int GetHeight(Node node)  
  {  
    if(node == null) {
      // traversed off the end of a leaf,
      // so nothing here to add
      return 0;
    }

    // count this node (the 1) plus whatever comes from
    // recursively traversing left and right
    int leftDepth = 1 + GetHeight(node.Left);  
    int rightDepth = 1 + GetHeight(node.Right);

    // the side (left or right) with highest value is deepest
    return Math.Max(leftDepth, rightDepth);
  }
  
  public int GetNumberOfNodes(Node node)
  {
  		if (node == null)
		{
			return 0;
		}
		
		return GetNumberOfNodes(node.Left) + GetNumberOfNodes(node.Right) + 1;  
  }
  
  public bool IsExist(Node node, int num)
  {
  	if (node == null)
	{
		return false;	
	}
	if (node.Data == num)
	{
		return true;
	}
  
  	return IsExist(node.Left, num) || IsExist(node.Right, num);
  }
  
  public string PreOrderString(Node node)
  {
  	if (node == null)
	{
		return "";
	}
	
	return node.Data + ","+PreOrderString(node.Left) + PreOrderString(node.Right);
  
  }

  public string InOrderString(Node node)
  {
  	if (node == null)
	{
		return "";
	}
	
	return InOrderString(node.Left) + node.Data + "," + InOrderString(node.Right);
  
  }
  
  public string PostOrderString(Node node)
  {
  	if (node == null)
	{
		return "";
	}
	
	return PostOrderString(node.Left)  + PostOrderString(node.Right) +node.Data +",";
  
  }
  
    public void PrintLevelOrder(Node root) // O(n^2)
	{
	    int h = GetHeight(root);
	   
	    for (int i=1; i<=h; i++)
        {
			PrintGivenLevel(root, i);
		}
	}
	
	public void PrintGivenLevel(Node root ,int level)
    {
        if (root == null)
            return;
        if (level == 1)
            Console.Write(root.Data + " ");
        else if (level > 1)
        {
            PrintGivenLevel(root.Left, level-1);
            PrintGivenLevel(root.Right, level-1);
        }
    }
	
	public void PrintByLevelOrder(Node root) //with Queue
	{	
	    Queue<Node> queue = new Queue<Node>();
		queue.Enqueue(root);
		
		while (queue != null && queue.Count > 0 )
		{
			Node tempNode = queue.Dequeue();           
 			Console.Write(tempNode.Data + " "); 
			if (tempNode.Left != null) 
			{
                queue.Enqueue(tempNode.Left);
            }     
			if (tempNode.Right != null) 
			{
                queue.Enqueue(tempNode.Right);
            } 
		}			
	}
	
	//O(nlogn) + Memory of O(n)
	public bool CheckBST(Node root) 
    {
        string byOrder = InOrderString(root);
        byOrder = byOrder.TrimEnd(',');
        int[] a = byOrder.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
        int i = 0;
        while (i < a.Count() - 1)
        {
            if (a[i] == a[i+1] || a[i] > a[i+1])   
            {
                return false;
            }
            i++;
        }
        return true;
    }
		
}