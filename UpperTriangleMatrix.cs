using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * -1 - default not found
 *  0 - nincs él
 *  1 - van, fekete
 *  2 - van, eredeti út
 *  3 - van, kerülő
 */

namespace CASA
{
    class UpperTriangleMatrix
    {
        Dictionary<Point, int> Values = new Dictionary<Point, int>();

        public int this[Point p]
        {
            get
            {
                if (Values.Keys.Contains(new Point(p.X, p.Y)) || Values.Keys.Contains(new Point(p.Y, p.X)))
                {
                    if (p.X > p.Y)
                    {
                        return Values[new Point(p.Y, p.X)];
                    }
                    return Values[p];
                }else
                {
                    return -1;
                }
            }
            set
            {
                if(p.X > p.Y)
                {
                    Values[new Point(p.Y, p.X)] = value;
                    return;
                }
                Values[p] = value;
            }
        }

        public List<Point> getValues()
        {
            List<Point> edges = new List<Point>();
            foreach(var v in Values)
            {
                if(v.Value == 1) edges.Add(v.Key);
            }
            return edges;
        }

        public List<Point> getEnabledValues()
        {
            List<Point> edges = new List<Point>();
            foreach(var v in Values)
            {
                if(v.Value == 0) edges.Add(v.Key);
            }

            return edges;
        }

       public void Clear()
        {
            Values.Clear();
        }
    }
}
