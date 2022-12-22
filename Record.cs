namespace ConsoleApp11
{
    internal class Record
    {
        public static void Table()
        {
            Console.WriteLine("Введите имя для таблицы рекордов: ");
            string name = Console.ReadLine();
            Console.Clear();

            int index = TapTap.TypingTest("");

            List<User> users = User.Serializing(name, index);

            Console.WriteLine("Таблица рекордов: ");
            Console.WriteLine(new string('=', 18));

            foreach (User item in users)
            {
                Console.WriteLine($"{item.Name}\t{item.CharsPerMinute} символов в минуту");
            }

            Console.WriteLine("Чтобы пройти тест заново - нажмите Enter");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                Table();
            }
        }
    }
}
