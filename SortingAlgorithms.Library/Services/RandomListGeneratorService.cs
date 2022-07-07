using System;
using System.Collections.Generic;

namespace SortingAlgorithms.Library.Services
{
    public interface IRandomListGeneratorService
    {
        IList<int> GenerateRandomList(int listSize);
    }

    public class RandomListGeneratorService : IRandomListGeneratorService
    {
        public IList<int> GenerateRandomList(int listSize)
        {
            var randomIntList = new List<int>();

            var random = new Random();
            for (var i = 0; i < listSize; i++)
            {
                randomIntList.Add(random.Next(1000));
            }

            return randomIntList;
        }
    }
}
