using DSAGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp5app
{
    class HashSearchListTest
    {
        static void Main(string[] args)
        {
            int k = 16;
            int[] d = { 19, 14, 23, 1, 32, 86, 55, 3, 62, 10, 16, 17 };
            HashSearchList<int> hsl1 = new HashSearchList<int>();
            CreateHashList(hsl1, d);
            hsl1.Show();
            Console.WriteLine("hash({0})={1}", k, hsl1.Hash(k));
            Console.WriteLine("Contains({0})={1}", k, hsl1.Contains(k));
        }
        static void CreateHashList(HashSearchList<int> hsl, int[] d)
        {
            for (int i = 0; i < d.Length; i++)
                hsl.Add(d[i]);
        }
    }
}
