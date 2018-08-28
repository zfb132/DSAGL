using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    public class SequencedStack<T>
    {
        private T[] items;
        private const int empty = -1;
        private int top = empty;

        public SequencedStack(int n)
        {
            items = new T[n];
            top = empty;
        }

        public SequencedStack() : this(16) { }

        public int Count { get => top + 1; }

        public bool Empty { get => top == empty; }

        public bool Full { get => top >= items.Length - 1; }

        /// <summary>
        /// 将当前顺序栈的长度增加一倍
        /// </summary>
        private void DoubleCapacity()
        {
            int count = Count;
            int capacity = 2 * items.Length;
            T[] copy = new T[capacity];
            for (int i = 0; i < count; i++)
                copy[i] = items[i];
            items = copy;
        }

        /// <summary>
        /// 弹出栈顶元素，栈为空时报异常
        /// </summary>
        public T Pop()
        {
            T k = default(T);
            if (!Empty)
            {
                k = items[top];
                top--;
                return k;
            }
            else
                throw new InvalidOperationException();
        }

        /// <summary>
        /// 将元素k压入栈顶（长度不够时自动将长度增加一倍）
        /// </summary>
        public void Push(T k)
        {
            if (Full)
                DoubleCapacity();
            top++;
            items[top] = k;
        }

        /// <summary>
        /// 查看栈顶元素（不弹栈），栈为空时报异常
        /// </summary>
        public T Peek()
        {
            if (!Empty)
                return items[top];
            else
                throw new InvalidOperationException();
        }

        /// <summary>
        /// 在控制台从栈顶开始输出顺序栈的各个元素
        /// </summary>
        public void Show(bool showTypeName)
        {
            if (showTypeName)
                Console.Write("Stack: ");
            if (!Empty)
                for (int i = this.top; i >= 0; i--)
                    Console.Write(items[i] + " ");
            Console.WriteLine();
        }

        /// <summary>
        /// 实现可迭代的接口：此处顺序显示
        /// </summary>
        public IEnumerable<T> Elements
        {
            get
            {
                for (int i = 0; i < items.Length; i++)
                    yield return items[i];
            }    
        }
    }
}
