namespace Advent2025.Problem2;

public static class Problem2
{
    public static void SolvePart1()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem2\\problem2.txt";
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

        sequences = input.SelectMany(x => x.Split(',')).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

        long result = sequences.Aggregate(0, (long acc, string s) => acc + CalculateSpecialParts(s));

        Console.WriteLine($"Value 2: {result}");
    }

    private static long CalculateSpecialParts(string s)
    {
        long value = 0;
        var sections = s.Split('-');
        var section1 = long.Parse(sections[0]);
        var section2 = long.Parse(sections[1]);


        if (section1 == section2.NumberDigitsCount() && section1.NumberDigitsCount() % 2 == 1)
            return 0;

        section1 = GetClosestSpecialString(section1, true);

        while (section1 <= section2)
        {
            Console.WriteLine(section1);
            value += section1;
            section1 = GetClosestSpecialString(section1);
        }

        return value;
    }

    private static long GetClosestSpecialString(long s, bool IsFirst = false)
    {
        if (s.NumberDigitsCount() % 2 == 1)
            return long.Parse("1" + new string('0', s.NumberDigitsCount() / 2) + "1" +
                              new string('0', s.NumberDigitsCount() / 2));

        long firstHalf = (long)(s / Math.Pow(10, s.NumberDigitsCount() / 2));
        long secondHalf = (long)(s % Math.Pow(10, s.NumberDigitsCount() / 2));
        if (firstHalf == secondHalf && IsFirst)
            return s;
        if (firstHalf > secondHalf)
            return long.Parse(firstHalf.ToString() + firstHalf.ToString());

        var firstHalfIncreased = firstHalf + 1;

        if (firstHalfIncreased.NumberDigitsCount() != secondHalf.NumberDigitsCount())
            return GetClosestSpecialString(long.Parse(firstHalfIncreased.ToString() + secondHalf.ToString()));

        return long.Parse(firstHalfIncreased.ToString() + firstHalfIncreased.ToString());
    }

    public static void SolvePart2()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem2\\problem2.txt";
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

        sequences = input.SelectMany(x => x.Split(',')).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

        long result = sequences.Aggregate(0, (long acc, string s) => acc + CalculateSpecialNumbersSum(s));

        Console.WriteLine($"Value 2: {result}");
    }

    private static long CalculateSpecialNumbersSum(string part)
    {
        long value = 0;
        var sections = part.Split('-');
        var section1 = long.Parse(sections[0]);
        var section2 = long.Parse(sections[1]);
        var section1Length = section1.NumberDigitsCount();
        var section2Length = section2.NumberDigitsCount();
        var numbers = new List<long>();

        for (var length = section1Length; length <= section2Length; length++)
        {
            var calculatedNumbers = new List<long>();

            var combos = ReturnDividers(length);
            
            var numbers2 = combos.SelectMany(x => BuildAllPotentialNumbers(x.Item1, x.Item2)).Distinct();
            numbers.AddRange(numbers2.Where(x => x >= section1 && x <= section2));
        }
        
        numbers = numbers.Distinct().ToList();
        
        Console.WriteLine($"{section1} - {section2}: " + string.Join(", ", numbers.Select(x => x.ToString())));

        return numbers.Sum();
    }

    private static List<long> BuildAllPotentialNumbers(long sequenceLength, long generationNumber)
    {
        var numbersList = new List<long>();
        var fromNumber = long.Parse("1" + new string('0', (int)(sequenceLength - 1)));
        var lastNumber = long.Parse(new string('9', (int)sequenceLength));
        for (long x = fromNumber; x <= lastNumber; x++)
        {
            numbersList.Add(x * generationNumber);
        }
        return numbersList;
    }

    private static List<(long, long)> ReturnDividers(int x) => x switch
    {
        1 => [],
        2 => [(1, 11)],
        3 => [(1, 111)],
        4 => [(1, 1111), (2, 101)],
        5 => [(1, 11111)],
        6 => [(1, 111111), (2, 10101), (3, 1001)],
        7 => [(1, 1111111)],
        8 => [(1, 11111111), (2, 1010101), (4, 10001)],
        9 => [(1, 111111111), (3, 1001001)],
        10 => [(1, 1111111111), (2, 101010101), (5, 100001)],
        11 => [(1, 11111111111)],
        12 => [(1, 111111111111), (2, 10101010101), (3, 1001001001), (4, 100010001), (6, 1000001)],
    };

    private static int NumberDigitsCount(this long number) => (int)Math.Floor(Math.Log10(number) + 1);
}