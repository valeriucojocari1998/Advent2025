namespace Advent2025.Problem4;

public static class Problem6
{
    public static void SolvePart1()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem6\\problem6.txt";
        var input = new List<string>();
        var numbers = new List<List<long>>();
        var signs = new List<char>();
        var isSigns = false;
        long finalValue = 0;
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim(' ');
                if (line[0] == '*' || line[0] == '*')
                {
                    isSigns = true;
                }

                if (isSigns)
                {
                    var values = line.Split(' ').Where(x => x != "").Select(x => x[0]).ToList();
                    signs = values;
                }
                else
                {
                    var test = line.Split(' ').ToList();
                    var values = line.Split(' ').Where(x => x != "").Select(x => long.Parse(x)).Where(x => x != long.MinValue).ToList();
                    numbers.Add(values);
                }
            }
        }

        for (int i = 0; i < numbers[0].Count; i++)
        {
            var value = numbers[0][i];
            for (int j = 1; j < numbers.Count; j++)
            {
                if (signs[i] == '+')
                {
                    value += numbers[j][i];
                }

                if (signs[i] == '*')
                {
                    value *= numbers[j][i];
                }
            }
            finalValue += value;
        }

        
        Console.WriteLine($"Value: {finalValue}");
    }
    
    public static void SolvePart2()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem6\\problem6.txt";
        var numbers = new List<List<char>>();
        var numbersParsed = new List<List<long>>();
        var signs = new List<char>();
        var isSigns = false;
        long finalValue = 0;
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line[0] == '*' || line[0] == '*')
                {
                    isSigns = true;
                }

                if (isSigns)
                {
                    line = line.Trim(' ');
                    var values = line.Split(' ').Where(x => x != "").Select(x => x[0]).ToList();
                    signs = values;
                }
                else
                {
                    numbers.Add(line.ToList());
                }
            }
        }

        var position = 0;
        var values2 = new List<long>();

        for (int i = 0; i <= numbers[0].Count; i++)
        {
            var value = "";

            for (int j = 0; j < numbers.Count; j++)
            {
                try
                {
                    value += numbers[j][i];

                }
                catch
                {
                    value += "";
                }
                
            }
            value = value.Trim(' ').Trim(' ').Trim(' ');
            
            if (value == "" || value == " " || value == "  " || value == "   ")
            {
                numbersParsed.Add(values2);
                position++;
                values2 = new List<long>();
                
            }
            else
            {
                values2.Add(long.Parse(value.Trim(' ')));
            }

        }
        
        for (int i = 0; i < numbersParsed.Count; i++)
        {
            var value = numbersParsed[i][0];
            for (int j = 1; j < numbersParsed[i].Count; j++)
            {
                if (signs[i] == '+')
                {
                    value += numbersParsed[i][j];
                }

                if (signs[i] == '*')
                {
                    value *= numbersParsed[i][j];
                }
            }
            finalValue += value;
        }

        Console.WriteLine($"Value: {finalValue}");
    }
    

}