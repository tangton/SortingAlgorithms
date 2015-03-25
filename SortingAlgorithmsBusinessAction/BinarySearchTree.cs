using SortingAlgorithmsBusinessAction.BinaryTree;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SortingAlgorithmsBusinessAction
{
    public class BinarySearchTree
    {
        public static List<int> Sort(List<int> collectionToSort, CancellationToken cancellationToken, IProgress<int> progress)
        {
            return Sort<int>(collectionToSort, cancellationToken, progress);
        }

        public static List<T> Sort<T>(List<T> collectionToSort, CancellationToken cancellationToken, IProgress<int> progress)
            where T : IComparable<T>
        {
            var binaryTree = new BinaryTreeNode<T>();

            for(var i = 0; i < collectionToSort.Count; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (i % 100 == 1)
                {
                    progress.Report(i);
                }
                binaryTree.Insert(collectionToSort[i]);
            }

            var sortedList = new List<T>();

            ReadTree<T>(binaryTree, sortedList);

            return sortedList;
        }

        private static void ReadTree<T>(BinaryTreeNode<T> node, ICollection<T> list)
            where T : IComparable<T>
        {
            var temp = node;
            if (temp == null)
            {
                return;
            }

            ReadTree<T>(temp.LeftNode, list);
            list.Add(temp.Value);
            ReadTree<T>(temp.RightNode, list);
        }
    }
}
