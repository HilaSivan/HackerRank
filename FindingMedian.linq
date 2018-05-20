<Query Kind="Program" />

void Main()
{
	int[] array = new int[]{12,4,5,3,8,7};
	double[] medians = GetMedians(array);
	foreach (var d in medians)
	{
	 Console.WriteLine("{0:0.0}", d); 
	}
}

public static double[] GetMedians(int[] array)
{
	PriorityQueue<int> lowers = new PriorityQueue<int>(new MaxHeapComperator()); //MaxHeap
	PriorityQueue<int> highers = new PriorityQueue<int>(new MinHeapComperator()); // MinHeap
	double[] medians = new double[array.Length];
	for (int i=0; i< array.Length; i++)
	{
		int num= array[i];
		AddNumber(num, lowers,highers);
		Rebalance(lowers, highers);
		medians[i] = GetMedian(lowers, highers);
	}
	
	return medians;
}

private static void AddNumber(int num, PriorityQueue<int> lowers, PriorityQueue<int> highers)
{
	if (lowers.Count == 0 || num < lowers.Peek())
	{
		lowers.Enqueue(num);
	}
	else
	{
		highers.Enqueue(num);
	}

}

private static void Rebalance( PriorityQueue<int> lowers, PriorityQueue<int> highers)
{
	PriorityQueue<int> biggest = lowers.Count > highers.Count ? lowers : highers;
	PriorityQueue<int> smallest = lowers.Count > highers.Count ? highers : lowers;
	
	if (biggest.Count - smallest.Count >=2)
	{
		smallest.Enqueue(biggest.Dequeue());
	}
}

private static double GetMedian(PriorityQueue<int> lowers, PriorityQueue<int> highers)
{
	PriorityQueue<int> biggest = lowers.Count > highers.Count ? lowers : highers;
	PriorityQueue<int> smallest = lowers.Count > highers.Count ? highers : lowers;
	
	if (biggest.Count == smallest.Count)
	{
		return (double)(((double)biggest.Peek() + (double)smallest.Peek())/(double)2);
	}
	return (double)biggest.Peek();
}

class MaxHeapComperator : IComparer<int>
{
   public int Compare(int a, int b)
	{
		return -1*a.CompareTo(b);			
	}
}

class MinHeapComperator : IComparer<int>
{
   public int Compare(int a, int b)
	{
		return a.CompareTo(b);			
	}
}

public class PriorityQueue<T> : ICollection, IEnumerable<T> where T : IComparable<T>
{
    public enum Type
    {
        MinHeap = 0,
        MaxHeap = 1
    };

    private readonly List<T> _heap;
    private readonly Type _type;


    IComparer<T> Comparer { get; set; }

    /// <summary>
    /// If you want to create MaxHeap you should implement IComparer(T) returning >0 when first item is lesser than second and less than zero
    /// when first item is greater than second item.
    /// </summary>
    /// <param name="comparer">Comparer</param>
    public PriorityQueue(IComparer<T> comparer)
        : this(comparer, new List<T>())
    {
        
    }

    public PriorityQueue(IComparer<T> comparer, int Capacity)
        : this(comparer, new List<T>(Capacity))
    {

    }

    public PriorityQueue(IComparer<T> comparer, IEnumerable<T> collection)
    {
        if (collection == null)
            throw new ArgumentNullException("Collection is null!");

        this.Comparer = comparer;
        _heap = new List<T>(collection);
        InitializeHeap();
    }

    private void InitializeHeap()
    {
        if (_heap.Any())
        {
            for (int i = _heap.Count - 1; i >= 0; --i)
                this.BubbleDown(i);
        }
    }

    private int Parent(int index)
    {
        if (index <= 0)
            return -1;

        return (index - 1) / 2;
    }

    private int LeftChildren(int index)
    {
        int childrenId = (index << 1) + 1;
        if (childrenId >= _heap.Count)
            return -1;

        return childrenId;
    }

    private int RightChildren(int index)
    {
        int childrenId = index * 2 + 2;
        if (childrenId >= _heap.Count)
            return -1;

        return childrenId;
    }

