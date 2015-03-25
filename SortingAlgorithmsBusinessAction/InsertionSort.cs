using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SortingAlgorithmsBusinessAction
{
    public class InsertionSort
    {
        public static List<int> Sort(List<int> collectionToSort, CancellationToken cancellationToken, IProgress<int> progress)
        {
            return Sort<int>(collectionToSort, cancellationToken, progress);
        }

        public static List<T> Sort<T>(List<T> collectionToSort, CancellationToken cancellationToken, IProgress<int> progress)
            where T : IComparable<T>
        {
            var sortedList = collectionToSort.ToList();

            for (var i = 1; i < sortedList.Count; i++)
            {
                if (i % 100 == 0)
                {
                    progress.Report(i);
                }
                cancellationToken.ThrowIfCancellationRequested();
                var j = i;

                while (j > 0 &&
                    sortedList[j - 1].CompareTo(sortedList[j]) > 0)
                {
                    var tempValue = sortedList[j -1];

                    sortedList[j - 1] = sortedList[j];
                    sortedList[j] = tempValue;

                    j--;
                }
            }

            return sortedList;
        }
    }
}
