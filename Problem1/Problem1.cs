namespace Advent2025;

public static class Problem1
{
    public static void SolvePart1()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem1\\problem1.txt";
        var input = new List<string>();
        var position = 50;
        var value = 0;
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                input.Add(line);
            }
        }

        foreach (var line in input)
        {
            var direction = line[0];
            var lineNumber = line.Remove(0, 1);
            var amount = int.TryParse(lineNumber, out var result) ? result : 0;
            if (direction == 'R')
            {
                position += amount;
                position %= 100;
            }

            if (direction == 'L')
            {
                position -= amount;
                if (position <= 0)
                {
                    var posToCalculate = position * -1;
                    position = 100 - (posToCalculate % 100);
                }
                position %= 100;
            }

            if (position == 0)
            {
                value++;
            }
        }

        Console.WriteLine($"Value 1: {value}");
    }
    
    public static void SolvePart2()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem1\\problem1.txt";
        var input = new List<string>();
        var position = 50;
        var value = 0;
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                input.Add(line);
            }
        }

        foreach (var line in input)
        {
            var direction = line[0];
            var lineNumber = line.Remove(0, 1);
            var amount = int.TryParse(lineNumber, out var result) ? result : 0;
            if (direction == 'R')
            {
                position += amount;
                value += position / 100;
                position %= 100;
            }

            if (direction == 'L')
            {
                var newPosition = position - amount;
                if (newPosition <= 0  && position != 0)
                {
                    value += 1;
                }
                var posToCalculate = newPosition * -1;
                value += posToCalculate / 100;
                newPosition = 100 - (posToCalculate % 100);
                newPosition %= 100;
                
                position = newPosition;
            }
        }

        Console.WriteLine($"Value 2: {value}");
    }

}