using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    public class Sort<T> where T : IComparable
    {
        /// <summary>
        /// 直接插入排序分趟将待排序的数据依次有序地插入成一个有序的数据序列
        /// <para>时间复杂度为O(n^2)</para>
        /// <para>空间复杂度为O(1)</para>
        /// <para>稳定排序</para>
        /// </summary>
        public static void InsertSort(T[] items)
        {
            T k;
            int i, j, m;
            int n = items.Length;
            for (m = 1; m < n; m++)
            {
                k = items[m];
                for (i = 0; i < m; i++)
                {
                    if (k.CompareTo(items[i]) < 0)
                    {
                        for (j = m; j > i; j--)
                            items[j] = items[j - 1];
                        items[i] = k;
                        break;
                    }
                }
                Show(m, items);
            }
        }
        /// <summary>
        /// 用二分查找算法代替顺序查找算法完成在有序表中查找的工作
        /// <para>时间复杂度为O(n^2)</para>
        /// <para>空间复杂度为O(1)</para>
        /// <para>稳定排序</para>
        /// </summary>
        public static void InsertSortBS(T[] items)
        {
            T k;
            int i, j, m, n = items.Length;
            for (m = 1; m < n; m++)
            {
                k = items[m];
                i = Array.BinarySearch<T>(items, 0, m, k);
                if (i < 0)
                    i = ~i;
                else
                {
                    //见讲义第九页（或PPT第22页）
                    //ERROR:此处需要初始化，否则可能找不到而无法退出循环
                    i = 0;
                    while (k.Equals(items[i]))
                        i++;
                }
                for (j = m; j > i; j--)
                    items[j] = items[j - 1];
                items[i] = k;
                Show(m, items);
            }
        }
        /// <summary>
        /// <para>先将整个序列分割成若干子序列分别进行排序</para>
        /// <para>待整个序列基本有序时，再进行全序列直接插入排序</para>
        /// <para>时间复杂度为O(n(log2n)^2)</para>
        /// <para>空间复杂度为O(1)</para>
        /// <para>不稳定排序</para>
        /// </summary>
        public static void ShellSort(T[] items)
        {
            T t;
            int n = items.Length, jump = n / 2;
            int i, j, m = 1;
            while (jump > 0)
            {
                for (i = jump; i < n; i++)
                {
                    j = i - jump;
                    while (j >= 0)
                    {
                        if (items[j].CompareTo(items[j + jump]) > 0)
                        {
                            t = items[j];
                            items[j] = items[j + jump];
                            items[j + jump] = t;
                            j -= jump;
                        }
                        else
                            j = -1;
                    }
                }
                Console.Write("jump=" + jump + " ");
                Show(m, items); m++;
                jump /= 2;
            }
        }
        /// <summary>
        /// 依次比较相邻的两个数据元素的关键字值，如果反序，则交换它们的位置
        /// <para>经过一趟交换排序后，具有大值的数据元素将移到序列的最后位置</para>
        /// <para>平均时间复杂度为O(n^2)</para>
        /// <para>空间复杂度为O(1)</para>
        /// <para>稳定排序</para>
        /// </summary>
        public static void BubbleSort(T[] items)
        {
            T t; int n = items.Length;
            bool exchanged;
            for (int m = 1; m < n; m++)
            {
                exchanged = false;
                for (int j = 0; j < n - m; j++)
                {
                    if (items[j].CompareTo(items[j + 1]) > 0)
                    {
                        t = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = t;
                        exchanged = true;
                    }
                }
                Show(m, items);
                if (!exchanged)
                    break;
            }
        }
        /// <summary>
        /// 将长序列以其中的某值为基准pivot分成两个独立的子序列
        /// <para>第一个子序列中的所有元素的关键字均比pivot小</para>
        /// <para>第二个子序列所有元素的关键字值则均比pivot大</para>
        /// <para>以相同的方法分别对两个子序列继续进行排序</para>
        /// <para>平均时间复杂度为O(nlog2n)</para>
        /// <para>空间复杂度为O(log2n)</para>
        /// <para>不稳定排序</para>
        /// </summary>
        public static void QuickSort(T[] items, int nLower, int nUpper)
        {
            if (nLower < nUpper)
            {
                int nSplit = Partition(items, nLower, nUpper);
                Console.Write("left=" + nLower + " right=" + nUpper + " Pivot=" + nSplit + "\t");
                Show(0, items);
                QuickSort(items, nLower, nSplit - 1);
                QuickSort(items, nSplit + 1, nUpper);
            }
        }
        /// <summary>
        /// 选取子序列的第一个元素为基准值pivot进行一趟排序
        /// </summary>
        private static int Partition(T[] items, int nLower, int nUpper)
        {
            T t, pivot = items[nLower];
            int nLeft = nLower + 1;
            int nRight = nUpper;
            while (nLeft <= nRight)
            {
                while (nLeft <= nRight && (items[nLeft]).CompareTo(pivot) <= 0)
                    nLeft = nLeft + 1;
                while (nLeft <= nRight && (items[nRight]).CompareTo(pivot) > 0)
                    nRight = nRight - 1;
                if (nLeft < nRight)
                {
                    t = items[nLeft];
                    items[nLeft] = items[nRight];
                    items[nRight] = t;
                    nLeft = nLeft + 1;
                    nRight = nRight - 1;
                }
            }
            t = items[nLower];
            items[nLower] = items[nRight];
            items[nRight] = t;
            return nRight;
        }
        /// <summary>
        /// 依次选择出待排序数据中的小者使其排列有序
        /// <para>时间复杂度为O(n^2)</para>
        /// <para>空间复杂度为O(1)</para>
        /// <para>稳定排序</para>
        /// </summary>
        public static void SelectSort(T[] items)
        {
            T t;
            int min, n = items.Length;
            for (int m = 1; m < n; m++)
            {
                min = m - 1;
                for (int j = m; j < n; j++)
                {
                    if (items[j].CompareTo(items[min]) < 0)
                        min = j;
                }
                if (min != m - 1)
                {
                    t = items[m - 1];
                    items[m - 1] = items[min];
                    items[min] = t;
                }
                Console.Write("min=" + min + " ");
                Show(m, items);
            }
        }
        /// <summary>
        /// 在每次选择小或大值时，利用以前的比较结果以提高排序的速度
        /// <para>平均时间复杂度为O(nlog2n)</para>
        /// <para>空间复杂度为O(1)</para>
        /// <para>不稳定排序</para>
        /// </summary>
        public static void HeapSort(T[] items)
        {
            T t;
            int i, n = items.Length;
            //WARNING:添加堆排序控制台显示
            int index = 1;
            for (i = (n - 1) / 2; i >= 0; i--)
            {   
                //从最后一个非终端结点建大顶堆 
                HeapAdjust(items, i, n);
                Show(index, items);
                index++;
            }
            for (i = n - 1; i > 1; i--)
            {
                t = items[0];
                items[0] = items[i];
                //根(最大)值交换到后面 
                items[i] = t;
                //调整成堆
                HeapAdjust(items, 0, i);                   
            }
            Show(index, items);
        }
        /// <summary>
        /// 将待排序序列建成堆
        /// </summary>
        private static void HeapAdjust(T[] items, int s, int m)
        {
            int i = s; int j = 2 * i + 1;        //第j个元素是第i个元素的左孩子 
            T t = items[i];               //获得第i个元素的值 
            while (j < m - 1)
            {
                if (items[j].CompareTo(items[j + 1]) < 0)
                    j++;                   //如果右孩子值较大时,j表示右孩子 
                if (t.CompareTo(items[j]) < 0)
                {   //根小，子树调整成堆 
                    items[i] = items[j];             //设置第i个元素为j的值 
                    i = j;                    //i,j向下滑动一层 
                    j = 2 * i + 1;
                }
                else break;
            }
            items[i] = t;
        }
        /// <summary>
        /// 将待排序序列看成是n个长度为1的已排序子序列
        /// <para>依次将两个相邻的子序列合并成一个大的有序序列</para>
        /// <para>时间复杂度为O(nlog2n)</para>
        /// <para>空间复杂度为O(n)</para>
        /// <para>稳定排序</para>
        /// </summary>
        public static void MergeSort(T[] items)
        {
            int len = 1;                        //已排序的序列长度,初始值为1 
            T[] temp = new T[items.Length];           //temp所需空间与items一样 
            do
            {
                MergePass(items, temp, len);      //将items中元素归并到temp中 
                Show(0, temp);
                len *= 2;
                MergePass(temp, items, len);          //将temp中元素归并到items中 
                Show(0, items);
                len *= 2;
            } while (len < items.Length);
        }
        /// <summary>
        /// 完成两趟归并排序
        /// </summary>
        private static void MergePass(T[] src, T[] dst, int len)
        {
            int i = 0, j;
            Console.Write("len=" + len + "  ");
            while (i < src.Length - 2 * len)
            {     //src至少包含两块子序列 
                Merge(src, dst, i, i + len, len);
                i += 2 * len;
            }
            if (i + len < src.Length)
                Merge(src, dst, i, i + len, len);   //src余下不足两块子序列，再一次归并 
            else
                for (j = i; j < src.Length; j++)   //src余下不足一块子序列，直接复制到dst 
                    dst[j] = src[j];
        }
        /// <summary>
        /// 依次将数组src中相邻两个有序子序列归并到数组dst中
        ///<para>如果相邻的子序列已归并完，数组src中仍有数据，则复制到dst</para>
        /// </summary>
        private static void Merge(T[] src, T[] dst, int r1, int r2, int n)
        {
            int i = r1, j = r2, k = r1;
            while (i < r1 + n && j < r2 + n && j < src.Length)
            {
                if (src[i].CompareTo(src[j]) < 0)
                {     //较小的值送到dst中 
                    dst[k] = src[i]; k++; i++;
                }
                else
                {
                    dst[k] = src[j]; k++; j++;
                }
            }
            while (i < r1 + n)
            {                  //将一子序列余下的值复制到dst中 
                dst[k] = src[i]; k++; i++;
            }
            while (j < r2 + n && j < src.Length)
            {  //将另一子序列余下的值复制到dst中 
                dst[k] = src[j]; k++; j++;
            }
        }
        /// <summary>
        /// 控制显示每次排序后的数组
        /// </summary>
        public static void Show(int i, T[] items)
        {
            if (i == 0)
                Console.Write("数据序列: ");
            else
                Console.Write("第" + i + "趟排序后: ");
            for (int j = 0; j < items.Length; j++)
                Console.Write(items[j] + " ");
            Console.WriteLine();
        }
    }
}
