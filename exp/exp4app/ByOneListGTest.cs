using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAGL;
namespace exp4app
{
    class ByOneListGTest
    {
        static void Main(string[] args)
        {
            string s = "1(2(4(^,7),^),3(5,6(8,^)))";
            Console.WriteLine("Generalized List: " + s);
            ListFlagsStruc<char> ListFlags;
            ListFlags.NullSubtree = '^'; ListFlags.LeftDelimit = '(';
            ListFlags.RightDelimit = ')'; ListFlags.MiddleDelimit = ',';
            //根据一个数组建立二叉树
            BinaryTree<char> btree = BinaryTree<char>.ByOneList(s.ToCharArray(0, s.Length), ListFlags);
            //三种遍历规则
            btree.ShowPreOrder(); btree.ShowInOrder();btree.ShowPostOrder();
            //按层次遍历
            btree.ShowByLevel();
        }
    }
}
