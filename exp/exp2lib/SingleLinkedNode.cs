using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    public class SingleLinkedNode<T>
    {
        private T item;
        private SingleLinkedNode<T> next;
        public SingleLinkedNode(T k)
        {
            Item = k;
            Next = null;
        }
        public SingleLinkedNode()
        {
            Next = null;
        }

        //属性生成器：选中变量，右键“快速操作和重构”，生成属性
        public T Item { get => item; set => item = value; }
        public SingleLinkedNode<T> Next { get => next; set => next = value; }

        ///<summary>控制台输出单向链表</summary>
        public void Show()
        {
            SingleLinkedNode<T> p = this;
            while(p!=null)
            {
                Console.Write(p.Item);
                p = p.Next;
                if (p != null)
                    Console.Write("-->");
                else
                    Console.Write(".");
            }
            Console.WriteLine();
        }

        ///<summary>重载ToString函数</summary>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            SingleLinkedNode<T> p = this;
            while (p != null)
            {
                s.Append(p.Item);
                p = p.Next;
                if (p != null)
                    s.Append("-->");
                else
                    s.Append(".");
            }
            return s.ToString();
        }
    }
}
