using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithmsBusinessAction;
using System.Collections.Generic;
using System.Collections;

namespace UnitTest
{
    [TestClass]
    public class SelectionSortTest
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
            List<int> result = SelectionSort.Sort<List<int>, int>(TestInitialiser.IntList);

            TestInitialiser.AssertInt(result);
        }

        [TestMethod]
        public void TestSelectionSortRandomListOfInt()
        {
            List<int> result = SelectionSort.Sort<List<int>, int>(_randomIntegerList);

            TestInitialiser.AssertRandom(result);
        }

        [TestMethod]
        public void TestSelectionSortListOfChar()
        {
            List<char> result = SelectionSort.Sort<List<char>, char>(TestInitialiser.CharList);

            TestInitialiser.AssertChar(result);
        }

        [TestMethod]
        public void TestSelectionSortRandomListOfChar()
        {

        }

        [TestMethod]
        public void TestSelectionSortListOfString()
        {
            ArrayList result = SelectionSort.Sort<ArrayList, string>(TestInitialiser.StringList);

            TestInitialiser.AssertString(result);
        }

        [TestMethod]
        public void TestSelectionSortRandomListOfString()
        {

        }
    }
}
