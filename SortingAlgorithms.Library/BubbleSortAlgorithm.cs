using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithms.Library
{
    public class BubbleSortAlgorithm : ISortingAlgorithm
    {
        public IList<T> Sort<T>(IList<T> collection, CancellationToken cancellationToken, IProgress<int> progress) where T : IComparable<T>
        {
            var sortedList = collection.ToList();

            for (var j = 0; j < sortedList.Count; j++)
            {
                if (j % 100 == 0)
                {
                    progress.Report(j);
                }
                cancellationToken.ThrowIfCancellationRequested();

                var sortCompleted = true;

                for (var i = 0; i < sortedList.Count; i++)
                {
                    if (i + 1 < sortedList.Count &&
                        sortedList[i].CompareTo(sortedList[i + 1]) > 0)
                    {
                        // swap
                        var tempValue = sortedList[i];
                        sortedList[i] = sortedList[i + 1];
                        sortedList[i + 1] = tempValue;

                        sortCompleted = false;
                    }
                }

                if (sortCompleted)
                {
                    break;
                }
            }

            return sortedList;
        }
    }
}
