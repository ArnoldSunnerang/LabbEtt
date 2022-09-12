void Labb(string s)
{
    char[] strang = s.ToCharArray();
    int searchIndex = 0;
    int firstIndex = 0;
    int lastIndex = 0;
    ulong sum = 0;
    int summands = 0;

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
        char[] greenString = new char[(lastIndex - firstIndex) + 1];
        for (int i = 0; i < (greenString.Length); i++)
        {
            greenString[i] = strang[firstIndex + i];
        }
        string sumString = new string(greenString);

        try 
        {
            sum = ulong.Parse(sumString) + sum;

        }
        catch
        {
            summands++;
        }

    }

    AlongString();
    Console.WriteLine();
    Console.WriteLine($"The sum is {sum}, excluding {summands} numbers that are too large.");
}

Labb("");