using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAGL;

namespace exp1app
{
    class ComplexTest
    {
        static void Main(string[] args)
        {
            Complex[] ca = new Complex[10];
            RandomizeData(ca, -10, 10);
            Show(ca);

            //int i = Array.IndexOf<Complex>(ca, new Complex());
            int i = Array.IndexOf<Complex>(ca, ca[5]);
            Console.WriteLine("{0}'s index is: {1}", ca[5], i);
            Console.WriteLine("Sorted Array: ");
            Array.Sort(ca);
            Show(ca);
        }

        private static void Show(Complex[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ; ");
            }
            Console.WriteLine();

        }

        private static void RandomizeData(Complex[] a, int minValue, int maxValue)
        {
            Random rd = new Random();
            int k = 0;
            for (int i = 0; i < a.Length; i++)
            {
                k = rd.Next(minValue, maxValue + 1);
                a[i] = new Complex(k * rd.NextDouble(), k * rd.NextDouble());
            }
        }
    }
}
