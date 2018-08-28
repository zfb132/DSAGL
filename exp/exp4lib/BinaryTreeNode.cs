using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    public class BinaryTreeNode<T>
    {
        /// <summary>
        /// 数据元素
        /// </summary>
        private T data;
  
        /// <summary>
        /// 指向左、右结点的链
        /// </summary>
        private BinaryTreeNode<T> left, right;   
        
        /// <summary>
        /// 构造空的二叉树节点
        /// </summary>
        public BinaryTreeNode()
        {
            left = right = null;
        }

        /// <summary>
        /// 构造一个有值结点
        /// </summary>
        public BinaryTreeNode(T d)
        {
            data = d;
            left = right = null;
        }

        /// <summary>
        /// 二叉树结点存储的数据
        /// </summary>
        public T Data { get => data; set => data = value; }

        /// <summary>
        /// 二叉树的左节点
        /// </summary>
        public BinaryTreeNode<T> Left { get =>  left; set => left = value; }

        /// <summary>
        /// 二叉树的右节点
        /// </summary>
        public BinaryTreeNode<T> Right { get => right; set => right = value; }

        /// <summary>
        /// 递归输出本结点为根结点的二叉树, 先根次序，输出在控制台
        /// </summary>
        public void ShowPreOrder()
        {
            Console.Write(this.Data + " ");
            BinaryTreeNode<T> q = this.Left;
            if (q != null)
                q.ShowPreOrder();
            q = this.Right;
            if (q != null)
                q.ShowPreOrder();
        }

        /// <summary>
        /// 先根次序遍历以本结点为根结点的二叉树, 将各结点的值存放在表sql中
        /// </summary>
        public void TraversalPreOrder(IList<T> sql)
        {
            sql.Add(this.Data);
            BinaryTreeNode<T> q = this.Left;
            if (q != null)
                q.TraversalPreOrder(sql);
            q = this.Right;
            if (q != null)
                q.TraversalPreOrder(sql);
        }

        /// <summary>
        /// 中根次序遍历以某结点为根的二叉树的递归方法，输出在控制台
        /// </summary>
        public void ShowInOrder()
        {
            BinaryTreeNode<T> q = this.Left;
            if (q != null)
                q.ShowInOrder();
            Console.Write(this.Data + " ");
            q = this.Right;
            if (q != null)
                q.ShowInOrder();
        }

        /// <summary>
        /// 中根次序遍历以某结点为根的二叉树的递归方法，将各结点的值存放在表sql中
        /// </summary>
        public void TraversalInOrder(IList<T> sql)
        {
            BinaryTreeNode<T> q = this.Left;
            if (q != null)
                q.TraversalInOrder(sql);
            sql.Add(this.Data);
            q = this.Right;
            if (q != null)
                q.TraversalInOrder(sql);
        }

        /// <summary>
        /// 后根次序遍历以某结点为根的二叉树的递归方法，输出在控制台
        /// </summary>
        public void ShowPostOrder()
        {
            BinaryTreeNode<T> q = this.Left;
            if (q != null)
                q.ShowPostOrder();
            q = this.Right;
            if (q != null)
                q.ShowPostOrder();
            Console.Write(this.Data + " ");
        }

        /// <summary>
        /// 后根次序遍历以某结点为根的二叉树的递归方法，将各结点的值存放在表sql中
        /// </summary>
        public void TraversalPostOrder(IList<T> sql)
        {
            BinaryTreeNode<T> q = this.Left;
            if (q != null)
                q.TraversalPostOrder(sql);
            q = this.Right;
            if (q != null)
                q.TraversalPostOrder(sql);
            sql.Add(this.Data);
        }
    }
}
