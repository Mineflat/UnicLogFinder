using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;


namespace UnicLogFinder
{
    internal class LogEntity
    {
        public string? time { get; set; }
        public string? error { get; set; }
        public string? msg { get; set; }
        public string? level { get; set; }
    }
}
