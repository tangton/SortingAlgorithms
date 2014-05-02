using SortingAlgorithmsBusinessAction.BinaryTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithmsBusinessAction
{
    public class BinaryTreeSort
    {
        public static List<int> Sort(List<int> collectionToSort, CancellationToken cancellationToken)
        {
            return Sort<List<int>, int>(collectionToSort, cancellationToken);
        }

        public static T Sort<T, T2>(T collectionToSort, CancellationToken cancellationToken)
            where T : IList
            where T2 : IComparable
        {
            BinaryTreeNode<T2> binaryTree = new BinaryTreeNode<T2>();

            foreach (T2 item in collectionToSort)
            {
                cancellationToken.ThrowIfCancellationRequested();
                binaryTree.Insert(item);
            }

            T sortedList = Activator.CreateInstance<T>();

            ReadTree<T, T2>(binaryTree, sortedList, cancellationToken);

            return sortedList;
        }

        private static void ReadTree<T, T2>(BinaryTreeNode<T2> node, T list, CancellationToken cancellationToken)
            where T : IList
            where T2 : IComparable
        {
            cancellationToken.ThrowIfCancellationRequested();
            BinaryTreeNode<T2> temp = node;
            if (temp == null)
            {
                return;
            }

            ReadTree<T, T2>(temp.LeftNode, list, cancellationToken);
            list.Add(temp.Value);
            ReadTree<T, T2>(temp.RightNode, list, cancellationToken);
        }
    }
}
