using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAGL;
namespace exp3app
{
    class MatrixTest
    {
        static void Main(string[] args)
        {
            int[] m1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Matrix a = new Matrix(3, 3, m1); //a.Show();
            int[] m2 = { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
            Matrix b = new Matrix(3, 3, m2); //b.Show();
            a.Add(b); //a.Show();
            Matrix c = a + b;
            //c.Show();
        }
    }
}
