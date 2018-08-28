using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAGL;
using System.Diagnostics;

namespace exp2app
{
    class Josephus
    {
        static void Main(string[] args)
        {
            long t1 = 0, t2 = 0, t3 = 0;
            int n = 8,s=1,d=3;
            Stopwatch timerA = new Stopwatch();
            timerA.Start();
            // ArrayList删除元素方法
            arraySolve(n, s, d);
            timerA.Stop();
            t1 = timerA.ElapsedMilliseconds;
            // 为啥时间是累加，没有置零
            timerA.Restart();
            // SequenceList标记元素方法
            sequenceSolve(n, s, d);
            timerA.Stop();
            t2 = timerA.ElapsedMilliseconds;
            timerA.Restart();
            // SingledLinkedList标记元素方法
            singleListSolvePro(n, s, d);
            timerA.Stop();
            t3 = timerA.ElapsedMilliseconds;
            Console.WriteLine("\n\n约瑟夫环：n={0}， s={1}， d={2}", n,s,d);
            Console.WriteLine("ArrayList删除元素方法所用时间：{0}", t1);
            Console.WriteLine("SequenceList标记元素方法所用时间：{0}", t2);//蛤？
            Console.WriteLine("SingledLinkedList标记元素方法所用时间：{0}", t3);//蛤？
        }

        /// <summary>
        /// 使用系统ArrayList实现约瑟夫环问题，删除元素实现
        /// </summary>
        public static void arraySolve(int n,int s,int d)
        {
            ArrayList al = new ArrayList();
            int i, j, k;
            for (i = 1; i <= n; i++)
                // 将n个人依次插入线性表
                al.Add(i);
            showArray(al);
            // 第s个人的下标为s-1，i初始指向第s个人的前一位置
            i = s - 2;
            // 每轮的当前人数
            k = n;
            // n-1个人依次出环
            while (k > 1)
            {
                j = 0;
                while (j < d)
                {
                    // 计数
                    j++;
                    // 取余运算实现环形位置记录
                    i = (i + 1) % k;
                }
                Console.WriteLine("Out :  " + al[i]);
                // 第i个人出环，删除第i个位置的元素
                al.RemoveAt(i);
                k--;
                i = (i - 1) % k;
                showArray(al);
            }
            Console.WriteLine("\n{0} is the last person.", al[0]);
        }

        public static void showArray(ArrayList tp)
        {
            foreach(object a in tp)
            {
                Console.Write(a+"  ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 使用自定义的线性表实现，将元素置零实现
        /// </summary>
        public static void sequenceSolve(int n,int s,int d)
        {
            const int killedValue = 0;
            int i, j, k;
            int[] a = new int[n];
            for (i = 0; i < n; i++)
                a[i] = i + 1;
            // 将n个人依次插入线性表
            SequencedList<int> ring = new SequencedList<int>(a);
            ring.Show(true);
            // 第s个人的下标为s-1，i初始指向第s个人的前一位置
            i = s - 2;
            // 每轮的当前人数
            k = n;
            // n-1个人依次出环
            while (k > 1)
            {
                j = 0;
                while (j < d)
                {
                    // 将线性表看成环形
                    i = (i + 1) % n;
                    // 计数，但跳过已被kill的元素
                    if (ring[i] != killedValue)
                        j++;
                }
                Console.WriteLine("Out :  " + ring[i]);
                // 第i个人出环，kill该元素
                ring[i] = killedValue;
                k--;
                ring.Show(true);
            }
            i = 0;
            // 寻找最后一个人
            while (i < n && ring[i] == killedValue)
                i++;
            Console.WriteLine("\n{0} is the last person.", ring[i]);
        }

        /// <summary>
        /// 使用自定义的单向链表实现，将元素置零实现
        /// </summary>
        public static void singleListSolve(int n, int s, int d)
        {
            const int killedValue = 0;
            int i, j, k;
            int[] a = new int[n];
            for (i = 0; i < n; i++)
                a[i] = i + 1;
            // 将n个人依次插入线性表
            SingleLinkedList<int> ring = new SingleLinkedList<int>(a);
            ring.Show(true);
            // 第s个人的下标为s-1，i初始指向第s个人的前一位置
            i = s - 2;
            // 每轮的当前人数
            k = n;
            // n-1个人依次出环
            while (k > 1)
            {
                j = 0;
                while (j < d)
                {
                    // 将线性表看成环形
                    i = (i + 1) % n;
                    // 计数，但跳过已被kill的元素
                    if (ring[i] != killedValue)
                        j++;
                }
                Console.WriteLine("Out :  " + ring[i]);
                // 第i个人出环，kill该元素
                ring[i] = killedValue;
                k--;
                ring.Show(true);
            }
            i = 0;
            // 寻找最后一个人
            while (i < n && ring[i] == killedValue)
                i++;
            Console.WriteLine("\n{0} is the last person.", ring[i]);
        }

        /// <summary>
        /// 使用自定义的单向链表实现，将元素删除（未实现）
        /// </summary>
        public static void singleListSolvePro(int n, int s, int d)
        {
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = i + 1;
            // 将n个人依次插入线性表
            CircularLinkedList<int> ring = new CircularLinkedList<int>(a);
            //ring.Show(true);

            SingleLinkedNode<int> p = ring.Head;
            int t = 0, k = 0;
            while(p!=null)
            {
                if (ring.Count == 1)
                    break;
                if(k<s-1)
                {
                    k++;
                    // 因为链表长度肯定大于s，因此不判断next为空
                    p = p.Next;
                    continue;
                }
                t++;
                if(t%d==0)
                {

                    p.Next = p.Next.Next;
                    //ring.Show(true);
                }
                else
                {

                    p = p.Next;
                }
            }

            //Console.WriteLine("Out :  " + ring[i]);
            ring.Show(true);
            //Console.WriteLine("\n{0} is the last person.", );
        }
    }
}
