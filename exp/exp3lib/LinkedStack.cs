using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    public class LinkedStack<T> : SingleLinkedList<T>
    {
        private SingleLinkedNode<T> top;

        public LinkedStack() : base()
        {
            //Head是仅作为标志的头结点，top指向第一个数据结点
            top = base.Head.Next;   
        }

        public override bool Empty { get { return top == null; } }

        /// <summary>
        /// 元素入栈
        /// </summary>
        // TODO: 长度不够时自动分配空间
        public void Push(T k)
        {
            SingleLinkedNode<T> q = new SingleLinkedNode<T>(k);
            //q结点作为新的栈顶结点 
            q.Next = top;      
            top = q;
            base.Head.Next = top;
        }

        /// <summary>
        /// 弹出链式栈栈顶数据元素，栈为空时报异常
        /// </summary>
        public T Pop()
        {
            //置变量k为T类型的缺省值 
            //对于引用类型，将为 NULL；对于值类型，将为零；对于结构，将为 0 位模式
            T k = default(T);
            //栈不空 
            if (!Empty)
            {
                //取得栈顶数据元素值 
                k = top.Item;                
                top = top.Next;
                //删除栈顶结点 
                base.Head.Next = top;
                return k;
            }
            else
                throw new InvalidOperationException("Stack is Empty: " + this.GetType());
        }

        /// <summary>
        /// 查看链式栈栈顶元素（不出栈），栈为空时报异常
        /// </summary>
        public T Peek()
        {
            if (!Empty)
                return top.Item;
            else
                throw new InvalidOperationException("Stack is Empty: " + this.GetType());
        }
    }
}
