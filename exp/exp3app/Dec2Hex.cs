using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp3app
{
    class Dec2Hex
    {
        static void Main(string[] args)
        {
            int n = 666;
            //用系统带的格式化输出显示16进制（自己写的函数就是为了实现此功能）
            //Console.WriteLine("{0:x}", n);
            if (args.Length == 1)
                try
                {
                    n = Int32.Parse(args[0]);
                }
                catch (Exception)
                {
                    throw new FormatException();
                }
            else
                try
                {
                    Console.WriteLine("输入要转换的10进制数：");
                    n = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    throw new FormatException();
                }
            
            trofStack(n);
        }

        /// <summary>
        /// <para>使用系统栈Stack进行10进制到16进制转换</para>
        /// <para>栈在此过程中可以保存每一位对应的十六进制数</para>
        /// </summary>
        private static void trofStack(int num)
        {
            //由于初始化为10位：故最大只能转换10位的16进制数
            Stack<int> stack = new Stack<int>(10);
            Console.WriteLine("转换前的十进制整数： {0}",num);
            while (num != 0)
            {
                stack.Push(num % 16);
                num = num / 16;
            }
            int i = stack.Count;
            Console.Write("转换后的十六进制整数： ");
            for (; i>0; i--)
            {
                if (stack.Peek() < 10)
                    Console.Write(stack.Pop() + "");
                else
                    //switch (stack.Pop())
                    //{
                    //    case 10: Console.Write("A"); break;
                    //    case 11: Console.Write("B"); break;
                    //    case 12: Console.Write("C"); break;
                    //    case 13: Console.Write("D"); break;
                    //    case 14: Console.Write("E"); break;
                    //    case 15: Console.Write("F"); break;
                    //    default:break;
                    //}
                    Console.Write((char)(stack.Pop() + 55));
            }
            Console.WriteLine();
        }
    }
}
