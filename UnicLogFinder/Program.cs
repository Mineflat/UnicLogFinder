namespace UnicLogFinder
{
    internal class Program
    {
        private static string HelpMessage = $"Использование: {Environment.CommandLine} [файл с json] [выходной файл]";
        private static bool CheckArgs(string[] args) => args.Length == 2;
        static void Main(string[] args)
        {
            if (CheckArgs(args))
            {
                List<LogEntity>? uniqueEntityes = ArgsParser.Parse(args[0]);
                if (uniqueEntityes != null && uniqueEntityes.Any())
                {
                    using (StreamWriter writer = new StreamWriter(args[1], true))
                    {
                        foreach (var entity in uniqueEntityes)
                        {
                            writer.WriteLine($"Level: {entity.level};\n\tError: {entity.error ?? "(пусто)"};\n\tMessage: {entity.msg};\n\tDate: {entity.time}\n");
                        }
                    }
                    Console.Write($"Файл '{args[0]}' был успешно пропаршен. Результат сохранен в ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{args[1]}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"В файле {args[1]} не обнаружено эвентов, подходящих под формат парсинга.\n" +
                        $"Правила парсинга:\n" +
                        $"\t1. Каждый эвент начинается с новой строки\n" +
                        $"\t2. Эвент является Json-структурой с полями \"time\", \"error\", \"msg\" и \"level\"");
                }
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(HelpMessage);
            }
        }
    }
}