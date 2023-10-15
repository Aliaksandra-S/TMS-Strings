using System.Text;

namespace Strings;
internal class Operation
{
    public static string[] GetWordsWithMaxCountOfDigits(string[] words)
    {
        var maxDigitCount = 0;
        
        foreach (var word in words)
        {
            int digitCount = CountDigitsInWord(word);
            if (digitCount > maxDigitCount)
            {
                maxDigitCount = digitCount;
            }
        }
        return FindAllWords(words, maxDigitCount);
    }

    public static (string, int) GetLongestWordAndFrequency(string[] words)
    {
        var word = words.OrderByDescending(w => w.Length).First();
        var frequency = words.Count(w => w.Equals(word, StringComparison.OrdinalIgnoreCase));
        return (word, frequency);
    }

    public static string[] ReplaceDigitsToWords(string[] strings)
    {
        var result = new string[strings.Length];
        var builder = new StringBuilder();

        for(var s = 0; s < strings.Length; s++)
        {
            builder.Append(strings[s]);
            for(var i = 0; i < builder.Length; i++)
            {
                if (char.IsDigit(builder[i]))
                    builder.Replace(builder[i].ToString(), GetLiteralRepresentation(builder[i]));
            }
            result[s] = builder.ToString();
            builder.Clear();
        }
        return result;
    }

    public static string[] GetInterrogativeThenExclamatory(string[] sentances)
    {
        var interrogative = sentances.Where(s => s.EndsWith('?'));
        var exclamatory = sentances.Where(s => s.EndsWith('!'));
        return interrogative.Concat(exclamatory).ToArray();
    }

    public static string[] GetSentancesWithoutComma(string[] sentances)
    {
        return sentances.Where(s => !s.Contains(',')).ToArray();
    }

    public static string[] GetWordsStartAndEndSame(string[] words)
    {
        return words.Where(word => hasSameStartAndEndChar(word)).ToArray();
    }
    private static int CountDigitsInWord(string word)
    {
        var count = 0;
        foreach (var c in word)
        {
            if (char.IsDigit(c))
                count++;
        }
        return count;
    } 
    private static string[] FindAllWords(string[] words, int digitNumber)
    {
        var list = new List<string>();
        foreach(var word in words)
        {
            if(CountDigitsInWord(word) == digitNumber)
            {
                list.Add(word);
            }
        }
        return list.ToArray();
    }
    private static bool hasSameStartAndEndChar(string word)
    {
        return word.Length > 1 && word[0] == word[word.Length - 1];
    }

    private static string GetLiteralRepresentation(char digit) => digit switch
    {
        '0' => "ноль",
        '1' => "один",
        '2' => "два",
        '3' => "три",
        '4' => "четыре",
        '5' => "пять",
        '6' => "шесть",
        '7' => "семь",
        '8' => "восемь",
        '9' => "девять",
        _ => "",
    };
}

