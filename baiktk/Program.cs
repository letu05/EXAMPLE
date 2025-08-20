using System.Text;

namespace baiktk;

internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        var game = new GuessNumberGame();
        game.Run();
    }
}

internal sealed class GuessNumberGame
{
    private readonly Random random = Random.Shared;

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            WriteTitle("TRÒ CHƠI: ĐOÁN SỐ");
            Console.WriteLine("Hãy đoán số bí mật trong phạm vi cho trước.\n");

            var (min, max, maxAttempts) = AskForDifficulty();
            PlayRound(min, max, maxAttempts);

            Console.WriteLine();
            if (!AskToReplay())
            {
                Console.WriteLine("Cảm ơn bạn đã chơi! Nhấn Enter để thoát...");
                Console.ReadLine();
                break;
            }
        }
    }

    private static void WriteTitle(string text)
    {
        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(text);
        Console.WriteLine(new string('=', text.Length));
        Console.ForegroundColor = previousColor;
    }

    private (int min, int max, int attempts) AskForDifficulty()
    {
        Console.WriteLine("Chọn độ khó:");
        Console.WriteLine("  1) Dễ      (1 - 50, 10 lượt)");
        Console.WriteLine("  2) Vừa     (1 - 100, 8 lượt)");
        Console.WriteLine("  3) Khó     (1 - 500, 10 lượt)");
        Console.WriteLine("  4) Tùy chỉnh");

        while (true)
        {
            int choice = ReadIntInRange("Nhập lựa chọn (1-4): ", 1, 4);
            switch (choice)
            {
                case 1: return (1, 50, 10);
                case 2: return (1, 100, 8);
                case 3: return (1, 500, 10);
                case 4:
                    int min = ReadInt("Nhập số nhỏ nhất: ");
                    int max = ReadInt($"Nhập số lớn nhất (>{min}): ",
                        validate: v => v > min,
                        errorMessage: $"Giá trị phải lớn hơn {min}.");
                    int attempts = ReadInt("Nhập số lượt đoán (>=1): ",
                        validate: v => v >= 1,
                        errorMessage: "Số lượt phải >= 1.");
                    return (min, max, attempts);
            }
        }
    }

    private void PlayRound(int minInclusive, int maxInclusive, int maxAttempts)
    {
        int secretNumber = random.Next(minInclusive, maxInclusive + 1);
        int attemptsLeft = maxAttempts;

        Console.WriteLine();
        Console.WriteLine($"Máy đã chọn một số trong khoảng [{minInclusive}, {maxInclusive}].");
        Console.WriteLine($"Bạn có {maxAttempts} lượt đoán. Chúc may mắn!\n");

        while (attemptsLeft > 0)
        {
            int guess = ReadIntInRange($"Nhập dự đoán của bạn (còn {attemptsLeft} lượt): ", minInclusive, maxInclusive);

            if (guess == secretNumber)
            {
                WriteColored("Chính xác! Bạn đã đoán đúng số bí mật.", ConsoleColor.Green);
                return;
            }

            attemptsLeft--;
            int diff = Math.Abs(secretNumber - guess);

            if (guess < secretNumber)
            {
                WriteColored("Số cần tìm LỚN HƠN.", ConsoleColor.Yellow);
            }
            else
            {
                WriteColored("Số cần tìm NHỎ HƠN.", ConsoleColor.Yellow);
            }

            GiveHeatHint(diff);

            if (attemptsLeft == 0)
            {
                WriteColored($"Rất tiếc! Bạn đã hết lượt. Số bí mật là {secretNumber}.", ConsoleColor.Red);
            }
        }
    }

    private static void GiveHeatHint(int difference)
    {
        var (message, color) = difference switch
        {
            <= 3 => ("Rất gần!", ConsoleColor.Green),
            <= 10 => ("Khá gần.", ConsoleColor.DarkGreen),
            <= 25 => ("Hơi xa.", ConsoleColor.DarkYellow),
            _ => ("Xa lắm!", ConsoleColor.DarkRed)
        };

        WriteColored(message, color);
    }

    private static bool AskToReplay()
    {
        Console.Write("Chơi lại? (y/n): ");
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Vui lòng nhập 'y' hoặc 'n': ");
                continue;
            }

            input = input.Trim().ToLowerInvariant();
            if (input is "y" or "yes" or "c" or "co" or "có") return true;
            if (input is "n" or "no" or "k" or "ko" or "không") return false;

            Console.Write("Không hợp lệ. Nhập 'y' để chơi lại hoặc 'n' để thoát: ");
        }
    }

    private static int ReadInt(string prompt, Func<int, bool>? validate = null, string? errorMessage = null)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int value))
            {
                WriteColored("Giá trị không hợp lệ. Vui lòng nhập số nguyên.", ConsoleColor.Red);
                continue;
            }

            if (validate != null && !validate(value))
            {
                WriteColored(errorMessage ?? "Giá trị không hợp lệ.", ConsoleColor.Red);
                continue;
            }

            return value;
        }
    }

    private static int ReadIntInRange(string prompt, int minInclusive, int maxInclusive)
    {
        return ReadInt(prompt,
            validate: v => v >= minInclusive && v <= maxInclusive,
            errorMessage: $"Vui lòng nhập số trong khoảng [{minInclusive}, {maxInclusive}].");
    }

    private static void WriteColored(string message, ConsoleColor color)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = previous;
    }
}
