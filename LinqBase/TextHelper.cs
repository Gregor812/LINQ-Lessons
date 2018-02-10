using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinqBase
{
    public static class TextHelper
    {
        public static string[] GetSortedWords(params string[] textLines)
        {
            return textLines.SelectMany(line => line.Split(new[] { ' ', ',', ';', '.', '\'' },
                                                           StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(s => s.ToLowerInvariant()))
                            .Distinct()
                            .OrderBy(s => s)
                            .ToArray();
        }

        public static List<string> GetSortedWords(string text)
        {
            return Regex.Split(text, @"\W+")
                        .Where(s => !string.IsNullOrWhiteSpace(s))
                        .Select(s => s.ToLowerInvariant())
                        .Distinct()
                        .OrderBy(s => Tuple.Create(s.Length, s))
                        .ToList();
        }

        public static string GetLongestWord(IEnumerable<string> words)
        {
            return words.Where(w => w.Length == words.Max(wl => wl.Length))
                        .Min(w => w);
        }

        public static Tuple<string, int>[] GetMostFrequentWords(string text, int count)
        {
            return Regex.Split(text, @"\W+")
                        .Where(word => !string.IsNullOrWhiteSpace(word))
                        .Select(word => word.ToLowerInvariant())
                        .GroupBy(word => word)
                        .Select(group => Tuple.Create(group.Key, group.Count()))
                        .OrderByDescending(t => t.Item2)
                        .ThenBy(t => t.Item1)
                        .Take(count)
                        .ToArray();
        }
    }
}
