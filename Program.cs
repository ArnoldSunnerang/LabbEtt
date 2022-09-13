void Labb(string s)
{
    char[] strang = s.ToCharArray();
    int firstIndex = 0;
    int searchIndex = 0;
    int lastIndex = 0;
    ulong sum = 0;
    List<int> excludedSummands = new List<int>();

    void AlongString()
    {
        if (firstIndex < strang.Length)
        {
            if (Char.IsDigit(strang[firstIndex]))
            {
                searchIndex = firstIndex + 1;
                SearchString();
                firstIndex++;
                AlongString();

            }
            else
            {
                firstIndex++;
                AlongString();
            }

        }

    }

    void SearchString()
    {
        if (searchIndex < strang.Length)
        {
            if (Char.IsDigit(strang[searchIndex]))
            {
                if (strang[searchIndex] == strang[firstIndex])
                {
                    lastIndex = searchIndex;
                    WriteString();
                    SumString();
                }
                else
                {
                    searchIndex++;
                    SearchString();
                }
            }


        }
    }

    void WriteString()
    {
        for (int i = 0; i < strang.Length; i++)
        {
            if (i == firstIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(strang[i]);
            }
            else if (i == lastIndex)
            {
                Console.Write(strang[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(strang[i]);

            }
        }
        Console.WriteLine();
    }

    void SumString()
    {
        char[] coloredString = new char[(lastIndex - firstIndex) + 1];
        
        for (int i = 0; i < (coloredString.Length); i++)
        {
            coloredString[i] = strang[firstIndex + i];
        }
        
        string sumString = new string(coloredString);

        try 
        {
            sum = ulong.Parse(sumString) + sum;

        }
        catch
        {
            excludedSummands.Add(firstIndex);
        }

    }

    void WriteSum()
    {
        Console.WriteLine();
        Console.WriteLine($"The sum is {sum}");
        
        if (excludedSummands.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("The excluded summands begin on indices:");
            
            foreach (int n in excludedSummands)
            {
                Console.WriteLine(n);
            }
        }
    }

    AlongString();
    WriteSum();
}

Labb("29535123p48723487597645723645");