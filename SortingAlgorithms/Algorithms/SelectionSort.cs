using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SortingAlgorithms.Algorithms
{
    public class SelectionSort
    {
        public static List<T> Sort<T>(List<T> collectionToSort, CancellationToken cancellationToken, IProgress<int> progress)
            where T : IComparable<T>
        {
            var sortedList = collectionToSort.ToList();

            for (var i = 0; i < sortedList.Count; i++)
            {
                if (i % 100 == 0)
                { 
                    progress.Report(i);
                }
                cancellationToken.ThrowIfCancellationRequested();
                var indexMinValue = i;

                for (var j = i + 1; j < sortedList.Count; j++)
                {
                    if (sortedList[j].CompareTo(sortedList[indexMinValue]) < 0)
                    {
                        indexMinValue = j;
                    }
                }

                // perform swap
                var tempValue = sortedList[indexMinValue];

                sortedList[indexMinValue] = sortedList[i];
                sortedList[i] = tempValue;
            }

            return sortedList;
        }
    }
}
