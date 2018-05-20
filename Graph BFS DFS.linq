<Query Kind="Program" />

/*
	BFS- Worst-case performance	O(|V|+|E|)=O(b^{d})
	Worst-case space complexity	O(|V|)=O(b^{d})
	The shortest way
	The breadth-first search has an interesting property:
	It first finds all the vertices that are one edge away from the starting point,
	then all the vertices that are two edges away, and so on. 
	This is useful if you’re trying to find the shortest path from the starting 
	vertex to a given vertex. You start a BFS, and when you find the specified vertex, 
	you know the path you’ve traced so far is the shortest path to the node. 
	If there were a shorter path, the BFS would have found it already.

	Breadth-first search can used for finding the neighbour nodes 
	in peer to peer networks like BitTorrent, GPS systems to find nearby locations,
	social networking sites to find people in the specified distance and things like that.

	DFS-
	Depth-first searches are often used in simulations of games 
	(and game-like situations in the real world).
	In a typical game you can choose one of several possible actions.
	Each choice leads to further choices, each of which leads to further choices,
	and so on into an ever-expanding tree-shaped graph of possibilities

*/

/*
Breadth-first search is unique with respect to depth-first search in that you can use breadth-first
search to find the shortest path between 2 vertices. This assumes an unweighted graph.
The shortest path in this case is defined as the path with the minimum number of edges between the two vertices.
In these cases it might be useful to calculate the shortest path to all vertices in the graph from
the starting vertex, and provide a function that allows the client application to query for the shortest 
path to any other vertex. I've created a ShortestPathFunction in C# that does just this. 
It caculates the shortest path to all vertices from a starting vertex and then returns a function that
allows one to query for the shortest path to any vertex from the original starting vertex.
Breadth-first search is being used to traverse the graph from the starting vertex and storing 
how it got to each node ( the previous node ) into a C# Dictionary, called previous.
To find the shortest path to a node, the code looks up the previous node of the destination
node and continues looking at all previous nodes until it arrives at the starting node.
since this will be the path in reverse, the code simply reverses the list and returns it.

*/

void Main()
{
	Graph G= new Graph();
	G.AddEdge(1,3);
	G.AddEdge(1,2);
	G.AddEdge(3,4);
	G.AddEdge(4,5);
	G.AddEdge(2,6);
	G.AddEdge(4,7);
	G.AddEdge(6,8);
	G.AddEdge(2,9);
	G.AddEdge(3,10);
	Node root = G.GetNode(1);
	
	var shortestPath = G.ShortestPathFunction(G, 1);
	  var vertices = new[] {1, 2, 3, 4, 5, 6};
	foreach (var vertex in vertices)
                Console.WriteLine("shortest path to {0,2}: {1}",
                        vertex, string.Join(", ", shortestPath(vertex)));
						
					
	Console.WriteLine(G.FindAncestor(G,10,12));
}


public class Node
{
	public int Data { get; set; }
    public List<Node> Children { get; set; } = new  List<Node>();
   		
    public Node(int data)
    {
        this.Data = data;		
    }
}
	
public class Graph
{	
	private Dictionary<int, Node> nodeLookup =  new Dictionary<int, Node> ();
	
	public Node GetNode(int id)
	{
		if (!nodeLookup.ContainsKey(id))
		{
			Node n= new Node(id);
			nodeLookup.Add(id, n);
		}
		return nodeLookup[id];;	
	}

	public void AddEdge(int source, int destination)
	{
		Node s = GetNode(source);	
		Node d = GetNode(destination);
		s.Children.Add(d);
	}
	
		
	public bool HasPathDFS(int source, int destination)
	{
		Node s = GetNode(source);
		Node d = GetNode(destination);
		Dictionary<int, bool> visited =  new Dictionary<int, bool> ();
		return HasPathDFS(s,d,visited);
	}
	
	public bool HasPathDFS(Node source, Node destination,Dictionary<int, bool> visited)
	{
		if (visited.ContainsKey(source.Data))
		{
			return false;
		}		
		visited.Add(source.Data, true);		
		if (source == destination)
		{
			return true;
		}		
		foreach (Node child in source.Children)
		{
			if (HasPathDFS(child, destination, visited))
			{
				return true;
			}
		}		
		return false;		
	}
	
