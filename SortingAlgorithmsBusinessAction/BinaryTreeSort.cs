using SortingAlgorithmsBusinessAction.BinaryTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmsBusinessAction
{
    public class BinaryTreeSort
    {
        public static List<int> Sort(List<int> collectionToSort)
        {
            return Sort<List<int>, int>(collectionToSort);
        }

        public static T Sort<T, T2>(T collectionToSort)
            where T : IList
            where T2 : IComparable
        {
            BinaryTreeNode<T2> binaryTree = new BinaryTreeNode<T2>();

            foreach (T2 item in collectionToSort)
            {
                binaryTree.Insert(item);
            }

            T sortedList = Activator.CreateInstance<T>();

            ReadTree<T, T2>(binaryTree, sortedList);

            return sortedList;
        }

        private static void ReadTree<T, T2>(BinaryTreeNode<T2> node, T list)
            where T : IList
            where T2 : IComparable
        {
            BinaryTreeNode<T2> temp = node;
            if (temp == null)
            {
                return;
            }

            ReadTree<T, T2>(temp.LeftNode, list);
            list.Add(temp.Value);
            ReadTree<T, T2>(temp.RightNode, list);
        }
    }
}
