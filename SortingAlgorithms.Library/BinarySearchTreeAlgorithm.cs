using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithms.Library
{
    public class BinarySearchTreeAlgorithm : ISortingAlgorithm
    {
        public IList<T> Sort<T>(IList<T> collection, CancellationToken cancellationToken, IProgress<int> progress) where T : IComparable<T>
        {
            var binaryTree = new BinaryTreeNode<T>();

            for (var i = 0; i < collection.Count; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (i % 100 == 1)
                {
                    progress.Report(i);
                }
                binaryTree.Insert(collection[i]);
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
