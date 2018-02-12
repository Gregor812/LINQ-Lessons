using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinqBase
{
    public struct Document
    {
        public int Id;
        public string Text;
    }

    public struct WordPosition
    {
        public string Word;
        public int[] DocumentId;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{Word}: ");
            foreach (var d in DocumentId)
                sb.Append(d).Append("; ");

            return sb.ToString().TrimEnd();
        }

        public int this[int index]
        {
            get => DocumentId[index];
        }
    }

    public static class InvertedIndex
    {
        public static ILookup<string, WordPosition> BuildInvertedIndex(Document[] documents)
        {
            var wordToIdTuples = documents.SelectMany(doc => Regex.Split(doc.Text, @"\W+")
                                                              .Where(word => !string.IsNullOrWhiteSpace(word))
                                                              .Select(word => Tuple.Create(word.ToLowerInvariant(), doc.Id)));
            var uniqueTuples = wordToIdTuples.Distinct();
            var groupedByWordTuples = uniqueTuples.GroupBy(t => t.Item1);

            return groupedByWordTuples.ToLookup(group => group.Key, group => new WordPosition
                                                                             {
                                                                                 Word = group.Key,
                                                                                 DocumentId = group.SelectMany(t => group.Select(tu => tu.Item2))
                                                                                                   .Distinct()
                                                                                                   .ToArray()
                                                                             });
        }

        public static void SearchQuery(string v, ILookup<string, WordPosition> index)
        {
            var finded = index[v].ToList();
            foreach (var f in finded)
                Console.WriteLine(f);
        }
    }


}
