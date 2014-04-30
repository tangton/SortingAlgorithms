using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithmsBusinessAction;
using System.Collections.Generic;
using System.Collections;

namespace UnitTest
{
    [TestClass]
    public class InsertionSortTest
    {
        List<int> _randomIntegerList = new List<int>();

        [TestInitialize()]
        public void Initialize()
        {
            _randomIntegerList = TestInitialiser.RandomIntList;
        }

        [TestMethod]
        public void TestSelectionSortListOfInt()
        {
            List<int> result = InsertionSort.Sort<List<int>, int>(TestInitialiser.IntList);

            TestInitialiser.AssertInt(result);
        }

        [TestMethod]
        public void TestInsertionSortRandomListOfInt()
        {
            List<int> result = InsertionSort.Sort<List<int>, int>(_randomIntegerList);

            TestInitialiser.AssertRandom(result);
        }

        [TestMethod]
        public void TestInsertionSortListOfChar()
        {
            List<char> result = InsertionSort.Sort<List<char>, char>(TestInitialiser.CharList);

            TestInitialiser.AssertChar(result);
        }

        [TestMethod]
        public void TestInsertionSortRandomListOfChar()
        {

        }

        [TestMethod]
        public void TestInsertionSortListOfString()
        {
            ArrayList result = InsertionSort.Sort<ArrayList, string>(TestInitialiser.StringList);

            TestInitialiser.AssertString(result);
        }

        [TestMethod]
        public void TestInsertionSortRandomListOfString()
        {

        }
    }
}
