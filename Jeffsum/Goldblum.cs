using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Jeffsum.Tests")]

namespace Jeffsum
{
    /// <summary>
    /// Quickly receive Jeffsum for your application
    /// </summary>
    public static class Goldblum
    {
        static List<string> Quotes { get; set; }
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
        /// Receive Jeffsum in paragraph form.
        /// </summary>
        /// <param name="paragraphCount">Number of paragraphs that you would like between 1-99.</param>
        /// <returns>Jeffsum for specified paragraphs</returns>
        public static IEnumerable<string> ReceiveTheJeff(int paragraphCount)
        {
            if (!paragraphCount.ValidRange(1, 99))
                throw new ArgumentOutOfRangeException(nameof(paragraphCount), "You can only have between 1 and 99 Jeffs!");

            Init();

            var paragraphs = new List<string>();
            for (var i = 0; i < paragraphCount; i++)
                paragraphs.Add(BuildParagraph());

            return paragraphs;
        }

        static string BuildParagraph()
        {
            var sentenceCount = Random.Next(4, 6);
            var builder = new StringBuilder();
            for (var i = 0; i < sentenceCount; i++)
            {
                builder.Append(Quotes.ElementAt(Random.Next(0, Quotes.Count - 1)));
                if (i < sentenceCount - 1)
                    builder.Append(" ");
            }
            return builder.ToString();
        }

        internal static bool ValidRange(this int count, int min, int max) =>
            count >= min && count <= max;
    }
}
