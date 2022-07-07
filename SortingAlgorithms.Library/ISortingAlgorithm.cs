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
        IList<T> Sort<T>(IList<T> values, CancellationToken cancellationToken, IProgress<int> progress) where T : IComparable<T>;
    }
}
