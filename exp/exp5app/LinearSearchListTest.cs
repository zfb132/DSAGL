using DSAGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp5app
{
    class LinearSearchListTest
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            int n = 10, k = 50, re;
            LinearSearchList<int> sl = new LinearSearchList<int>(n + 8);
            RandomizData(sl, n);
            sl[8] = 50;
            Console.Write("随机排列： "); sl.Show(true);
            timer.Start();
            sl.Sort();
            timer.Stop();
            Console.Write("排序后： ");  sl.Show(true);
            Console.WriteLine("Elapsed time = {0} Ticks", timer.ElapsedTicks);

            timer.Start();
            re = sl.BinarySearch(k, 0, n);
            timer.Stop();
            Console.WriteLine("二分法：k={0}, re={1}, i={2}", k, re, ~re);
            Console.WriteLine("Elapsed time = {0} Ticks", timer.ElapsedTicks);
            ///两种方法在有数据被找到时查找不一致
            timer.Start();
            re = sl.SequencedSearch(k,0,n);
            timer.Stop();
            Console.WriteLine("顺序法：k={0}, re={1}, i={2}", k, re, ~re);
            Console.WriteLine("Elapsed time = {0} Ticks", timer.ElapsedTicks);
        }

        public static void RandomizData(LinearSearchList<int> sl, int n)
        {
            int k;
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                k = random.Next(100);
                sl.Add(k);
            }
        }
    }
}
