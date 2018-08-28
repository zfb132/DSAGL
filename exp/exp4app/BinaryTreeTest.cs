using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAGL;
namespace exp4app
{
    class BinaryTreeTest
    {
        static void Main(string[] args)
        {
            BinaryTree<int> bt1 = new BinaryTree<int>();
            BinaryTreeNode<int>[] nodes = new BinaryTreeNode<int>[9];
            for (int i = 1; i <= 8; i++)
                nodes[i] = new BinaryTreeNode<int>(i);

            bt1.Root = nodes[1];
            nodes[1].Left = nodes[2]; nodes[1].Right = nodes[3];
            nodes[2].Left = nodes[4];
            nodes[3].Left = nodes[5]; nodes[3].Right = nodes[6];
            nodes[4].Right = nodes[7];
            nodes[6].Left = nodes[8];

            //显示不同的遍历序列  
            bt1.ShowPreOrder(); bt1.ShowInOrder(); bt1.ShowPostOrder();

            BinaryTree<string> bt2 = new BinaryTree<string>();
            bt2.Root = new BinaryTreeNode<string>("武汉大学");
            bt2.Root.Left = new BinaryTreeNode<string>("电信学院");
            bt2.Root.Right = new BinaryTreeNode<string>("计算机学院");
            bt2.Root.Left.Left = new BinaryTreeNode<string>("C#课程");
            bt2.Root.Right.Left = new BinaryTreeNode<string>("教师1");
            bt2.Root.Right.Right = new BinaryTreeNode<string>("DSAGL课程");
            bt2.Root.Left.Left.Right = new BinaryTreeNode<string>("学生1");
            bt2.Root.Right.Right.Left = new BinaryTreeNode<string>("教师2");
            //显示不同的遍历序列 
            bt2.ShowPreOrder(); bt2.ShowInOrder(); bt2.ShowPostOrder();
        }
    }
}
