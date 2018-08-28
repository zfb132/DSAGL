using DSAGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exp2app
{
    public class SingleLinkedListTest
    {
        static void Main(string[] args)
        {
            SingleLinkedList<int> a = new SingleLinkedList<int>();
            a.Insert(3, 1);
            a.Show(true);
        }
    }
}
