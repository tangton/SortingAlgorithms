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
    public class BinarySearchTree
    {
        public static List<int> Sort(List<int> collectionToSort, CancellationToken cancellationToken, IProgress<int> progress)
        {
            return Sort<List<int>, int>(collectionToSort, cancellationToken, progress);
        }

        public static T Sort<T, T2>(T collectionToSort, CancellationToken cancellationToken, IProgress<int> progress)
            where T : IList
            where T2 : IComparable
        {
            BinaryTreeNode<T2> binaryTree = new BinaryTreeNode<T2>();

            for(int i = 0; i < collectionToSort.Count; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (i % 100 == 1)
                {
                    progress.Report(i);
                }
                binaryTree.Insert((T2)collectionToSort[i]);
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
