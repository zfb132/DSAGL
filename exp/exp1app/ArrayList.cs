using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp1app
{
    //namespace HelloWorld
    //{
    //    class ArrayTest
    //    {
    //        // 定义数组长度
    //        public static int LENGTH = 20;
    //        public static int MIN = -99;
    //        public static int MAX = 99;
    //        public static void Main(String[] args)
    //        {
    //            // 创建并初始化一个新数组
    //            int[] arrayTest = new int[LENGTH];
    //            Random r = new Random();
    //            for (int i = 0; i < LENGTH; i++)
    //            {
    //                arrayTest[i] = r.Next(MIN, MAX);
    //            }
    //        }

    //        // 查找特定数据
    //        // 只返回第一个查找到的数据位置
    //        public int findNum(int num,int[] arrayName)
    //        {
    //            // 若无匹配项返回-1
    //            int index = -1;
    //            for(int i=0;i<arrayName.Length;i++)
    //            {
    //                if(arrayName[i]==num)
    //                {
    //                    index = i;
    //                    break;
    //                }
    //            }
    //            return index;
    //        }

    //        // 对数组排序
    //        public void sortArray(ref int[] arrayName)
    //        {
    //            for(int i=0;i<arrayName.Length;i++)
    //            {
    //                for(int t=0;t<arrayName.Length-i-1;t++)
    //                {
    //                    if (arrayName[t] > arrayName[t + 1])
    //                    {
    //                        int temp = arrayName[t];
    //                        arrayName[t] = arrayName[t + 1];
    //                        arrayName[t + 1] = temp;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
    // Random() 新实例初始化 Random 类，使用依赖于时间的默认种子值。
    // Random(Int32) 新实例初始化 Random 类，使用指定的种子值。
    // Next() 返回一个非负随机整数。
    // Next(Int32) 返回一个小于所指定最大值的非负随机整数。
    // Next(Int32, Int32) 返回在指定范围内的任意整数。
    // NextBytes(Byte[]) 用随机数填充指定字节数组的元素。
    // NextDouble() 返回一个大于或等于 0.0 且小于 1.0 的随机浮点数。
    // Sample() 返回一个介于 0.0 和 1.0 之间的随机浮点数。

    // Array方法
    // Array.IndexOf<T>(arrayName,value)
    // Array.Sort()
    // arrayName.Min()

    class ArrayTest
    {
        static void Main(string[] args)
        {
            int[] a = new int[20];

            RandomizeData(a);	
            Show(a);           

            int i = Array.IndexOf<int>(a, 10);
            Console.WriteLine("10's index is: {0}", i);
            Console.WriteLine("Min of the array is {0}", a.Min());
            Console.WriteLine("Sorted Array: ");
            Array.Sort(a);
            Show(a);

            RandomizeData(a, -99, 100);
            Show(a);
            Console.WriteLine("Sorted by Absolute Value: ");
            Array.Sort(a, new AbsComparer());
            Show(a);

            ArrayList l = new ArrayList();
            l.Add(100); l.Add(5);
        }

        private static void Show(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            { //数组的Length属性告知数组元素个数 
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();

        }

        private static void RandomizeData(int[] a, int minValue = -99, int maxValue = 100)
        {
            Random rd = new Random();        //面向对象，需要随机数就找Random对象

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rd.Next(minValue, maxValue);
            }
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
