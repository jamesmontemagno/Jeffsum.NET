using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("Jeffsum.Tests")]

namespace Jeffsum
{
    /// <summary>
    /// Quickly receive Jeffsum for your application
    /// </summary>
    public static class Goldblum
    {
        static List<string> Quotes { get; set; }
        static List<string> Sentences { get; set; }
        static List<string> Words { get; set; }
        static Random Random { get; } = new Random();
        static void Init()
        {
            if (Quotes != null)
                return;

            var assembly = typeof(Goldblum).GetTypeInfo().Assembly;
            var resourceName = "Jeffsum.quotes.csv";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    Quotes = new List<string>(reader.ReadToEnd()
                        .Replace("\"", string.Empty)
                        .Split(new[] { "\r\n" },
                        StringSplitOptions.RemoveEmptyEntries));

                }
            }
        }

        /// <summary>
        /// Receive a specific amount of Jeffsum.
        /// </summary>
        /// <param name="count">Number of jeffsums that you would like between 1-99.</param>
        /// <returns>Jeffsum for specified count</returns>
        public static IEnumerable<string> ReceiveTheJeff(int count, JeffsumType jeffsumType = JeffsumType.Paragraphs)
        {
            if (!count.ValidRange(1, 99))
                throw new ArgumentOutOfRangeException(nameof(count), "You can only have between 1 and 99 Jeffs!");

            Init();

            return ReceiveTheJeffsIterator(count, jeffsumType);                       
        }

        static IEnumerable<string> ReceiveTheJeffsIterator(int count, JeffsumType jeffsumType)
        {
            switch (jeffsumType)
            {
                case JeffsumType.Words:

                    for (var i = 0; i < count; i++)
                    {
                        var words = GetQuote()
                               .Replace(".", "")
                               .Replace(",", "")
                               .Replace("?", "")
                               .Replace("!", "")
                               .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                        yield return words[Random.Next(0, words.Length - 1)];
                    }
                    break;
                case JeffsumType.Quotes:
                    for (var i = 0; i < count; i++)
                        yield return GetQuote();
                    break;
                case JeffsumType.Paragraphs:
                    var paragraphs = new List<string>();
                    for (var i = 0; i < count; i++)
                        yield return BuildParagraph();
                    break;
            }
        }

        static string BuildParagraph()
        {
            var sentenceCount = Random.Next(4, 6);
            var builder = new StringBuilder();
            for (var i = 0; i < sentenceCount; i++)
            {
                builder.Append(GetQuote());
                if (i < sentenceCount - 1)
                    builder.Append(" ");
            }
            return builder.ToString();
        }

        static string GetQuote() => Quotes.ElementAt(Random.Next(0, Quotes.Count - 1));

        internal static bool ValidRange(this int count, int min, int max) =>
            count >= min && count <= max;
    }
}
