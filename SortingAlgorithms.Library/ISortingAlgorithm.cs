using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithms.Library
{
    public interface ISortingAlgorithm
    {
        IEnumerable<T> Sort<T>(IEnumerable<T> values, CancellationToken cancellationToken, IProgress<int> progress) where T : IComparable<T>;
    }
}
