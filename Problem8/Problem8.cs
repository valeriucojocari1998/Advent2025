namespace Advent2025.Problem4;

public static class Problem8
{
    public static void SolvePart1()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem8\\problem8.txt";
        var input = new List<(int x, int y, int z)>();
        var distances = new List<(int first, int second, double distance)>();
        long result = 0;
        var combinations = new List<List<int>>();
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
               var values = line.Split(',');
               var x = int.Parse(values[0]);
               var y = int.Parse(values[1]);
               var z = int.Parse(values[2]);
               input.Add((x, y, z));
            }
            
        }

        for (int i = 0; i < input.Count - 1; i++)
        for (int j = i + 1; j < input.Count; j++)
        {
            var distance = Math.Sqrt(Math.Pow(input[i].x - input[j].x, 2) + Math.Pow(input[i].y - input[j].y, 2) + Math.Pow(input[i].z - input[j].z, 2));
            distances.Add((i, j, distance));
        }
        
        distances.Sort((x, y) => x.distance.CompareTo(y.distance));
        for (int i = 0; i < 1000; i++)
        {
            var dist = distances[i];
            var containsFirst = combinations.FindIndex(x => x.Contains(dist.first));
            var containsSecond = combinations.FindIndex(x => x.Contains(dist.second));
            if (containsFirst >= 0 && containsSecond >= 0 )
            {
                if (containsFirst != containsSecond)
                {
                    var elements = new List<int> { };
                    elements.AddRange(combinations[containsFirst]);
                    elements.AddRange(combinations[containsSecond]);
                    combinations[containsFirst] = null;
                    combinations[containsSecond] = null;
                    var toContainAll = containsFirst < containsSecond ? containsFirst : containsSecond;
                    combinations[toContainAll] = elements;
                    combinations = combinations.Where(x => x != null).ToList();
                }
                continue;
            }
            
            
            if (containsFirst >= 0)
            
            {
            
                combinations[containsFirst].Add(dist.second);
                continue;
            }

            if (containsSecond >= 0)
            {
                combinations[containsSecond].Add(dist.first);
                continue;
            }
            
            combinations.Add(new List<int> { dist.first, dist.second });
        }

        var finalCombinations = combinations.Select(x => x.Count).ToList();
        finalCombinations.Sort();
        result = finalCombinations.TakeLast(3).Aggregate((x, y) => x * y);
        
        Console.WriteLine($"Value: {result}");
    }
    
        public static void SolvePart2()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem8\\problem8.txt";
        var input = new List<(int x, int y, int z)>();
        var distances = new List<(int first, int second, double distance)>();
        long result = 0;
        var combinations = new List<List<int>>();
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
               var values = line.Split(',');
               var x = int.Parse(values[0]);
               var y = int.Parse(values[1]);
               var z = int.Parse(values[2]);
               input.Add((x, y, z));
            }
            
        }

        for (int i = 0; i < input.Count - 1; i++)
        for (int j = i + 1; j < input.Count; j++)
        {
            var distance = Math.Sqrt(Math.Pow(input[i].x - input[j].x, 2) + Math.Pow(input[i].y - input[j].y, 2) + Math.Pow(input[i].z - input[j].z, 2));
            distances.Add((i, j, distance));
        }
        
        distances.Sort((x, y) => x.distance.CompareTo(y.distance));
        for (int i = 0; i < distances.Count(); i++)
        {
            var dist = distances[i];
            var containsFirst = combinations.FindIndex(x => x.Contains(dist.first));
            var containsSecond = combinations.FindIndex(x => x.Contains(dist.second));
            if (containsFirst >= 0 && containsSecond >= 0 )
            {
                if (containsFirst != containsSecond)
                {
                    var elements = new List<int> { };
                    elements.AddRange(combinations[containsFirst]);
                    elements.AddRange(combinations[containsSecond]);
                    combinations[containsFirst] = null;
                    combinations[containsSecond] = null;
                    var toContainAll = containsFirst < containsSecond ? containsFirst : containsSecond;
                    combinations[toContainAll] = elements;
                    combinations = combinations.Where(x => x != null).ToList();
                    
                    combinations.Sort((x,y) => y.Count.CompareTo(x.Count));
                    if (combinations.First().Count == input.Count)
                    {
                        Console.WriteLine($"{input[dist.first].x},{input[dist.first].y},{input[dist.first].z} and {input[dist.second].x},{input[dist.second].y},{input[dist.second].z}" );
                    }
                }
                continue;
            }
            
            
            if (containsFirst >= 0)
            
            {
            
                combinations[containsFirst].Add(dist.second);
                combinations.Sort((x,y) => y.Count.CompareTo(x.Count));
                if (combinations.First().Count == input.Count)
                {
                    Console.WriteLine($"{input[dist.first].x},{input[dist.first].y},{input[dist.first].z} and {input[dist.second].x},{input[dist.second].y},{input[dist.second].z}" );
                }
                continue;
            }

            if (containsSecond >= 0)
            {
                combinations[containsSecond].Add(dist.first);
                combinations.Sort((x,y) => y.Count.CompareTo(x.Count));
                if (combinations.First().Count == input.Count)
                {
                    Console.WriteLine($"{input[dist.first].x},{input[dist.first].y},{input[dist.first].z} and {input[dist.second].x},{input[dist.second].y},{input[dist.second].z}" );
                }
                continue;
            }
            
            combinations.Add(new List<int> { dist.first, dist.second });
        }

        var finalCombinations = combinations.Select(x => x.Count).ToList();
        finalCombinations.Sort();
        result = finalCombinations.TakeLast(3).Aggregate((x, y) => x * y);
        
        Console.WriteLine($"Value: {result}");
    }
    

}