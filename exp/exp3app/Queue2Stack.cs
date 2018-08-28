using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp3app
{
    class Queue2Stack
    {
        private const int NUM = 10;
        static void Main(string[] args)
        {
            /*此方法初始化很方便
            IEnumerable<int> numarray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Queue<int> queue = new Queue<int>(numarray);
            */
            Queue<int> queue = new Queue<int>(NUM);
            Stack<int> stack = new Stack<int>(NUM);
            //以下for可以合并为1个
            //将数字放入队列并显示
            for (int i = 0; i < NUM; i++)
            {
                queue.Enqueue(i);
            }
            //不重载ToString显示队列元素
            Console.Write("原来的队列： ");
            foreach (var item in queue)
                Console.Write("{0} ", item);
            Console.WriteLine();
               
            //将队列元素依次入栈
            for (int i = 0; i < NUM; i++)
                stack.Push(queue.Dequeue());
            //将栈元素依次弹出到队列
            for (int i = 0; i < NUM; i++)
                queue.Enqueue(stack.Pop());
            Console.Write("反序后队列： ");
            for (int i = 0; i < NUM; i++)
                Console.Write(queue.Dequeue() + "  ");
            Console.WriteLine();
        }
    }
}
