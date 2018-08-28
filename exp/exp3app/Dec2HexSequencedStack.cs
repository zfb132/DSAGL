using System;
using System.Collections.Generic;
using System.Linq;
using DSAGL;

namespace exp3app
{
    class Dec2HexSequencedStack
    {
        static void Main(string[] args)
        {
            int n = 666;
            trofSequencedStack(n);
            //Console.WriteLine(recursionFact(5));
        }

        private static int recursionFact(int n)
        {
            int s = 1;
            if (n == 1) return s;
            else s = n * recursionFact(n - 1);
            return s;
        }

        /// <summary>
        /// <para>使用自定义栈SequencedStack进行10进制到16进制转换</para>
        /// </summary>
        private static void trofSequencedStack(int num)
        {
            //由于初始化为10位：故最大只能转换10位的16进制数
            SequencedStack<int> sequencedstack = new SequencedStack<int>(10);
            Console.WriteLine("转换前的十进制整数： {0}", num);
            while (num != 0)
            {
                sequencedstack.Push(num % 16);
                num = num / 16;
            }
            int i = sequencedstack.Count;
            Console.Write("转换后的十六进制整数： ");
            for (; i > 0; i--)
            {
                if (sequencedstack.Peek() < 10)
                    Console.Write(sequencedstack.Pop() + "");
                else
                    switch (sequencedstack.Pop())
                    {
                        case 10: Console.Write("A"); break;
                        case 11: Console.Write("B"); break;
                        case 12: Console.Write("C"); break;
                        case 13: Console.Write("D"); break;
                        case 14: Console.Write("E"); break;
                        case 15: Console.Write("F"); break;
                        default: break;
                    }
            }
            Console.WriteLine();
        }
    }
}
