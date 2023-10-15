using System.Text;
using System.Text.RegularExpressions;

namespace Strings;

internal class TextSplitter
{
    public static string[] SplitIntoWords(string[] lines)
    {
        var wordSeparator = @"[\s\p{P}]";
        return lines.SelectMany(line => Regex.Split(line, wordSeparator))
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();
    }

    public static string[] SplitIntoSentances(string[] lines)
    {
        var sentanceSeparator = @"(?<=[.!?])\s+";
        var temp = lines.SelectMany(line => Regex.Split(line, sentanceSeparator))
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();

        var builder = new StringBuilder();
        var list = new List<string>();

        foreach (var line in temp)
        {
            if (line.EndsWith('.') || line.EndsWith('!') || line.EndsWith('?'))
            {
                if (builder.Length > 0)
                {
                    builder.Append(line);
                    list.Add(builder.ToString());
                    builder.Clear();
                }
                else
                    list.Add(line);
            }
            else
            {
                builder.Append(line + " ");
            }
        }
        return list.ToArray();
    }
}

