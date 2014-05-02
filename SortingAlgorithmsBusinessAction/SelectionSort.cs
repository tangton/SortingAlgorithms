using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithmsBusinessAction
{
    public class SelectionSort
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

            T2 tempValue;
            int indexMinValue;

            for (int i = 0; i < sortedList.Count; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                indexMinValue = i;

                for (int j = i + 1; j < sortedList.Count; j++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (((T2)sortedList[j]).CompareTo((T2)sortedList[indexMinValue]) < 0)
                    {
                        indexMinValue = j;
                    }
                }

                // perform swap
                tempValue = (T2)sortedList[indexMinValue];

                sortedList[indexMinValue] = sortedList[i];
                sortedList[i] = tempValue;
            }

            return sortedList;
        }
    }
}
