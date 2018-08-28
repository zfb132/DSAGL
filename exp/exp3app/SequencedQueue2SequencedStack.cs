using System;
using System.Collections.Generic;
using DSAGL;

namespace exp3app
{
    class SequencedQueue2SequencedStack
    {
        private const int NUM = 10;
        static void Main(string[] args)
        {
            SequencedQueue<int> sequencedqueue = new SequencedQueue<int>(NUM);
            SequencedStack<int> sequencedstack = new SequencedStack<int>(NUM);
            //以下for可以合并为1个
            //将数字放入队列并显示
            for (int i = 0; i < NUM; i++)
                sequencedqueue.Enqueue(i);
            Console.Write("原来的队列： ");
            sequencedqueue.Show(false);

            //将队列元素依次入栈
            for (int i = 0; i < NUM; i++)
                sequencedstack.Push(sequencedqueue.Dequeue());

            foreach (var item in sequencedstack.Elements)
                Console.Write("{0} ", item);

            //将栈元素依次弹出到队列
            for (int i = 0; i < NUM; i++)
                sequencedqueue.Enqueue(sequencedstack.Pop());
            Console.Write("反序后队列： ");
            sequencedqueue.Show(false);
        }
    }
}
