using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp11
{
    internal class TapTap
    {
        static string[] texts = new string[10];
        public static int TypingTest(string textsFile)
        {
            char[] text = GetText();
            foreach (char letter in text)
            {
                Console.Write(letter);
            }

            int LetterNum = 0;
            Console.WriteLine(texts[LetterNum]);
            Console.WriteLine(new string('=', 31));
            Console.WriteLine("Нажмите Enter для запуска теста");
            Console.SetCursorPosition(0, 0);

            ConsoleKeyInfo key = Console.ReadKey();

            int index = 0;

            if (key.Key == ConsoleKey.Enter)
            {
                Thread timer = new((_) =>
                {
                    Stopwatch stopwatch = new();
                    Stopwatch timer = stopwatch;
                    timer.Start();
                    TimeSpan ts;

                    do
                    {
                        ts = timer.Elapsed;
                        string elapsedTime = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

                        Console.SetCursorPosition(0, texts.Length / Console.WindowWidth + 8);
                        Console.WriteLine("Время: " + elapsedTime);
                        Thread.Sleep(1000);

                    } while (ts.Seconds <= 30);

                    Console.SetCursorPosition(0, texts.Length / Console.WindowWidth + 5);
                    Console.WriteLine("Стооооооооооп");
                });

                timer.Start();

                do
                {
                    ConsoleKeyInfo letter = Console.ReadKey(true);

                    if (letter.KeyChar == text[index])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(index, index / Console.WindowWidth);
                        Console.Write(letter.KeyChar);
                        Console.ForegroundColor = ConsoleColor.White;

                        index++;
                    }

                } while (timer.IsAlive);

                Thread.Sleep(1000);
                Console.SetCursorPosition(0, text.Length / Console.WindowWidth + 5);
                Console.WriteLine("Для продолжения нажмите любую кнопку");
                
                Console.ReadKey();

                Console.Clear();
            }

            return index;
        }
        private static char[] GetText()
        {
            string text = "Хороший сценарий может легко стать твоим самым страшным врагом и доставить тебе значительно больше проблем, чем плохой. Когда ты получаешь плохой сценарий, ты изо всех сил пытаешься сделать его лучше. И так ты незаметно для самого себя вкладываешь в него свою душу. А потом ты получаешь хороший сценарий и расплываешься в улыбке, потому что думаешь, что он все сделает за тебя сам — ведь он же хороший. И вот здесь ты попался. Ведь только что ты как будто сказал себе: я не буду вкладывать в этот сценарий свою душу, пусть он работает сам.";
            char[] chars = text.ToCharArray();

            return chars;
        }
    }
}
