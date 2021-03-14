<Query Kind="Program" />

/*
Problem Description

Given an directed graph having A nodes labelled from 1 to A containing M edges given by matrix B of size M x 2such that there is a edge directed from node

B[i][0] to node B[i][1].

Find whether a path exists from node 1 to node A.

Return 1 if path exists else return 0.

NOTE:

There are no self-loops in the graph.
There are no multiple edges between two nodes.
The graph may or may not be connected.
Nodes are numbered from 1 to A.
Your solution will run on multiple test cases. If you are using global variables make sure to clear them.


Problem Constraints
2 <= A <= 105

1 <= M <= min(200000,A(A-1))

1 <= B[i][0], B[i][1] <= A



Input Format
The first argument given is an integer A representing the number of nodes in the graph.

The second argument given a matrix B of size M x 2 which represents the M edges such that there is a edge directed from node B[i][0] to node B[i][1].



Output Format
Return 1 if path exists between node 1 to node A else return 0.



Example Input
Input 1:

 A = 5
 B = [  [1, 2] 
        [4, 1] 
        [2, 4] 
        [3, 4] 
        [5, 2] 
        [1, 3] ]
Input 2:

 A = 5
 B = [  [1, 2]
        [2, 3] 
        [3, 4] 
        [4, 5] ]


Example Output
Output 1:

 0
Output 2:

 1




*/


class Solution {
    public int solve(int A, List<List<int>> B) 
    {
        Dictionary<int, Stack<int>> dic = new Dictionary<int,Stack<int>>();
        FillDic(dic, B);
       return CheckForPath(1, A, dic);
    }
    
    private void FillDic(   Dictionary<int,Stack<int>>  dic, List<List<int>> B)
    {
        foreach (var item in B)
        {
            if (!dic.ContainsKey(item[0]))
            {
                dic.Add(item[0], new Stack<int>());
            }
            dic[item[0]].Push(item[1]);
        }
    }
    
    private int CheckForPath(int number, int A, Dictionary<int, Stack<int>>  dic)
    {
        if (dic.ContainsKey(number))
        {
            var stack = dic[number];
            while (stack.Count > 0)
            {
                var connectedNumer = stack.Pop();
                if (connectedNumer == A)
                {
                    return 1;
                }
              
                return CheckForPath(connectedNumer, A, dic);
            }
        }
      
       
        return 0;
    }
}