    static void Swap(List<T> list, int first, int second)
    {
        T temp = list[first];
        list[first] = list[second];
        list[second] = temp;
    }

    /// <summary>
    /// Iterative bubble up heap method. O(logn);
    /// </summary>
    /// <param name="index">Item index</param>
    private void BubbleUp(int index)
    {
        //int parentIndex = Parent(index);
        int parentIndex = (index - 1) >> 1;

        if (parentIndex == -1)
            return;
        T item = _heap[index];
        
        while ( Comparer.Compare(_heap[index], _heap[parentIndex]) < 0 )
        {
            _heap[index] = _heap[parentIndex];

            index = parentIndex;
            _heap[index] = item;

            parentIndex = (index - 1) >> 1;
            if (parentIndex == -1)
                break;
        }
        
    }


    /// <summary>
    /// Iterative bubble down heap method. O(logn);
    /// </summary>
    /// <param name="index">Item index.</param>
    private void BubbleDown(int index)
    {
        int leftChildren = (index << 1) + 1;
        int rightChildren = (index << 1) + 2;
        int minItem = (rightChildren < _heap.Count && Comparer.Compare(_heap[leftChildren], _heap[rightChildren]) > 0) ? rightChildren : leftChildren;
        T item = _heap[index];

        while (minItem < _heap.Count && Comparer.Compare(_heap[minItem], _heap[index]) < 0)
        {
            // swap - performance issue (same as  Swap(_heap, minItem, index) )
            T tempItem = _heap[minItem];
            _heap[minItem] = _heap[index];
            _heap[index] = tempItem;
            //endswap

            index = minItem;
            
            leftChildren = (index << 1) + 1;
            rightChildren = (index << 1) + 2;

            minItem = (rightChildren < _heap.Count && Comparer.Compare(_heap[leftChildren], _heap[rightChildren]) > 0) ? rightChildren : leftChildren;
        }
    }

    
    private void BubbleUpRecursive(int index)
    {
        int parentIndex = Parent(index);

        if (parentIndex == -1)
            return;

        if ( Comparer.Compare(_heap[parentIndex], _heap[index]) > 0)
        {
            Swap(_heap, parentIndex, index);
            BubbleUpRecursive(parentIndex);
        }
    }
    private void BubbleDownRecursive(int index)
    {
        int leftChild = LeftChildren(index);
        int rightChild = RightChildren(index);
        int minChild = 0;

        if (index >= _heap.Count || (leftChild == -1 && rightChild == -1))
            return;

        if (leftChild == -1)
            minChild = rightChild;
        else if (rightChild == -1)
            minChild = leftChild;
        else
            minChild = (Comparer.Compare(_heap[leftChild], _heap[rightChild]) >= 0) ? rightChild : leftChild;

        if ( Comparer.Compare(_heap[minChild], _heap[index]) < 0 )
        {
            Swap(_heap, minChild, index);
            BubbleDownRecursive(minChild);
        }
    }
    
   
    public void Enqueue(T item)
    {
        _heap.Add(item);
        BubbleUp(_heap.Count - 1);
    }

    public T Dequeue()
    {
        if (_heap.Count == 0)
            throw new InvalidOperationException("Queue is empty!");
        int lastIndex = _heap.Count - 1;
        T rootItem = _heap[0];
        Swap(_heap, 0, lastIndex);
        _heap.RemoveAt(lastIndex);
        if (_heap.Any())
           BubbleDown(0);

        return rootItem;
    }

    public T Peek()
    {
        if (_heap.Count == 0)
            throw new InvalidCastException("Queue is empty!");
        return _heap[0];
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _heap.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void CopyTo(Array array, int index)
    {
        ((ICollection)_heap).CopyTo(array, index);
    }

    public int Count
    {
        get { return _heap.Count; }
    }

    public bool IsSynchronized
    {
        get { return false; }
    }

    public object SyncRoot
    {
        get { throw new NotImplementedException(); }
    }
}
