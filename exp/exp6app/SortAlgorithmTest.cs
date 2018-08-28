using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAGL;
using System.Diagnostics;

namespace exp6app
{
    class SortAlgorithmTest
    {
        public const int N = 8;
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            int[] a = { 70, 30, 12, 61, 80, 20, 97, 46 };
            int[] b = new int[N];
            //RandomizeData(a, -99, 100);
            Console.WriteLine("冒泡排序演示：");
            Sort<int>.Show(0, a);
            Array.Copy(a,b,N);
            timer.Start();
            Sort<int>.BubbleSort(b);
            timer.Stop();
            Console.WriteLine("消耗时间：{0}ms", timer.ElapsedMilliseconds);
            

            Console.WriteLine("\n堆排序演示：");
            Sort<int>.Show(0, a);
            Array.Copy(a, b, N);
            timer.Reset();
            timer.Start();
            Sort<int>.HeapSort(b);
            timer.Stop();
            Console.WriteLine("消耗时间：{0}ms", timer.ElapsedMilliseconds);

            Console.WriteLine("\n插入排序演示：");
            Sort<int>.Show(0, a);
            Array.Copy(a, b, N);
            timer.Reset();
            timer.Start();
            Sort<int>.InsertSort(b);
            timer.Stop();
            Console.WriteLine("消耗时间：{0}ms", timer.ElapsedMilliseconds);

            Console.WriteLine("\n二分插入排序演示：");
            Sort<int>.Show(0, a);
            Array.Copy(a, b, N);
            timer.Reset();
            timer.Start();
            Sort<int>.InsertSortBS(b);
            timer.Stop();
            Console.WriteLine("消耗时间：{0}ms", timer.ElapsedMilliseconds);


            Console.WriteLine("\n归并排序演示：");
            Sort<int>.Show(0, a);
            Array.Copy(a, b, N);
            timer.Reset();
            timer.Start();
            Sort<int>.MergeSort(b);
            timer.Stop();
            Console.WriteLine("消耗时间：{0}ms", timer.ElapsedMilliseconds);

            Console.WriteLine("\n快速排序演示：");
            Sort<int>.Show(0, a);
            Array.Copy(a, b, N);
            timer.Reset();
            timer.Start();
            Sort<int>.QuickSort(b, 0, N - 1);
            timer.Stop();
            Console.WriteLine("消耗时间：{0}ms", timer.ElapsedMilliseconds);

            Console.WriteLine("\n选择排序演示：");
            Sort<int>.Show(0, a);
            Array.Copy(a, b, N);
            timer.Reset();
            timer.Start();
            Sort<int>.SelectSort(b);
            timer.Stop();
            Console.WriteLine("消耗时间：{0}ms", timer.ElapsedMilliseconds);

            Console.WriteLine("\n希尔排序演示：");
            Sort<int>.Show(0, a);
            Array.Copy(a, b, N);
            timer.Reset();
            timer.Start();
            Sort<int>.ShellSort(b);
            timer.Stop();
            Console.WriteLine("消耗时间：{0}ms", timer.ElapsedMilliseconds);
        }

        private static void RandomizeData(int[] a, int minValue = -99, int maxValue = 100)
        {
            Random rd = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rd.Next(minValue, maxValue);
            }
        }
    }
}