	public bool HasPathBFS(int source, int destination)
	{
		Node s = GetNode(source);
		Node d = GetNode(destination);
		Dictionary<int, bool> visited =  new Dictionary<int, bool> ();
		return HasPathBFS(s,d,visited);
	}
	
	private bool HasPathBFS(Node source, Node destination,Dictionary<int, bool> visited)
	{		
		Queue<Node> nextToVisit = new Queue<Node>();
		
		nextToVisit.Enqueue(source);
		while (nextToVisit.Count > 0)
		{
			Node node = nextToVisit.Dequeue();
			if (node == destination)
			{
				return true;
			}
			if (visited.ContainsKey(node.Data))
			{
				continue;
			}
			visited.Add(node.Data, true);
			
			foreach (Node child in node.Children)
			{
				nextToVisit.Enqueue(child);
			}		
		}
		return false;		
	}
	
	public int CalculateDistance(int source, int destination)
	{
		Node s = GetNode(source);
		Node d = GetNode(destination);
		Dictionary<int, bool> visited =  new Dictionary<int, bool> ();
		int distance = 0;
		return CalcBFS(s,d,visited,distance);
	}
	
	private int CalcBFS(Node source, Node destination,Dictionary<int, bool> visited, int distance)
	{		
		Queue<Node> nextToVisit = new Queue<Node>();
		
		nextToVisit.Enqueue(source);
		while (nextToVisit.Count > 0)
		{
			Node node = nextToVisit.Dequeue();
			Console.WriteLine(node.Data);
			
			if (node == destination)
			{				
				return distance;
			}
			if (visited.ContainsKey(node.Data))
			{
				distance -=6; //Th distance of each edge is 6km(in this specific question)
				continue;
			}
			visited.Add(node.Data, true);
			
			if (!HasPathBFS(node.Data, destination.Data))
			{
				continue;
			}
			distance +=6;
			
			foreach (Node child in node.Children)
			{
				nextToVisit.Enqueue(child);
			}		
		}
		return -1;		
	}
	
	public Func<int, List<int>> ShortestPathFunction(Graph graph, int start) 
	{
	    var previous = new Dictionary<int, int>();
	        
	    var queue = new Queue<int>();
	    queue.Enqueue(start);
	
	    while (queue.Count > 0) 
		{
	        var vertex = queue.Dequeue();
	        foreach(var neighbor in graph.GetNode(vertex).Children)
			{
	            if (previous.ContainsKey(neighbor.Data))
	                continue;
	            
	            previous[neighbor.Data] = vertex;
	            queue.Enqueue(neighbor.Data);
	        }
	    }
	
	    Func<int, List<int>> shortestPath = v => 
		{
	        var path = new List<int>{};
	
	        var current = v;
	        while (!current.Equals(start)) 
			{
	            path.Add(current);
	            current = previous[current];
	        };
	
	        path.Add(start);
	        path.Reverse();
	
	        return path;
	    };
	
	    return shortestPath;
	}
	
	/*
 * Find the lowest common ancestor in an unordered binary tree given two values in the tree.
 * There are no duplicate values.
 */
 	private void PrintPath(List<int> path)
	{
		foreach(var d in path)
		{
			Console.Write($" {d} ");
		}
	}
	
	public int FindAncestor(Graph G, int id1, int id2)
	{
		if (!nodeLookup.ContainsKey(id1) || !nodeLookup.ContainsKey(id2) )
		{
			return -1;
		}
	
		var shortestPath = G.ShortestPathFunction(G, 1);
		List<int> path1 = shortestPath(id1);
		List<int> path2 = shortestPath(id2);
		int len1 = path1.Count();
		int len2 = path2.Count();
		
		int lengthShort = len1 <len2? len1 : len2;
		int i=0;
	
		while (i < lengthShort)
		{
			if (path1[i] != path2[i])
			{
				break;
			}
			i++;
		}
		
		return path1[i-1];
	}
 
}

   