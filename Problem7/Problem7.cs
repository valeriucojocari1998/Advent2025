namespace Advent2025.Problem4;

public static class Problem7
{
    public static void SolvePart1()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem7\\problem7.txt";
        var input = new List<List<char>>();
        var result = 0;
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
               input.Add(line.ToCharArray().ToList()); 
            }
        }

        for (int i = 0; i < input.Count; i++)
        for (int j = 0; j < input[i].Count; j++)
        {
            if (input[i][j] == 'S')
            {
                if (i + 1 < input.Count && input[i + 1][j] == '.')
                {
                    input[i + 1][j] = '|';
                }
            }

            if (input[i][j] == '^' && input[i-1][j] == '|')
            {
                if (i + 1 < input.Count)
                {
                    if (j - 1 >= 0 && input[i+1][j-1] == '.')
                    {
                        input[i + 1][j-1] = '|';
                    }

                    if (j + 1 < input[i].Count && input[i + 1][j + 1] == '.')
                    {
                        input[i + 1][j + 1] = '|';
                    }
                }

                result++;
            }

            if (input[i][j] == '|')
            {
                if (i + 1 < input.Count && input[i + 1][j] == '.')
                {
                    input[i + 1][j] = '|';
                }
            }
        }

        Console.WriteLine($"Value: {result}");
    }
    
    public static void SolvePart2()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem7\\problem7.txt";
        var input = new List<List<char>>();
        long result = 0;
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                input.Add(line.ToCharArray().ToList()); 
            }
        }

        List<List<long>> timelines  = input.Select(x => x.Select(y => 0L).ToList()).ToList();

        for (int i = 0; i < input.Count; i++)
        for (int j = 0; j < input[i].Count; j++)
        {
            if (input[i][j] == 'S')
            {
                if (i + 1 < input.Count && input[i + 1][j] == '.')
                {
                    timelines[i + 1][j] = 1;
                }
            }

            if (input[i][j] == '^' && timelines[i - 1][j] > 0)
            {
                if (j - 1 >= 0)
                {
                    timelines[i + 1][j - 1] += timelines[i - 1][j];
                }

                if (j + 1 < input[i].Count)
                {
                    timelines[i + 1][j + 1] += timelines[i - 1][j];
                }
            
            }

            if (input[i][j] != 'S' && input[i][j] != '^')
            {
                if (timelines[i][j] > 0)
                {
                    if (i + 1 < input.Count)
                    {
                        timelines[i + 1][j] +=  timelines[i][j];
                    }
                }
            }
        }

        Console.WriteLine($"Value: {timelines.Last().Sum()}");
    }

    

}