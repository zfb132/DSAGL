using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    public class LinearSearchList<T> where T : IComparable
    {
        /// <summary>
        /// 存储数据元素的数组
        /// </summary>
        private T[] items; 

        /// <summary>
        /// 顺序表的长度
        /// </summary>
        private int count;

        /// <summary>
        /// 顺序表的容量
        /// </summary>
        int capacity = 0; 

        /// <summary>
        /// 生成指定容量大小的空线性搜索表
        /// </summary>
        public LinearSearchList(int capacity)
        {
            items = new T[capacity]; // 分配capacity个存储单元
            count = 0; // 此时顺序表长度为0
            this.capacity = capacity;
        }

        /// <summary>
        /// 生成容量为16的空线性搜索表
        /// </summary>
        public LinearSearchList() : this(16) { }

        /// <summary>
        /// 在原有线性表末尾位置插入数据k
        /// </summary>
        /// <param name="k"></param>
        public void Add(T k)
        { // 将k 添加到顺序表的结尾处
            if (Full)
            { // resize array
                Capacity = capacity * 2; // double capacity
            }
            items[count] = k; count++;
        }

        ///<summary>
        ///在原有线性表第i个位置插入数据k
        ///<para>若当前线性表已满，则扩充原线性表容量为两倍</para>
        ///</summary>
        public void Insert(int i, T k)
        {
            if (Full)
                Capacity = capacity * 2;
            if (i < 0)
                i = 0;
            // 若i太大，直接插入到线性表元素末尾（中间不能隔空元素）
            if (i >= count)
                i = count;
            else
                // 此处索引为t+1是由于insert一个元素，长度变了
                for (int t = count - 1; t >= i; t--)
                    items[t + 1] = items[t];
            items[i] = k;
            count++;
        }

        ///<summary>
        ///获取或设置某位置的元素值
        ///</summary>
        public T this[int i]
        {
            get
            {
                if (i >= 0 && i < count)
                    return items[i];
                else
                    throw new IndexOutOfRangeException("Index Out of Range Exception in" + this.GetType());
            }
            set
            {
                if (i >= 0 && i < count)
                    items[i] = value;
                else
                    throw new IndexOutOfRangeException("Index Out of Range Exception in" + this.GetType());
            }
        }

        /// <summary>
        /// 判断顺序表是否已满
        /// </summary>
        public bool Full { get { return count >= capacity; } }

        /// <summary>
        /// 返回顺序表长度
        /// </summary>
        public int Count { get { return count; } } 

        /// <summary>
        /// 返回或设置线性表容量
        /// </summary>
        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (value > capacity)
                {
                    capacity = value;
                    T[] copy = new T[capacity]; // create newly sized array
                    Array.Copy(items, copy, count); // copy over the array
                    items = copy; // assign items to the new, larger array
                }
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Capacity/2; i++)
            {
                T temp = items[i];
                items[i] = items[Capacity - i - 1];
                items[Capacity - i - 1] = temp;
            }
        }

        public void Sort(bool reverse=true)
        {
            Array.Sort(items);
            //if (reverse)
            //    Reverse();
            if (Capacity == Count)
                return;
            for (int i = 0; i < Count; i++)
            {
                //T temp = items[i];
                items[i] = items[i + Capacity - Count];
                //items[i + Capacity - Count] = temp;
            }
        }

        /// <summary>
        /// 在控制台从开始输出线性表的各个元素
        /// </summary>
        public void Show(bool showTypeName)
        {
            if (showTypeName)
                Console.Write("LinearSearchList: ");
            for (int i = 0; i < this.count; i++)
            {
                Console.Write(items[i] + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 查找k值在线性表中的位置,查找成功时返回k值首次出现位置，否则返回-1
        /// </summary>
        public int IndexOf(T k)
        {
            int i = 0;
            while (i < count && !items[i].Equals(k))
                i++;
            if (i >= 0 && i < count)
                return i;
            else return -1;
        }

        /// <summary>
        /// 查找线性表是否包含k值,查找成功时返回true，否则返回false
        /// </summary>
        public bool Contains(T k)
        {
            int j = IndexOf(k);
            if (j != -1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// <para>顺序查找k值在线性表中的位置，查找成功时返回k值首次出现位置，否则返回应插入位置的反码</para>
        /// <para>查找范围:从下标si开始，包含length个元素</para>
        /// </summary>
        public int SequencedSearch(T k,int si,int length)
        {
            int time = length + si;
            int i, location = si;
            for (i = si; i < time; i++)
            {
                switch (k.CompareTo(items[i]))
                {
                    case 1:location++;break;
                    case 0: return i;
                    case -1: break;
                    default:break;
                }
            }
            return ~location;
        }

        /// <summary>
        /// <para>二分查找k值在线性表中的位置，查找成功时返回k值首次出现位置，否则返回应插入位置的反码</para>
        /// <para>查找范围:从下标si开始，包含length个元素</para>
        /// </summary>
        public int BinarySearch(T k, int si, int length)
        {
            int mid = 0, left = si;
            int right = left + length - 1;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (k.CompareTo(items[mid]) == 0)
                    return mid;
                else if (k.CompareTo(items[mid]) < 0)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            if (k.CompareTo(items[mid]) > 0)
                mid++;
            return ~mid;
        }
    }
}
