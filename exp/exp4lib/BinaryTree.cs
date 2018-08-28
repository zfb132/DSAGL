using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    //广义表专用结构体
    public struct ListFlagsStruc<T>
    {
        public T NullSubtree;
        public T LeftDelimit;
        public T RightDelimit;
        public T MiddleDelimit;
    }
    public class BinaryTree<T>
    {
        //指向二叉树的根结点 
        protected BinaryTreeNode<T> root;

        //广义表专用变量
        private static ListFlagsStruc<T> ListFlags;
        private static int idx = 0;

        /// <summary>
        /// 二叉树的根结点
        /// </summary>
        public BinaryTreeNode<T> Root{ get => root; set => root = value; }

        /// <summary>
        /// 构造空二叉树 
        /// </summary>
        public BinaryTree()
        {                           
            root = null;
        }

        /// <summary>
        /// 先根次序递归遍历二叉树，输出在控制台
        /// </summary>
        public void ShowPreOrder()
        {
            Console.Write("先根次序：  ");
            if (root != null)
                root.ShowPreOrder();
            Console.WriteLine();
        }

        /// <summary>
        /// 先根次序递归遍历二叉树，返回遍历后的数据列表
        /// </summary>
        public List<T> TraversalPreOrder()
        {
            List<T> sql = new List<T>();
            if (root != null)
                root.TraversalPreOrder(sql);
            return sql;
        }

        /// <summary>
        /// 中根次序递归遍历二叉树 
        /// </summary>
        public void ShowInOrder()
        {
            Console.Write("中根次序：  ");
            if (root != null)
                root.ShowInOrder();
            Console.WriteLine();
        }

        /// <summary>
        /// 中根次序递归遍历二叉树，返回遍历后的数据列表
        /// </summary>
        public List<T> TraversalInOrder()
        {
            List<T> sql = new List<T>();
            if (root != null)
                root.TraversalInOrder(sql);
            return sql;
        }

        /// <summary>
        /// 后根次序递归遍历二叉树 
        /// </summary>
        public void ShowPostOrder()
        {
            Console.Write("后根次序：  ");
            if (root != null)
                root.ShowPostOrder();
            Console.WriteLine();
        }

        /// <summary>
        /// 后根次序递归遍历二叉树，返回遍历后的数据列表
        /// </summary>
        public List<T> TraversalPostOrder()
        {
            List<T> sql = new List<T>();
            if (root != null)
                root.TraversalPostOrder(sql);
            return sql;
        }

        /// <summary>
        /// 非递归中根次序遍历二叉树
        /// </summary>
        public void ShowInOrderNR()
        {
            Stack<BinaryTreeNode<T>> s = new Stack<BinaryTreeNode<T>>(100);
            BinaryTreeNode<T> p = root;
            Console.Write("非递归中根次序：  ");
            while (p != null || s.Count != 0)
            {  
                //p非空或栈非空时 
                if (p != null)
                {
                    //p结点入栈 
                    s.Push(p);
                    //进入左子树 
                    p = p.Left;                 
                }
                else
                {
                    //p指向出栈的结点
                    p = s.Pop();
                    //访问结点
                    Console.Write(p.Data + " ");
                    //进入右子树
                    p = p.Right;
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 通过层次遍历二叉树
        /// </summary>
        public void ShowByLevel()
        {
            //设立一个空队列 
            Queue<BinaryTreeNode<T>> q = new Queue<BinaryTreeNode<T>>(100); 
            BinaryTreeNode<T> p = root;
            Console.Write("层次遍历：  ");
            while (p != null)
            {
                Console.Write(p.Data + " ");
                //p的左孩子结点入队 
                if (p.Left != null) q.Enqueue(p.Left);
                //p的右孩子结点入队 
                if (p.Right != null) q.Enqueue(p.Right);  
                if (q.Count != 0)
                    //当队列不空，p指向出队的结点 
                    p = q.Dequeue();            
                else
                    //当队列为空，p置为null 
                    p = null;        
            }
            Console.WriteLine();
        }

        /// <summary>
        /// <para>建立链式存储结构的完全二叉树</para>
        /// <para>参数 t 是一个线性表或数组，用以表示顺序存储的完全二叉树结点值的序列</para>
        /// <para>返回由 t 建立的二叉树</para>
        /// </summary>
        public static BinaryTree<T> ByOneList(IList<T> t)
        {
            int n = t.Count;
            BinaryTree<T> bt = new BinaryTree<T>();
            if (n == 0)
            {
                bt.Root = null;
                return bt;
            }
            int i, j;
            BinaryTreeNode<T>[] q = new BinaryTreeNode<T>[n];
            T v;
            for (i = 0; i < n; i++)
            {
                v = t[i];
                //取编号为i的结点值 
                q[i] = new BinaryTreeNode<T>(v);
            }
            for (i = 0; i < n; i++)
            {
                j = 2 * i + 1;
                if (j < n)
                    q[i].Left = q[j];
                else
                    q[i].Left = null;
                j++;
                if (j < n)
                    q[i].Right = q[j];
                else
                    q[i].Right = null;
            }
            bt.Root = q[0];
            return bt;
        }

        /// <summary>
        /// <para>按先根遍历序列和中根遍历序列建立二叉树</para>
        /// <para>返回构造后的二叉树</para>
        /// </summary>
        public static BinaryTree<T> ByTwoList(IList<T> preList, IList<T> inList)
        {
            BinaryTree<T> bt = new BinaryTree<T>();
            bt.Root = RootByTwoList(preList, inList);
            return bt;
        }

        /// <summary>
        /// <para>按先根遍历序列和中根遍历序列建立二叉树</para>
        /// <para>返回构造后的二叉树的根节点</para>
        /// </summary>
        private static BinaryTreeNode<T> RootByTwoList(IList<T> preList, IList<T> inList)
        {
            BinaryTreeNode<T> p = null;
            T rootData;
            int i, k, n;
            // 当前子树先根序列 
            IList<T> presub = new List<T>();
            // 当前子树中根序列
            IList<T> insub = new List<T>();              
            n = preList.Count;
            if (n > 0)
            {
                // 当前根结点 
                rootData = preList[0];                  
                p = new BinaryTreeNode<T>(rootData);
                // 当前根在中根序列的位置 
                k = inList.IndexOf(rootData);           
                Console.WriteLine("\t current root = " + rootData + "\t k=" + k);
                // 准备当前根结点的左子树先根序列
                for (i = 0; i < k; i++)                  
                    presub.Add(preList[1 + i]);
                // 准备当前根结点的左子树中根序列 
                for (i = 0; i < k; i++)                 
                    insub.Add(inList[i]);
                // 建立当前根结点的左子树，递归
                p.Left = RootByTwoList(presub, insub);   
                presub.Clear();
                // 准备当前根结点的右子树先根序列
                for (i = 0; i < n - k - 1; i++)          
                    presub.Add(preList[k + 1 + i]);
                insub.Clear();
                // 准备当前根结点的右子树中根序列 
                for (i = 0; i < n - k - 1; i++)         
                    insub.Add(inList[k + 1 + i]);
                // 建立当前根结点的右子树，递归
                p.Right = RootByTwoList(presub, insub);  
            }
            return p;
        }


        //广义表方法
        /// <summary>
        /// 判断当前节点值是否为数据
        /// </summary>
        private static bool isData(T nodeValue)
        {
            if (nodeValue.Equals(ListFlags.NullSubtree)) return false;
            if (nodeValue.Equals(ListFlags.LeftDelimit)) return false;
            if (nodeValue.Equals(ListFlags.RightDelimit)) return false;
            if (nodeValue.Equals(ListFlags.MiddleDelimit)) return false;
            else return true;
        }

        /// <summary>
        /// <para>由一个列表构造广义表二叉树</para>
        /// <para>返回广义表二叉树</para>
        /// </summary>
        public static BinaryTree<T> ByOneList(IList<T> sList, ListFlagsStruc<T> ListFlags)
        {
            BinaryTree<T>.ListFlags = ListFlags;
            // 初始化递归变量 
            BinaryTree<T>.idx = 0;                              
            BinaryTree<T> bt = new BinaryTree<T>();
            if (sList.Count > 0)
                bt.Root = RootByOneList(sList);
            else
                bt.Root = null;
            return bt;
        }

        /// <summary>
        /// <para>由一个列表构造广义表二叉树</para>
        /// <para>返回广义表二叉树的根节点</para>
        /// </summary>
        private static BinaryTreeNode<T> RootByOneList(IList<T> sList)
        {
            BinaryTreeNode<T> p = null;
            T nodeData = sList[idx];
            if (isData(nodeData))
            {
                // 有效数据，建立结点 
                p = new BinaryTreeNode<T>(nodeData);            
                idx++;
                nodeData = sList[idx];
                if (nodeData.Equals(ListFlags.LeftDelimit))
                {
                    //左边界，如'（'，跳过 
                    idx++;
                    //建立左子树，递归
                    p.Left = RootByOneList(sList);
                    //跳过中界符，如','
                    idx++;
                    //建立右子树，递归
                    p.Right = RootByOneList(sList);
                    //跳过右边界，如')'
                    idx++;                                       
                }
            }
            //空子树符，跳过，返回null 
            if (nodeData.Equals(ListFlags.NullSubtree)) idx++; 
            return p;
        }
    }
}
