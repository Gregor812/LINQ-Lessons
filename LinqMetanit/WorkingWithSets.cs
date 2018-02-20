using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMetanit
{
    public static class WorkingWithSets
    {
        public static void Example1()
        {
            var soft = new[] { "Microsoft", "Google", "Apple" };
            var hard = new[] { "Apple", "IBM", "Samsung" };

            var onlySoft = soft.Except(hard);

            foreach (var o in onlySoft)
                Console.WriteLine(o);
        }

        public static void Example2()
        {
            var soft = new[] { "Microsoft", "Google", "Apple" };
            var hard = new[] { "Apple", "IBM", "Samsung" };

            var bothSoftAndHard = soft.Intersect(hard);

            foreach (var b in bothSoftAndHard)
                Console.WriteLine(b);
        }

        public static void Example3()
        {
            var soft = new[] { "Microsoft", "Google", "Apple" };
            var hard = new[] { "Apple", "IBM", "Samsung" };

            var softAndHard = soft.Union(hard);

            foreach (var s in softAndHard)
                Console.WriteLine(s);
        }

        public static void Example4()
        {
            var soft = new[] { "Microsoft", "Google", "Apple" };
            var hard = new[] { "Apple", "IBM", "Samsung" };

            var softAndHardJoin = soft.Concat(hard);

            foreach (var s in softAndHardJoin)
                Console.WriteLine(s);
        }

        public static void Example5()
        {
            var soft = new[] { "Microsoft", "Google", "Apple" };
            var hard = new[] { "Apple", "IBM", "Samsung" };

            var softAndHard = soft.Concat(hard)
                                  .Distinct();

            foreach (var s in softAndHard)
                Console.WriteLine(s);
        }
    }
}
