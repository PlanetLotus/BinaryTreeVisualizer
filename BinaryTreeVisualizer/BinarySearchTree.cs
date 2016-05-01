using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeVisualizer
{
    public sealed class BinarySearchTree<T>
    {
        public Node<T> Root { get; set; }

        public void Insert(T data)
        {
        }

        public void Delete(T data)
        {
        }

        public T GetMin()
        {
            if (Root == null)
            {
                return default(T);
            }

            Node<T> node = Root;
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node.Data;
        }

        public T GetMax()
        {
            if (Root == null)
            {
                return default(T);
            }

            Node<T> node = Root;
            while (node.Right != null)
            {
                node = node.Right;
            }

            return node.Data;
        }
    }
}
