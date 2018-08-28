using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAGL;
namespace exp4app
{
    class ByOneListTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("通过单数组建立完全二叉树：");
            myByOneListTest();
            Console.WriteLine("\n\n通过前序和中序数组建立二叉树：");
            ByTwoListPreInTest();
        }

        /// <summary>
        /// 以单数组建立完全二叉树
        /// </summary>
        public static void myByOneListTest()
        {
            int[] it = { 1, 2, 3, 4, 5, 6, 7, 8 };
            BinaryTree<int> bt1 = BinaryTree<int>.ByOneList(it);
            //按三种次序遍历
            bt1.ShowPreOrder(); bt1.ShowInOrder();bt1.ShowPostOrder();
            //按层次遍历
            bt1.ShowByLevel();
            Console.WriteLine();
            char[] ct = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            BinaryTree<char> bt2 = BinaryTree<char>.ByOneList(ct);
            //按三种次序遍历
            bt2.ShowPreOrder(); bt2.ShowInOrder(); bt2.ShowPostOrder();
            //按层次遍历
            bt2.ShowByLevel();
        }

        /// <summary>
        /// 以先根和中根次序遍历序列建立一颗二叉树
        /// </summary>
        public static void ByTwoListPreInTest()
        {
            int[] prelist = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] inlist = { 2, 3, 4, 1, 6, 7, 8, 9, 5};
            BinaryTree<int> btree = BinaryTree<int>.ByTwoList(prelist, inlist);
            //按三种次序遍历
            btree.ShowPreOrder(); btree.ShowInOrder(); btree.ShowPostOrder();
            //按层次遍历
            btree.ShowByLevel();
        }
    }
}
