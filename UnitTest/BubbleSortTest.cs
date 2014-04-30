using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithmsBusinessAction;
using System.Collections.Generic;
using System.Collections;

namespace UnitTest
{
    [TestClass]
    public class BubbleSortTest
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
            List<int> result = BubbleSort.Sort<List<int>, int>(TestInitialiser.IntList);

            TestInitialiser.AssertInt(result);
        }

        [TestMethod]
        public void TestBubbleSortRandomListOfInt()
        {
            List<int> result = BubbleSort.Sort<List<int>, int>(_randomIntegerList);

            TestInitialiser.AssertRandom(result);
        }

        [TestMethod]
        public void TestBubbleSortListOfChar()
        {
            List<char> result = BubbleSort.Sort<List<char>, char>(TestInitialiser.CharList);

            TestInitialiser.AssertChar(result);
        }

        [TestMethod]
        public void TestBubbleSortRandomListOfChar()
        {

        }

        [TestMethod]
        public void TestBubbleSortListOfString()
        {
            ArrayList result = BubbleSort.Sort<ArrayList, string>(TestInitialiser.StringList);

            TestInitialiser.AssertString(result);
        }

        [TestMethod]
        public void TestBubbleSortRandomListOfString()
        {

        }
    }
}
