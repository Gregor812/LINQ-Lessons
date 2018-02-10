using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBase
{
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point p)
                return X == p.X && Y == p.Y;
            return false;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public static List<Point> ParsePoints(IEnumerable<string> lines)
        {
            return lines
                  .Select(l =>
                  {
                      var position = l
                                    .Split(' ')
                                    .Select(int.Parse)
                                    .ToArray();
                      return new Point(position[0], position[1]);
                  })
                  .ToList();
        }

        public static IEnumerable<Point> GetNeighbours(Point p)
        {
            int[] d = { -1, 0, 1 }; // используйте подсказку, если не понимаете зачем тут этот массив :)
            return d.SelectMany(dx => d.Select(dy => new Point(p.X + dx, p.Y + dy))).Where(point => !point.Equals(p));
        }
    }
}
