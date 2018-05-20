<Query Kind="Program" />

/*Dijkstra's algorithm is an algorithm for finding the shortest paths between nodes in a graph, which may represent, for example, road networks.

Dijkstra's shortest path algorithm is O(ElogV) where:
V is the number of vertices
E is the total number of edges

Each vertex can be connected to (V-1) vertices, hence the number of adjacent edges to each vertex is V - 1. 
Let us say N represents V-1 edges connected to each vertex.
Finding & Updating each adjacent vertex's weight in min heap is O(log(V)) + O(1) or O(log(V)).
Hence from step1 and step2 above, the time complexity for updating all adjacent vertices of a vertex is N*(logV). or E*logV.
Hence time complexity for all V vertices is O(V * (N*logV)) .
But- E = O(V*N) =>  Meaning => N = O(E/V)  => and then w'll get: O(ElogV).

*/
void Main()
{
   //A connected to B
	//B connected to A, C , D
	//C connected to B, D
	//D connected to B, C , E
	//E connected to D.
   List<Node> graph = new List<Node>() {
        new Node {name = "A", distanceDict = new Dictionary<string,List<string>>(){
            {"B",new List<string>(){"B"}}}, 
            visited = false},
        new Node {name = "B", distanceDict = new Dictionary<string,List<string>>(){
            {"A",new List<string>(){"A"}}, {"C",new List<string>(){"C"}}, {"D",new List<string>(){"D"}}},
            visited = false},
        new Node {name = "C", distanceDict = new Dictionary<string,List<string>>(){
            {"B",new List<string>(){"B"}}, {"D",new List<string>(){"D"}}},
            visited = false},
        new Node {name = "D", distanceDict = new Dictionary<string,List<string>>(){
            {"B",new List<string>(){"B"}}, {"C",new List<string>(){"C"}}, {"E",new List<string>(){"E"}}},
            visited = false},
        new Node {name = "E", distanceDict = new Dictionary<string,List<string>>(){
            {"D",new List<string>(){"D"}}},
            visited = false}
    };
	
	 //initialize neighbors using predefined dixtionary
    foreach (Node node in graph)
    {
        node.neighbors = new List<Neighbor>();
        foreach (KeyValuePair<string, List<string>> neighbor in node.distanceDict)
        {
            Neighbor newNeightbor = new Neighbor();
            foreach (Node graphNode in graph)
            {
                if (graphNode.name == neighbor.Key)
                {
                    newNeightbor.node = graphNode;
                    newNeightbor.distance = neighbor.Value.Count;
                    node.neighbors.Add(newNeightbor);
                    break;
                }
            }
        }
    }
    Dijkstra.TransverNode(graph[0]);
    foreach (Node node in graph)
    {
        Console.WriteLine("Node : {0}", node.name);
        foreach (string key in node.distanceDict.Keys.OrderBy(x => x))
        {
            Console.WriteLine(" Path to node {0} is {1}", key, string.Join(",",node.distanceDict[key].ToArray()));
        }
    }
}

public class Neighbor
{
    public Node node {get;set;}
    public int distance { get; set; }
}
public class Node
{
    
    public string name { get; set; }
    public Dictionary<string, List<string>> distanceDict { get; set; }
    public Boolean visited { get; set; }
    public List<Neighbor> neighbors {get;set;}
}
		
public class Dijkstra
{	
    public static void TransverNode(Node node)
    {
        if (!node.visited)
        {
            node.visited = true;
            foreach (Neighbor neighbor in node.neighbors)
            {
                TransverNode(neighbor.node);
                string neighborName = neighbor.node.name;
                int neighborDistance = neighbor.distance;
                //compair neibors dictionary with current dictionary
                //update current dictionary as required
                foreach (string key in neighbor.node.distanceDict.Keys)
                {
                    if (key != node.name)
                    {
                        int neighborKeyDistance = neighbor.node.distanceDict[key].Count;
                        if (node.distanceDict.ContainsKey(key))
                        {
                            int currentDistance = node.distanceDict[key].Count;
                            if (neighborKeyDistance + neighborDistance < currentDistance)
                            {
                                List<string> nodeList = new List<string>();
                                nodeList.AddRange(neighbor.node.distanceDict[key].ToArray());
                                nodeList.Insert(0, neighbor.node.name);
                                node.distanceDict[key] = nodeList;
                            }
                        }
                        else
                        {
                            List<string> nodeList = new List<string>();
                            nodeList.AddRange(neighbor.node.distanceDict[key].ToArray());
                            nodeList.Insert(0, neighbor.node.name);
                            node.distanceDict.Add(key, nodeList);
                        }
                    }
                }
            }
        }
    }
}