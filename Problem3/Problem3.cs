namespace Advent2025.Problem3;

public class Problem3
{
    public static void SolvePart1()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem3\\problem3.txt";
        var input = new List<string>();
        var sequences = new List<string>();
        var value = 0;
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                input.Add(line);
            }
        }

        var numbers = input.Select(x => GetBiggestBattery(x)).Sum();
        
        Console.WriteLine($"Numbers: {numbers}");
    }

    public static int GetBiggestBattery(string input)
    {
        char? firstDigit = null;
        char? secondDiggit = null;

        string number = string.Empty;
        firstDigit = input[0];
        int firstDigitPosition = 0;
        for (int i = 1; i < input.Length; i++)
        {
            if (firstDigit < input[i])
            {
                firstDigit = input[i];
                firstDigitPosition = i;
            }
        }

        if (firstDigitPosition == input.Length - 1)
        {
            secondDiggit = input[firstDigitPosition-1];
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (secondDiggit < input[i])
                {
                    secondDiggit = input[i];
                }
            }
            
            number = secondDiggit.ToString() + firstDigit.ToString();
        }
        else
        {
            secondDiggit = input[firstDigitPosition + 1];
            for (int i = firstDigitPosition + 1; i < input.Length; i++)
            {
                if (secondDiggit < input[i])
                {
                    secondDiggit = input[i];
                }
            }
            
            number = firstDigit.ToString() + secondDiggit.ToString();
        }
            
        return int.Parse(number);
    }
    
    public static void SolvePart2()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem3\\problem3.txt";
        var input = new List<string>();
        var sequences = new List<string>();
        var value = 0;
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                input.Add(line);
            }
        }

        var numbers = input.Select(x => GetBiggestBattery12(x)).Sum();
        
        Console.WriteLine($"Numbers: {numbers}");
    }

    public static long GetBiggestBattery12(string input)
    {
        var digits = new List<(int value, int position)>();

        var lastDigitPosition = -1;
        string number = string.Empty;
        for (int digIndex = 1; digIndex <= 12; digIndex++)
        {
            var digit = GetBiggestNumber(input, lastDigitPosition + 1, input.Length - (13 -digIndex));
            digits.Add(digit);
            lastDigitPosition = digit.position;
        }

        number = string.Join("", digits.Select(x => x.value.ToString()));
        Console.WriteLine($"Number: {number}");
        return long.Parse(number);
    }

    public static (int value, int position) GetBiggestNumber(string input, int from, int to)
    {
        char value = input[from];
        var position = from;
        for (int i = from + 1; i <= to; i++)
        {
            if (value < input[i])
            {
                value = input[i];
                position = i;
            }
        }

        return (int.Parse(value.ToString()), position);
    }

}