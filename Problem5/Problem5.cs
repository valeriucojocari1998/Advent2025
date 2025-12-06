namespace Advent2025.Problem4;

public static class Problem5
{
    public static void SolvePart1()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem5\\problem5.txt";
        var input = new List<string>();
        var ranges = new List<(long i, long j)>();
        var products = new List<long>();
        var isProducts = false;
        var finalValue = 0;
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line == "")
                {
                    isProducts = true;
                    continue;
                }

                if (isProducts)
                {
                    var product = long.Parse(line);
                    products.Add(product);
                }
                else
                {
                    var range = line.Split('-');
                    var from = long.Parse(range[0]);
                    var to = long.Parse(range[1]);
                    ranges.Add((from, to));
                }
            }
        }
        
        foreach (var product in products)
        {
           foreach (var range in ranges)
           {
               if (product >= range.i && product <= range.j)
               {
                   finalValue++;
                   break;
               }
           } 
        }

        
        Console.WriteLine($"Value: {finalValue}");
    }
    
    public static void SolvePart2()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem5\\problem5.txt";
        var input = new List<string>();
        var ranges = new List<(long i, long j)>();
        var newRanges = new List<(long i, long j)>();
        long finalValue = 0;
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var range = line.Split('-');
                var from = long.Parse(range[0]);
                var to = long.Parse(range[1]);
                ranges.Add((from, to));
            }
        }
        
        foreach (var valueTuple in ranges)
        {
             newRanges = newRanges.AddRangeToList(valueTuple);
        }
        
        foreach (var valueTuple in newRanges)
        {
            finalValue += valueTuple.j - valueTuple.i + 1;
        }

        
        Console.WriteLine($"Value: {finalValue}");
    }

    public static List<(long i, long j)> AddRangeToList(this List<(long i, long j)> ranges, (long i, long j) element)
    {
        if (ranges.Count == 0)
        {
            ranges.Add(element);
            return ranges;
        }
        
        var newRanges = new List<(long i, long j)>();

        foreach (var valueTuple in ranges)
        {
            var (main, secondary) = IntersectElements(element, valueTuple);
            element = main;
            if (secondary != null)
            {
                newRanges.Add(secondary.Value);
            }
        }
        
        newRanges.Add(element);
        return newRanges;
    }

    private static ((long i, long j) main, (long i, long j)? secondary) IntersectElements((long i, long j) main, (long i, long j) secondary)
    {
        if (main.i > secondary.j || main.j < secondary.i)
        {
            return (main, secondary);
        }

        if (main.i <= secondary.i && main.j >= secondary.j)
        {
            return (main, null);
        }

        if (main.i >= secondary.i && main.j <= secondary.j)
        {
            return (secondary, null);
        }

        if (main.i <= secondary.i && main.j >= secondary.i && main.j <= secondary.j)
        {
            return ((main.i, secondary.j), null);
        }

        if (main.i >= secondary.i && main.i <= secondary.j && main.j >= secondary.j)
        {
            return ((secondary.i, main.j), null);
        }

        return (main, secondary);
    }
}