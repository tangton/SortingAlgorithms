using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithmsBusinessAction
{
    public class InsertionSort
    {
        public static List<int> Sort(List<int> collectionToSort, CancellationToken cancellationToken)
        {
            return Sort<List<int>, int>(collectionToSort, cancellationToken);
        }

        public static T Sort<T, T2>(T collectionToSort, CancellationToken cancellationToken)
            where T : IList
            where T2 : IComparable
        {
            T sortedList = Activator.CreateInstance<T>();

            foreach (var item in collectionToSort)
            {
                cancellationToken.ThrowIfCancellationRequested();
                sortedList.Add(item);
            }

            for (int i = 1; i < sortedList.Count; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                int j = i;

                while (j > 0 &&
                    ((T2)sortedList[j]).CompareTo((T2)sortedList[j - 1]) < 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    T2 tempValue = (T2)sortedList[j -1];

                    sortedList[j - 1] = sortedList[j];
                    sortedList[j] = tempValue;

                    j--;
                }

            }

            return sortedList;
        }
    }
}
