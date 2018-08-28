using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp6app
{
    class SortArrayTest
    {
        static void Main(string[] args)
        {
            int[] a = new int[20];
            RandomizeData(a, -99, 100);
            Console.WriteLine("第一次: ");
            Console.WriteLine("原数组: ");
            Show(a);
            Array.Sort(a);
            Console.WriteLine("值排序后数组: ");
            Show(a);

            Console.WriteLine("\n第二次: ");
            RandomizeData(a, -99, 100);
            Console.WriteLine("原数组: ");
            Show(a);
            Array.Sort(a, new AbsComparer());
            Console.WriteLine("绝对值排序后数组: ");
            Show(a);
        }

        private static void RandomizeData(int[] a, int minValue = -99, int maxValue = 100)
        {
            Random rd = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rd.Next(minValue, maxValue);
            }
        }
        private static void Show<T>(T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            { 
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
    class AbsComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return (Math.Abs(x)).CompareTo(Math.Abs(y));
        }
    }
}
