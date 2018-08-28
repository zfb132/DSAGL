using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp1app
{
    class GenericMethod
    {
        static void Main(string[] args)
        {
            int a = 3; int b = 7;
            show<int>("交换前", a, b);
            swapint(ref a, ref b);
            show<int>("交换后", a, b);
            double ad = 3.5; double bd = 7.5;
            show<double>("交换前", ad, bd);
            swapdouble(ref ad, ref bd);
            show<double>("交换后", ad, bd);
            swap<int>(ref a, ref b);
        }

        static void show<T>(String s, T a, T b)
        {
            Console.Write(s + "\n第一个数是：" + a + "第二个数是：" + b + "\n");
        }

        static void swapint(ref int a, ref int b)
        {
            int x = a;
            a = b;
            b = x;
        }

        static void swapdouble(ref double a, ref double b)
        {
            double x = a;
            a = b;
            b = x;
        }

        static void swap<T>(ref T a, ref T b)
        {
            T x = a;
            a = b;
            b = x;
        }
    }
}
