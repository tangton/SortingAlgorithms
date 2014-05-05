using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithmsBusinessAction
{
    public class BubbleSort
    {
        public static List<int> Sort(List<int> collectionToSort, CancellationToken cancellationToken, IProgress<int> progress)
        {
            return Sort<List<int>, int>(collectionToSort, cancellationToken, progress);
        }

        public static T Sort<T, T2>(T collectionToSort, CancellationToken cancellationToken, IProgress<int> progress)
            where T : IList
            where T2 : IComparable
        {
            T sortedList = Activator.CreateInstance<T>();

            foreach (var item in collectionToSort)
            {
                sortedList.Add(item);
            }

            for (int j = 0; j < sortedList.Count; j++)
            {
                if (j % 100 == 0)
                {
                    progress.Report(j);
                }
                cancellationToken.ThrowIfCancellationRequested();
                for (int i = 0; i < sortedList.Count; i++)
                {
                    if (i + 1 < sortedList.Count &&
                        ((T2)sortedList[i]).CompareTo((T2)sortedList[i + 1]) > 0)
                    {
                        // swap
                        T2 tempValue = (T2)sortedList[i];
                        sortedList[i] = sortedList[i + 1];
                        sortedList[i + 1] = tempValue;
                    }
                }
            }

            return sortedList;
        }
    }
}
