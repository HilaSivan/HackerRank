<Query Kind="Program" />

void Main()
{
	int[] array = {1,5,2,4,3};
	
	SegmentTree st = new SegmentTree(array);
	st.Build();
	st.PrintTreeArray();
	//Console.WriteLine(st.Query(0,4));
	Console.WriteLine(st.Query(3,5));
	st.Update(1,0);
	st.PrintTreeArray();
	Console.WriteLine(st.Query(1,5));
}


public class SegmentTree
{
    private int[] Tree;
    private int TreeSize;
    private int[] _array;
    private int _arraySize;

    public SegmentTree(int[] array)
    {
	
        TreeSize = (array.Count()+1)*2;
        Tree = new int[TreeSize];
       	_array = (int[])array.Clone();
        _arraySize = array.Count()-1;
    }

	public void Build()
	{
		Build(0, 0, _arraySize);
	}
    private void Build(int indexTree, int start, int end)
    {		
		//Console.Write($"indexTree= {indexTree} start ={start} end = {end}");
        if (start == end)
        {
            Tree[indexTree] = _array[start];
			return;
        }
        int mid = (start+end)/2;
	
        Build(2*indexTree + 1, start, mid );
		Build(2*indexTree + 2, mid + 1, end);		
        Tree[indexTree] = Math.Min(Tree[2*indexTree +1], Tree[2*indexTree+2]);
	}
	
	public void PrintTreeArray()
	{
		foreach (var node in Tree)
		{
			Console.Write($" {node} ");
		}
		
		Console.WriteLine("");
	}

    public void Update(int index, int number)
    {
       Update(0, 0, _arraySize, index-1, number);      
    }

    private void Update(int indexTree, int start, int end, int index, int number)
    {
		if (indexTree > TreeSize)
		{
			return;
		}
        if (start == end)
        {          
            _array[index] = number;
            Tree[indexTree] = number;			
        }
		else
		{
		    int mid = (start + end)/2;
			if (start <= index && index <= mid)
			{			
	        	Update(indexTree*2+1, start, mid, index, number);
			}
			else
			{
	       		Update(index*2 + 2, mid, end, index, number);
			}
	        Tree[index] = Math.Min(Tree[indexTree*2+1], Tree[indexTree*2+2]);
		
		}
    
    }


    public  int Query(int left, int right)
    {
        return Query(0, 0, _arraySize, left-1, right-1);
    }

    private int Query (int treeIndex, int start, int end, int left, int right )
    {	
		
        if (right < start || left> end || treeIndex > TreeSize)
        {
            //outside of array
            return Int32.MaxValue;
        }
		
		
        if (left<= start && right <= end)
        {
            return Tree[treeIndex];
        }
	

        int mid= (start + end)/2;

        int min1 = Query(treeIndex*2+1, start, mid, left, right );
        int min2 = Query(treeIndex*2 +2, mid, end, left, right);

        return Math.Min(min1, min2);
    }

}