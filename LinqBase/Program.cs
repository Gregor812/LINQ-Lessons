using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinqBase
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectExercises();

            foreach (var num in ParseNumbers(new[] { "-0", "+0000" }))
                Console.WriteLine(num);
            foreach (var num in ParseNumbers(new List<string> { "1", "", "-03", "0" }))
                Console.WriteLine(num);

            foreach (var point in Point.ParsePoints(new[] { "1 -2", "-3 4", "0 2" }))
                Console.WriteLine(point.X + " " + point.Y);
            foreach (var point in Point.ParsePoints(new List<string> { "+01 -0042" }))
                Console.WriteLine(point.X + " " + point.Y);

            var words = new[] { "ab", "", "c", "de" };
            var letters = words.SelectMany(w => w).ToList(); //IEnumerable<char> letters = words.SelectMany(w => w.ToCharArray()); -- the same

            Classroom[] classes =
            {
                new Classroom {Students = {"Pavel", "Ivan", "Petr"},},
                new Classroom {Students = {"Anna", "Ilya", "Vladimir"},},
                new Classroom {Students = {"Bulat", "Alex", "Galina"},}
            };
            var allStudents = Classroom.GetAllStudents(classes);
            Array.Sort(allStudents);
            Console.WriteLine(string.Join(" ", allStudents));

            var p = new Point(0, 0);
            var neighbours = Point.GetNeighbours(p);

            var gridDots = new[] { 1, 2, 3, 4, 5 }.SelectMany(left => new[] { 1, 2, 3, 4, 5 }.Select(right => new[] { left, right })).ToArray(); // Cartesian multiply

            var text = new[]
            {
                "Hello, hello, hello, how low",
                "",
                "With the lights out, it's less dangerous",
                "Here we are now; entertain us",
                "I feel stupid and contagious",
                "Here we are now; entertain us",
                "A mulatto, an albino, a mosquito, my libido...",
                "Yeah, hey"
            };

            var vocabulary = TextHelper.GetSortedWords(text);
            foreach (var word in vocabulary)
                Console.WriteLine(word);

            var sortedWords = TextHelper.GetSortedWords(string.Join(" ", text));
            foreach (var word in sortedWords)
                Console.WriteLine(word);

            IEnumerable<int> nums = new int[] { 8, 9, 0, 1, 2, 3, 4, 5, 6, 7 };

            Console.WriteLine(nums.Count());

            Console.WriteLine(nums.Min());

            words = new[] { "hi", "kitty" };

            Console.WriteLine(words.Select(word => word.Length).Max());
            // the same
            Console.WriteLine(words.Max(word => word.Length));

            Console.WriteLine(nums.Average(n => n * n));

            var numbers = new[] { 1, 2, 6, 2, 8, 0, 10, 6, 1, 2 };

            Console.WriteLine(numbers.All(n => n >= 0));
            Console.WriteLine(numbers.All(n => n % 2 == 0));

            Console.WriteLine(numbers.Any(n => n == 0));
            Console.WriteLine(numbers.Any(n => n < 0));

            Console.WriteLine(TextHelper.GetLongestWord(new[] { "azaz", "as", "sdsd" }));
            Console.WriteLine(TextHelper.GetLongestWord(new[] { "zzzz", "as", "sdsd" }));
            Console.WriteLine(TextHelper.GetLongestWord(new[] { "as", "12345", "as", "sds" }));

            var mostFrequentWords = TextHelper.GetMostFrequentWords(string.Join(" ", text), 8);
            foreach (var w in mostFrequentWords)
                Console.WriteLine(w);

            string[] names = { "Pavel", "Peter", "Andrew", "Anna", "Alice", "John" };

            var namesByLetter = new Dictionary<char, List<string>>();
            foreach (var group in names.GroupBy(name => name[0]))
                namesByLetter.Add(group.Key, group.ToList());

            foreach (var n in namesByLetter['J'])
                Console.WriteLine(n);
            foreach (var n in namesByLetter['P'])
                Console.WriteLine(n);
            Console.WriteLine(namesByLetter.ContainsKey('Z'));

            // the same
            namesByLetter = names.GroupBy(name => name[0])
                                 .ToDictionary(group => group.Key, group => group.ToList());

            foreach (var n in namesByLetter['J'])
                Console.WriteLine(n);
            foreach (var n in namesByLetter['P'])
                Console.WriteLine(n);
            Console.WriteLine(namesByLetter.ContainsKey('Z'));

            // and the same
            var namesByLetterLookup = names.ToLookup(name => name[0], name => name.ToLower());
            foreach (var n in namesByLetterLookup['J'])
                Console.WriteLine(n);
            foreach (var n in namesByLetterLookup['P'])
                Console.WriteLine(n);
            Console.WriteLine(namesByLetterLookup['Z'].Count());

            Document[] documents =
            {
                new Document {Id = 1, Text = "Hello world!"},
                new Document {Id = 2, Text = "World, world, world... Just words..."},
                new Document {Id = 3, Text = "Words — power"},
                new Document {Id = 4, Text = ""}
            };
            var index = InvertedIndex.BuildInvertedIndex(documents);
            InvertedIndex.SearchQuery("world", index);
            InvertedIndex.SearchQuery("words", index);
            InvertedIndex.SearchQuery("power", index);
            InvertedIndex.SearchQuery("cthulhu", index);
            InvertedIndex.SearchQuery("", index);
        }

        private static void SelectExercises()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNumbers = numbers
                             .Where(n => (n % 2) == 0)
                             .ToList();

            var evenSquares = evenNumbers
                             .Select(e => e * e)
                             .ToList();

            var firstFive = numbers
                           .Take(5)
                           .ToList();

            var lastFive = numbers
                          .Reverse()
                          .Take(5)
                          .Reverse()
                          .ToList();

            var exceptFirstFive = numbers
                                 .Skip(5)
                                 .ToList();

            var exceptLastFive = numbers
                                .Reverse()
                                .Skip(5)
                                .Reverse()
                                .ToList();
        }

        public static int[] ParseNumbers(IEnumerable<string> lines)
        {
            return lines
                  .Where(l => int.TryParse(l, out _))
                  .Select(i => int.Parse(i))
                  .ToArray();
        }
    }
}
