using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    public class SequencedQueue<T>
    {
        private T[] items;
        private int front, rear;

        /// <summary>
        /// 创建长度为n的顺序队列
        /// </summary>
        public SequencedQueue(int n)
        {
            items = new T[n + 1];
            front = rear = 0;
        }

        /// <summary>
        /// 创建一个长度为16的顺序队列
        /// </summary>
        public SequencedQueue() : this(16) { }

        public int Count { get => (rear - front + items.Length) % items.Length; }

        public bool Empty { get => front == rear; }

        public bool Full { get => front == (rear + 1) % items.Length; }

        /// <summary>
        /// 将当前顺序栈的长度增加1倍
        /// </summary>
        private void DoubleCapacity()
        {
            int i, t, count = Count;
            int capacity = 2 * items.Length - 1;
            T[] copy = new T[capacity];
            for (i = 0; i < count; i++)
            {
                t = (i + front) % items.Length;
                copy[i] = items[t];
            }
            front = 0;rear = count;items = copy;
        }

        /// <summary>
        /// 将元素k入队（长度不够时自动将长度增加一倍）
        /// </summary>
        public void Enqueue(T k)
        {
            if (Full)
                DoubleCapacity();
            items[rear] = k;
            rear = (rear + 1) % items.Length;
        }

        /// <summary>
        /// 将元素k出队
        /// </summary>
        public T Dequeue()
        {
            T k = default(T);
            if (!Empty)
            {
                k = items[front];
                front = (front + 1) % items.Length;
                return k;
            }
            else
                throw new InvalidOperationException();
        }

        /// <summary>
        /// 查看队列元素（不出队），队列为空时报异常
        /// </summary>
        public T Peek()
        {
            if (!Empty)
                return items[front];
            else
                throw new InvalidOperationException();
        }

        /// <summary>
        /// 在控制台从队列头开始输出顺序队列的各个元素
        /// </summary>
        public void Show(bool showTypeName)
        {
            if (showTypeName)
                Console.Write("Queue: ");
            int i = this.front;int n = i;
            if (!Empty)
            {
                if (i < this.rear)
                    n = this.rear - 1;
                else
                    n = this.rear + this.items.Length - 1;
                for (; i <= n; i++)
                    Console.Write(items[i%items.Length] + " ");
            }
            Console.WriteLine();
        }
    }
}
