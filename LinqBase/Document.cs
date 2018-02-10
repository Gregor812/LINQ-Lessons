using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinqBase
{
    public class Document
    {
        public int Id;
        public string Text;

        public static ILookup<string, int> BuildInvertedIndex(Document[] documents)
        {
            return documents.SelectMany(doc => Regex.Split(doc.Text, @"\W+")
                                                    .Where(word => !string.IsNullOrWhiteSpace(word))
                                                    .Select(word => Tuple.Create(word.ToLowerInvariant(), doc.Id))
                                                    .Distinct())
                            .ToLookup(tuple => tuple.Item1, tuple => tuple.Item2);
        }

        public static void SearchQuery(string v, ILookup<string, int> index)
        {
            var finded = index[v].ToList();
            foreach (var f in finded)
                Console.WriteLine(f);
        }
    }
}
