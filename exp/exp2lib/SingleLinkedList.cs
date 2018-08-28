using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    public class SingleLinkedList<T>
    {
        private SingleLinkedNode<T> head;
        ///<summary>构造空的单向链表</summary>
        public SingleLinkedList()
        {
            head = new SingleLinkedNode<T>();
        }
        ///<summary>构造由参数f所指向结点为第一个结点的单向链表</summary>
        public SingleLinkedList(SingleLinkedNode<T> f):this()
        {
            head.Next = f;
        }
        ///<summary>以一个元素构造单向链表</summary>
        // :this()啥意思？？？
        public SingleLinkedList(T a):this()
        {
            SingleLinkedNode<T> rear, q;
            rear = head;
            q = new SingleLinkedNode<T>(a);
            rear.Next = q;
            rear = q;
        }
        ///<summary>以一个数组的多个元素构造单向链表</summary>
        public SingleLinkedList(T[] a) : this()
        {
            SingleLinkedNode<T> rear, q;
            rear = head;
            for(int i=0;i<a.Length;i++)
            {
                q = new SingleLinkedNode<T>(a[i]);
                rear.Next = q;
                rear = q;
            }
        }

        ///<summary>head属性生成器</summary>
        public SingleLinkedNode<T> Head { get => head; set => head = value; }
        ///<summary>获取单向链表长度(只读)</summary>
        public virtual int Count
        {
            get
            {
                int n = 0;
                SingleLinkedNode<T> p = head.Next;
                while (p != null)
                {
                    n++;
                    p = p.Next;
                }
                return n;
            }
        }
        ///<summary>判断链表是否为空(只读)</summary>
        public virtual bool Empty { get => head.Next == null; }

        ///<summary>获取或设置指定位置的元素值，使用从0开始的索引参数</summary>
        public virtual T this[int i]
        {
            get
            {
                if(i<0)
                    throw new IndexOutOfRangeException("Index is negative in " + this.GetType());
                int n = 0;
                SingleLinkedNode<T> p = head.Next;
                while (p != null&&n!=i)
                {
                    n++;
                    p = p.Next;
                }
                if (p == null)
                    throw new IndexOutOfRangeException("Index Out of Range Exception in " + this.GetType());
                return p.Item;
            }
            set
            {
                if (i < 0)
                    throw new IndexOutOfRangeException("Index is negative in " + this.GetType());
                int n = 0;
                SingleLinkedNode<T> p = head.Next;
                while (p != null && n != i)
                {
                    n++;
                    p = p.Next;
                }
                if (p == null)
                    throw new IndexOutOfRangeException("Index Out of Range Exception in " + this.GetType());
                p.Item=value;
            }
        }

        ///<summary>控制台输出单向链表</summary>
        public virtual void Show(bool showTypeName)
        {
            if (showTypeName)
                Console.Write("SingleLinkedList: ");
            SingleLinkedNode<T> p = head.Next;
            if (p != null)
                p.Show();
        }

        ///<summary>重载ToString函数</summary>
        public override string ToString()
        {
            SingleLinkedNode<T> p = head.Next;
            if (p != null)
                return p.ToString();
            else
                return null;
        }

        ///<summary>在单向链表指定位置插入元素（索引过大则插入到最后，索引为负则视为0）</summary> 
        public virtual void Insert(int i,T k)
        {
            int t = 0;
            SingleLinkedNode<T> p = head;
            SingleLinkedNode<T> q = p.Next;
            if (i < 0)
                i = 0;
            SingleLinkedNode<T> s = new SingleLinkedNode<T>(k);
            while(q!=null)
            {
                if (t == i)
                    break;
                p = q;
                q = q.Next;
                t++;
            }
            s.Next = p.Next;
            p.Next = s;
        }

        ///<summary>在单向链表末尾增加元素</summary> 
        public virtual void Add(T k)
        {
            SingleLinkedNode<T> q = head.Next;
            SingleLinkedNode<T> s = new SingleLinkedNode<T>(k);
            // 若原线性表为空
            // if(q==null)
            if (Empty)
            {
                q = s;
                return;
            }
            while (q.Next != null)
            {
                q = q.Next;
            }
            q.Next = s;
        }

        ///<summary>删除单向链表某个元素k</summary> 
        public void Remove(T k)
        {
            SingleLinkedNode<T> p = head;
            SingleLinkedNode<T> q = p.Next;
            while (q != null)
            {
                if(k.Equals(q.Item))
                {
                    p.Next = q.Next;
                    return;
                }
                p = q;
                q = q.Next;
            }
            Console.WriteLine(k + "值未找到，无法删除！");
        }

        ///<summary>删除单向链表指定位置的元素</summary>
        public void RemoveAt(int i)
        {
            int t = 0;
            SingleLinkedNode<T> p = head;
            SingleLinkedNode<T> q = p.Next;
            while (q != null)
            {
                if (t==i)
                {
                    p.Next = q.Next;
                    return;
                }
                p = q;
                q = q.Next;
                t++;
            }
            // throw在什么情况触发？？？
            throw new IndexOutOfRangeException("Index Out of Range Exception in " + this.GetType());
        }

        ///<summary>单向链表反向</summary>
        public virtual void Reverse()
        {
            SingleLinkedNode<T> q = null, front = null;
            SingleLinkedNode<T> p = head.Next;
            while (p != null)
            {
                q = p.Next;
                p.Next = front;
                front = p;
                p = q;
            }
            head.Next = front;
        }
    }
}
