using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentGroupSystem.Models;

namespace StudentGroupSystem.Services
{
    public class TextProcessor
    {
        public string Reverse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var sb = new StringBuilder(input.Length);

            for (int i = input.Length - 1; i >= 0; i--)
                sb.Append(input[i]);

            return sb.ToString();
        }

        public int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            var normalized = Normalize(text);
            return normalized.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public int CountCharacters(string text, bool ignoreWhitespace = true)
        {
            if (text == null)
                return 0;

            if (ignoreWhitespace)
                return text.Count(c => !char.IsWhiteSpace(c));

            return text.Length;
        }

        public string Normalize(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var trimmed = text.Trim();
            while (trimmed.Contains("  "))
                trimmed = trimmed.Replace("  ", " ");

            return trimmed;
        }

        public bool IsPalindrome(string text, bool ignoreCase = true, bool ignoreSpaces = true)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (ignoreSpaces)
                text = text.Replace(" ", "");

            if (ignoreCase)
                text = text.ToLower();

            var reversed = Reverse(text);
            return text == reversed;
        }

        public string ReplaceMultiple(string text, Dictionary<string, string> replacements)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var sb = new StringBuilder(text);

            foreach (var pair in replacements)
                sb.Replace(pair.Key, pair.Value);

            return sb.ToString();
        }

        public string[] SplitIntoSentences(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return Array.Empty<string>();

            return text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(s => s.Trim())
                       .ToArray();
        }

        public string BuildGroupReport(StudentGroup group)
        {
            var sb = new StringBuilder();

            sb.AppendLine("=== Звіт групи ===");
            sb.AppendLine($"Кількість студентів: {group.Students.Count}");
            sb.AppendLine();

            foreach (var student in group.Students)
            {
                sb.AppendLine(student.GetFormattedInfo(detailed: true));
                sb.AppendLine("---------------------------");
            }

            return sb.ToString();
        }

        public string ComparePerformance(int iterations)
        {
            var sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            string s = "";
            for (int i = 0; i < iterations; i++)
                s += "x";
            sw.Stop();
            var stringTime = sw.ElapsedMilliseconds;

            sw.Reset();
            sw.Start();
            var sb = new StringBuilder();
            for (int i = 0; i < iterations; i++)
                sb.Append("x");
            sw.Stop();
            var sbTime = sw.ElapsedMilliseconds;

            return $"string: {stringTime} ms\nStringBuilder: {sbTime} ms";
        }
    }
}
