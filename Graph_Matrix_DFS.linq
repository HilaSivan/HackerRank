<Query Kind="Program" />

//DFS: Connected Cell in a Grid
//Find the Bigest region 
void Main()
{
 	int n = Convert.ToInt32(Console.ReadLine()); // rows
    int m = Convert.ToInt32(Console.ReadLine()); // columns
    int[][] grid = new int[n][];
    for(int grid_i = 0; grid_i < n; grid_i++){
       string[] grid_temp = Console.ReadLine().Split(' ');
       grid[grid_i] = Array.ConvertAll(grid_temp,Int32.Parse);
    }
    
     Console.WriteLine(GetMax(grid, n, m));
}

public static int GetMax(int[][] arr, int n, int m)
{
	// Create a matrix of  the cells we have visited in visited
	// init this matrix in false
    bool[][] visited = new bool[n][]; 

    for(int i=0;i<n;i++)
        visited[i] = new bool[m]; 

    for(int i=0;i<n;i++)
        for(int j=0;j<m;j++)    
        	visited[i][j] = false; 
    
    int max = 0;
    IList<string> curList = new List<string>(); 
    for(int i=0;i<n;i++)
	{
        for(int j=0;j<m;j++)
    	{
	        if (!visited[i][j])
	        {
	            int node = arr[i][j];
	            if (node == 1)
	            {
	                IList<string> list = new List<string>();
	
	                DFS(arr, i, j, visited, m + n, list);
	
	                if (list.Count > max)
	                {
	                    curList = list;
	                    max = list.Count;
	                }
	            }
	        }
		}
    }
	//Print the region
	foreach (var item in curList)
	{
		Console.Write($"{item} ");
	}
	Console.WriteLine("");
    return max; 
}

private static void DFS(int[][] arr, int i, int j, bool[][] visited, int maxStep, IList<string> list)
{
    int row = arr.Length; 
    int col = arr[0].Length; 
    if( i<row && i>=0 && j<col && j>=0 && maxStep >=0)
    {                
        // node is 1 and not visited. 
        if (arr[i][j] == 1 && !visited[i][j])
        {
            visited[i][j] = true;

            list.Add($"({i},{j})");

            DFS(arr, i - 1, j - 1, visited, maxStep - 1, list);
            DFS(arr, i - 1, j, visited, maxStep - 1, list);
            DFS(arr, i - 1, j + 1, visited, maxStep - 1, list);

            DFS(arr, i, j - 1, visited, maxStep - 1, list);
            DFS(arr, i, j + 1, visited, maxStep - 1, list);

            DFS(arr, i + 1, j - 1, visited, maxStep - 1, list);
            DFS(arr, i + 1, j, visited, maxStep - 1, list);
            DFS(arr, i + 1, j + 1, visited, maxStep - 1, list);
        }               
        else if(arr[i][j] == 0)
        {
            if (!visited[i][j])
                visited[i][j] = true; 
        }
    }      
}
	