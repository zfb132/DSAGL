using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp5app
{
    class SearchInArray
    {
        public const int N = 5000;
        static void Main(string[] args)
        {
            int[] a = new int[N];
            int result = 0;
            int[] test = { 5, 15, 25, 35, 45, 55, 65,
                75, 85, 95, 105, 115, 125,
                135, 145, 155, 165, 175, 185, 195 };
            RandomizeData(a, 0, 999);
            Array.Sort(a);
            Show(a);
            //在有重复数值时，两种方法查找会不一样
            foreach(var k in test)
            {
                result = SequencedSearch(a, k, 0, N);
                Console.WriteLine("顺序法：k={0}, re={1}, i={2}", k, result, ~result);
                result = BinarySearch(a, k, 0, N);
                Console.WriteLine("二分法：k={0}, re={1}, i={2}", k, result, ~result);
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// <para>顺序查找k值在线性表中的位置，查找成功时返回k值首次出现位置，否则返回应插入位置的反码</para>
        /// <para>查找范围:从下标si开始，包含length个元素</para>
        /// </summary>
        public static int SequencedSearch(int[] a,int k, int si, int length)
        {
            int time = length + si;
            int i, location = si;
            for (i = si; i < time; i++)
            {
                switch (k.CompareTo(a[i]))
                {
                    case 1: location++; break;
                    case 0: return i;
                    case -1: break;
                    default: break;
                }
            }
            return ~location;
        }

        /// <summary>
        /// <para>二分查找k值在线性表中的位置，查找成功时返回k值首次出现位置，否则返回应插入位置的反码</para>
        /// <para>查找范围:从下标si开始，包含length个元素</para>
        /// </summary>
        public static int BinarySearch(int[] a, int k, int si, int length)
        {
            int mid = 0, left = si;
            int right = left + length - 1;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (k.CompareTo(a[mid]) == 0)
                    return mid;
                else if (k.CompareTo(a[mid]) < 0)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            if (k.CompareTo(a[mid]) > 0)
                mid++;
            return ~mid;
        }

        private static void Show(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            { //数组的Length属性告知数组元素个数 
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();

        }

        /// <summary>
        /// 初始化数组的每个元素为指定范围内的随机数
        /// </summary>
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
