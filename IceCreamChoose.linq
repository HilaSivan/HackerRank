<Query Kind="Program" />

void Main()
{
	int[] a= {3,2,5,2,4,1,3};
	int amount = 4;
	
	 List<Tuple<int, int>>  results = ChooseIceCream(a,amount);
	 foreach(var result in results)
	 {
	 	Console.WriteLine($" {result.Item1} {result.Item2}");	 
	 }
}

public static List<Tuple<int, int>>  ChooseIceCream(int[]a, int amount)
{	
	Dictionary<int, List<int>> menu = new Dictionary<int, List<int>>();
	
	for (int i=0; i< a.Length; i++)
	{
		if (!menu.ContainsKey(a[i]))
		{
			menu.Add(a[i], new List<int>());
		}
		menu[a[i]].Add(i);
	}	
	
	return GetIndexes(menu, amount);
}

public static List<Tuple<int, int>>  GetIndexes(Dictionary<int, List<int>> menu, int amount)
{
	List<Tuple<int, int>>  result = new List<Tuple<int, int>>(); //Only 2 numbers to add up
	foreach (var item in menu)
	{
		int rest = amount - item.Key;
		if (menu.ContainsKey(rest))		
		{		
			foreach (var index1 in item.Value)
			{
				foreach (var index2 in menu[rest])
				{
					if (index1 != index2 )
					{
						if (!result.Any(x=>x.Item1 == index2 && x.Item2 == index1) )
						{
							result.Add(Tuple.Create(index1, index2));
						}
					}
				}
			}	
		}
	}
	return result;
}
