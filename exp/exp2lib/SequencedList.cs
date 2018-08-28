using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    public class SequencedList<T>
    {
        private T[] items;
        // 顺序表中元素的个数
        private int count = 0;
        // 顺序表的当前容量，即数组items的当前容量
        private int capacity = 0;

        //-------属性-----------//
        ///<summary>count属性生成器(只读)</summary>
        public int Count { get => count; }
        ///<summary>Empty属性：线性表是否为空</summary>
        public bool Empty { get => count == 0; }
        ///<summary>Full属性：线性表是否已满（当前预分配空间已满）</summary>
        // TODO 动态自动分配线性表容量
        public bool Full { get => count == items.Length; }
        ///<summary>获取或设置线性表容量</summary>
        public int Capacity{
            get => capacity;
            set {
                capacity = value;
                T[] copy = new T[capacity];
                // 如果设置的容量比当前元素个数少（放不下），强制把后面元素不要了
                if (count > capacity)
                    count = capacity;
                // 把原线性表中的所有非空元素复制到新数组
                Array.Copy(items, copy, count);
                items = copy;
            }
        }
        ///<summary>获取或设置某位置的元素值</summary>
        public T this[int i]{
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
                    items[i]=value;
                else
                    throw new IndexOutOfRangeException("Index Out of Range Exception in" + this.GetType());
            }
        }


        ///<summary>构造容量为c，但内容为空的线性表</summary>
        public SequencedList(int c)
        {
            capacity = c;
            items = new T[capacity];
            count = 0;
        }

        ///<summary>无参构造函数，创建容量为16的线性表</summary>
        public SequencedList() : this(16) { }

        ///<summary>以一个数组的元素作为参数构造线性表实例</summary>
        public SequencedList(T[] itemarray)
        {
            count = itemarray.Length;
            // 自动为线性表增加16个存储空间
            capacity = count + 16;
            items = new T[capacity];
            for(int i=0;i<count;i++)
            {
                items[i] = itemarray[i];
            }
        }

        ///<summary>判断线性表是否包含某值</summary>
        public bool Contains(T k)
        {
            int j = IndexOf(k);
            return j == -1 ? false : true;
        }

        ///<summary>返回元素在线性表中首次出现的位置，否则-1</summary>
        public int IndexOf(T k)
        {
            int t = 0;
            while (t < count && k.Equals(items[t]))
                t++;
            return t >= 0 && t < count ? t : -1;
        }

        ///<summary>在原有线性表第i个位置插入数据k<para>若当前线性表已满，则扩充原线性表容量为两倍</para></summary>
        public void Insert(int i,T k)
        {
            // 
            // if(count>=capacity)
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

        ///<summary>在线性表队列尾部加入数据<para>若当前线性表已满，则扩充原线性表容量为两倍</para></summary>
        public void Add(T k)
        {
            // 线性表已满，分配容量翻倍
            if (count >= capacity)
                Capacity = capacity * 2;
            items[count] = k;
            count++;
        }

        ///<summary>删除线性表第i个位置的元素（从0开始）</summary>
        public void RemoveAt(int i)
        {
            if (i >= 0 && i < count)
            {
                for (int t = i + 1; t < count; t++)
                    items[t-1]= items[t];
                count--;
            }
            else
                throw new IndexOutOfRangeException("Index Out of Range Exception in" + this.GetType());
        }

        ///<summary>删除线性表中指定数据</summary>
        public void Remove(T k)
        {
            int i = IndexOf(k);
            if (Contains(k))
            {
                for (int t = i + 1; t < count; t++)
                    items[t - 1] = items[t];
                count--;
            }
            else
                Console.WriteLine(k + "值未找到，无法删除！");
        }

        ///<summary>控制台输出线性表</summary>
        public void Show(bool showTypeName)
        {
            if (showTypeName)
                Console.Write("SequencedList: ");
            //foreach(var element in items)
            //    Console.Write(element+" ");
            for(int i=0;i<count;i++)
                Console.Write(items[i] + " ");
            Console.WriteLine();
        }

        ///<summary>重载ToString函数</summary>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                s.Append(items[i]);
                s.Append("; ");
            }
            return s.ToString();
        }
    }
}
