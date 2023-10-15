namespace Strings;
class Program {
    static void Main(string[] args)
    {
        var path = @"..\..\..\Input.txt";
        var lines = File.ReadAllLines(path);

        var sentances = TextSplitter.SplitIntoSentances(lines);
        var words = TextSplitter.SplitIntoWords(lines);

        var isFinished = false;
        while (!isFinished)
        {
            Console.Clear();

            Console.WriteLine("\nВыберите задачу:");
            Console.WriteLine("1 - Найти слова, содержащие максимальное количество цифр");
            Console.WriteLine("2 - Найти самое длинное слово и определить, сколько раз оно встречалось в тексте");
            Console.WriteLine("3 - Заменить цифры от 0 до 9 на слова \"ноль\", .. \"девять\"");
            Console.WriteLine("4 - Вывести сначала вопросительные, затем восклицательные предложения");
            Console.WriteLine("5 - Вывести только предложения, не содержащие запятых");
            Console.WriteLine("6 - Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву");
            Console.WriteLine("0 - ВЫХОД");
            Console.Write("\nВведите номер: ");

            switch (ReadValidInput(0, 6))
            {
                case 0:
                    {
                        Console.WriteLine("Пока :)");
                        isFinished = true;
                        break;
                    }
                case 1:
                    {
                        var result = Operation.GetWordsWithMaxCountOfDigits(words);
                        Print("Ни в одном из слов нет цифр.", result);
                        break;
                    }
                case 2:
                    {
                        var result = Operation.GetLongestWordAndFrequency(words);
                        Console.WriteLine($"Самое длинное слово: {result.Item1}" +
                                          $"\nЧастота повторения: {result.Item2}");
                        break;
                    }
                case 3:
                    {
                        var result = Operation.ReplaceDigitsToWords(lines);
                        Print("В тексте нет цифр.", result);
                        break;
                    }
                case 4:
                    {
                        var result = Operation.GetInterrogativeThenExclamatory(sentances);
                        Print("В тексте нет таких предложений.", result);
                        break;
                    }
                case 5:
                    {
                        var result = Operation.GetSentancesWithoutComma(sentances);
                        Print("В тексте нет таких предложений.", result);
                        break;
                    }
                case 6:
                    {
                        var result = Operation.GetWordsStartAndEndSame(words);
                        Print("В тексте нет таких слов.", result);
                        break;
                    }
            }
            Console.ReadKey();
        }
    }
    private static void Print(string message, params string[] strings)
    {
        if(strings != null && strings.Length > 0)
        {
            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }
        }
        else
        {
            Console.WriteLine(message);
        }
    }
    private static int ReadValidInput(int lower, int upper)
    {
        var valid = -1;
        var input = Console.ReadLine();
        while (!int.TryParse(input, out valid) && valid < lower && valid > upper)
        {
            Console.WriteLine("Не то.. попробуй еще раз.");
            input = Console.ReadLine();
        }
        return valid;
    }
}