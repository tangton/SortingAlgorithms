using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithmsBusinessAction;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

namespace UnitTest
{
    [TestClass]
    public class InsertionSortTest
    {
        List<int> _randomIntegerList = new List<int>();
        CancellationToken _cancellationToken = new CancellationToken();

        [TestInitialize()]
        public void Initialize()
        {
            _randomIntegerList = TestInitialiser.RandomIntList;
        }

        [TestMethod]
        public void TestSelectionSortListOfInt()
        {
            List<int> result = InsertionSort.Sort<List<int>, int>(TestInitialiser.IntList, _cancellationToken);

            TestInitialiser.AssertInt(result);
        }

        [TestMethod]
        public void TestInsertionSortRandomListOfInt()
        {
            List<int> result = InsertionSort.Sort<List<int>, int>(_randomIntegerList, _cancellationToken);

            TestInitialiser.AssertRandom(result);
        }

        [TestMethod]
        public void TestInsertionSortListOfChar()
        {
            List<char> result = InsertionSort.Sort<List<char>, char>(TestInitialiser.CharList, _cancellationToken);

            TestInitialiser.AssertChar(result);
        }

        [TestMethod]
        public void TestInsertionSortRandomListOfChar()
        {

        }

        [TestMethod]
        public void TestInsertionSortListOfString()
        {
            ArrayList result = InsertionSort.Sort<ArrayList, string>(TestInitialiser.StringList, _cancellationToken);

            TestInitialiser.AssertString(result);
        }

        [TestMethod]
        public void TestInsertionSortRandomListOfString()
        {

        }
    }
}
