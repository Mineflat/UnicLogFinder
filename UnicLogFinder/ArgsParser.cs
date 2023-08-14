using Newtonsoft.Json;

namespace UnicLogFinder
{
    internal static class ArgsParser
    {

        /// <summary>
        /// Метод используется для парсинга эвентов из файла. Каждый эвент начинается с новой строки и имеет формат JSON
        /// </summary>
        /// <param name="fullPath">Полный путь до файла с эвентами</param>
        /// <returns>Список эвентов (объектов класса <b>LogEntity</b>) или null</returns>
        public static List<LogEntity>? Parse(string fullPath)
        {
            string[] fileStrings = File.ReadLines(fullPath).ToArray();
            if (fileStrings.Length == 0) return null;

            List<LogEntity> uniqueStrings = new List<LogEntity>();
            LogEntity? lastDeserealizedLine;
            try
            {
                foreach (string line in fileStrings)
                {
                    lastDeserealizedLine = JsonConvert.DeserializeObject<LogEntity>(line);
                    if(lastDeserealizedLine != null)
                    {
                        if(uniqueStrings?.FirstOrDefault(x => x?.msg == lastDeserealizedLine?.msg) == null)
                        {
                            uniqueStrings?.Add(lastDeserealizedLine);
                        }
                    }
                }
            }
            catch (Exception fileParsingException)
            {
                Console.WriteLine(fileParsingException.Message);
                Environment.Exit(1);
            }
            return uniqueStrings;
        }
    }
}
