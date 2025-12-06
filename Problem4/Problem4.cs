namespace Advent2025.Problem4;

public static class Problem4
{
    public static void SolvePart1()
    {
        var filepath = "C:\\Users\\valer\\Documents\\Advent2025\\Problem4\\problem4.txt";
        var charTable = new List<char[]>();
        var positions = new List<(int i, int j)>();
        var finalValue = 0;
        var turnValue = 1;
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                charTable.Add(line.ToArray());
            }
        }
        
        while (turnValue > 0)
        {
            positions = new List<(int i, int j)>();
            turnValue = 0;
            for (int i = 0; i < charTable.Count; i++)
            for (int j = 0; j < charTable[i].Length; j++)
            {
                var count = charTable[i][j] == '@' ? 
                    ((i - 1 >= 0 && j - 1 >= 0 && charTable[i - 1][j - 1] == '@' ? 1 : 0) +
                    (i - 1 >= 0 && charTable[i - 1][j] == '@' ? 1 : 0) +
                    (i - 1 >= 0 && j + 1 < charTable[i - 1].Length && charTable[i - 1][j + 1] == '@' ? 1 : 0) +
                    (j - 1 >= 0 && charTable[i][j - 1] == '@' ? 1 : 0) +
                    (j + 1 < charTable[i].Length && charTable[i][j + 1] == '@' ? 1 : 0) +
                    (i + 1 < charTable.Count && j - 1 >= 0 && charTable[i + 1][j - 1] == '@' ? 1 : 0) +
                    (i + 1 < charTable.Count && charTable[i + 1][j] == '@' ? 1 : 0) +
                    (i + 1 < charTable.Count && j + 1 < charTable[i + 1].Length && charTable[i + 1][j + 1] == '@' ? 1 : 0)) : 4;

                if (count < 4)
                {
                    positions.Add((i, j));
                    turnValue++;
                }
            }
            
            foreach (var valueTuple in positions)
            {
                charTable[valueTuple.i][valueTuple.j] = 'X';
            }

            finalValue += turnValue;

        }
        
        Console.WriteLine($"Value: {finalValue}");
    }
}