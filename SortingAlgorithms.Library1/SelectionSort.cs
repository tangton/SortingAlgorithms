using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Library
{
    public class SelectionSort : ISortingAlgorithm
    {
        public IList<T> Sort<T>(IList<T> collection, CancellationToken cancellationToken, IProgress<int> progress) where T : IComparable<T>
        {
            for (var i = 0; i < collection.Count; i++)
            {
                if (i % 100 == 0)
                {
                    progress.Report(i);
                }
                cancellationToken.ThrowIfCancellationRequested();
                var indexMinValue = i;

                for (var j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[indexMinValue]) < 0)
                    {
                        indexMinValue = j;
                    }
                }

                // perform swap
                var tempValue = collection[indexMinValue];

                collection[indexMinValue] = collection[i];
                collection[i] = tempValue;
            }

            return collection;
        }
    }
}
