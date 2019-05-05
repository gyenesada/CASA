using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASA
{
    class Matrix
    {
        List<List<int>>[,] values;
        int dimension;

        public Matrix(int size)
        {
            dimension = size;
            values = new List<List<int>>[dimension, dimension];

        }
    }
}
