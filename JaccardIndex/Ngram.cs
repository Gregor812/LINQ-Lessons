using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaccardIndex
{
    public struct Ngram
    {
        public readonly string[] Words;
        public int N
        {
            get => Words.Length;
        }

        public Ngram(string[] words)
        {
            if (words == null || words.Length == 0)
                throw new ArgumentException("Ngram ctor: words array is null or empty");

            Words = words;
        }
    }
}
