using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithms.Library
{
    public class InsertionSortAlgorithm : ISortingAlgorithm
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> collection, CancellationToken cancellationToken, IProgress<int> progress) where T : IComparable<T>
        {
            var sortedList = collection.ToList();

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
                    var tempValue = sortedList[j - 1];

                    sortedList[j - 1] = sortedList[j];
                    sortedList[j] = tempValue;

                    j--;
                }
            }

            return sortedList;
        }
    }
}
