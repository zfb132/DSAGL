using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    public class CircularLinkedList<T> : SingleLinkedList<T>
    {
        private SingleLinkedNode<T> rear;

        public SingleLinkedNode<T> Rear { get => rear; }

        public CircularLinkedList() : base()
        {
            this.rear = this.Head;
        }

        public CircularLinkedList(T[] array) : this()
        {
            SingleLinkedNode<T> p = null;
            for(int i=0;i<array.Length;i++)
            {
                p = new SingleLinkedNode<T>(array[i]);
                rear.Next = p;
                rear = p;
            }
            p.Next = Head;
        }

        public override int Count
        {
            get
            {
                int n = 0;
                SingleLinkedNode<T> p = Head.Next;
                if (p == null)
                    return 0;
                while(p!=Head)
                {
                    n++;
                    p = p.Next;
                }
                return n;
            }
        }

        public override bool Empty { get => Head == rear; }
    }
}
