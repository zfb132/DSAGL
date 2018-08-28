using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    public class Node<T>
    {
        /// <summary>
        /// 存放结点值
        /// </summary>
        private T item;

        /// <summary>
        /// 后继结点的引用
        /// </summary>
        private Node<T> next; 

        /// <summary>
        /// 以值k构造一个结点
        /// </summary>
        public Node(T k) { item = k; next = null; }

        /// <summary>
        /// 结点值的属性生成器
        /// </summary>
        public T Item { get { return item; } set { item = value; } }

        /// <summary>
        /// 后继结点的属性生成器
        /// </summary>
        public Node<T> Next { get { return next; } set { next = value; } }
    }
    public class HashSearchList<T>
    {
        /// <summary>
        /// 基本表的结点
        /// </summary>
        private Node<T>[] basetable;

        /// <summary>
        /// 构造容量大小为hashsize的哈希表
        /// </summary>
        public HashSearchList(int hashsize)
        {
            basetable = new Node<T>[hashsize];
        }

        /// <summary>
        /// 构造容量大小为7的哈希表
        /// </summary>
        public HashSearchList() : this(7) { }

        /// <summary>
        /// 计算值k的哈希值
        /// </summary>
        public int Hash(T k)
        {
            return k.GetHashCode() % basetable.Length;
        }

        /// <summary>
        /// 在哈希表末尾增加一个值k
        /// </summary>
        public void Add(T k)
        {
            Node<T> q = new Node<T>(k);
            int i = Hash(k);
            if (basetable[i] == null)
                basetable[i] = q;
            else
            {
                q.Next = basetable[i].Next;
                basetable[i].Next = q;
            }
        }

        /// <summary>
        /// 返回哈希表中值k所在结点
        /// </summary>
        public Node<T> Search(T k)
        {
            int i = Hash(k);
            if (basetable[i] == null)
                return null;
            else
            {
                if (k.Equals(basetable[i].Item))
                    return basetable[i];
                else
                {
                    Node<T> q = basetable[i].Next;
                    while (q != null && !k.Equals(q.Item))
                    {
                        q = q.Next;
                    }
                    return q;
                }
            }
        }

        /// <summary>
        /// 判断哈希表是否包含值k
        /// </summary>
        public bool Contains(T k)
        {
            Node<T> q = Search(k);
            if (q != null) return true;
            else return false;
        }

        /// <summary>
        /// 在控制台输出哈希表的各个元素
        /// </summary>
        public void Show()
        {
            for (int i = 0; i < basetable.Length; i++)
            {
                Console.Write("Basetable[" + i + "]= ");
                if (basetable[i] != null)
                {
                    Node<T> q = basetable[i];
                    while (q != null)
                    {
                        Console.Write(q.Item + "-> ");
                        q = q.Next;
                    }
                }
                Console.WriteLine(".");
            }
        }
    }
}