using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StudentGroupSystem.Services
{
    public class AdvancedLogger
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public void Log(string level, string message)
        {
            var entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            _sb.AppendLine(entry);
        }

        public void SaveToFile(string path)
        {
            File.WriteAllText(path, _sb.ToString());
        }

        public string GetLogsByLevel(string level)
        {
            var lines = _sb.ToString()
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Where(l => l.Contains($"[{level}]"));

            return string.Join("\n", lines);
        }

        public void Clear()
        {
            _sb.Clear();
        }

        public string GetLast(int count)
        {
            var lines = _sb.ToString()
                .Split('\n', StringSplitOptions.RemoveEmptyEntries);

            return string.Join("\n", lines.TakeLast(count));
        }
    }
}
