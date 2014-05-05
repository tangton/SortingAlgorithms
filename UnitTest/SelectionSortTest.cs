﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithmsBusinessAction;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

namespace UnitTest
{
    [TestClass]
    public class SelectionSortTest
    {
        List<int> _randomIntegerList = new List<int>();
        CancellationToken _cancellationToken = new CancellationToken();
        Progress<int> _progress = new Progress<int>();

        [TestInitialize()]
        public void Initialize()
        {
            _randomIntegerList = TestInitialiser.RandomIntList;
        }

        [TestMethod]
        public void TestSelectionSortListOfInt()
        {
            List<int> result = SelectionSort.Sort<List<int>, int>(TestInitialiser.IntList, _cancellationToken, _progress);

            TestInitialiser.AssertInt(result);
        }

        [TestMethod]
        public void TestSelectionSortRandomListOfInt()
        {
            List<int> result = SelectionSort.Sort<List<int>, int>(_randomIntegerList, _cancellationToken, _progress);

            TestInitialiser.AssertRandom(result);
        }

        [TestMethod]
        public void TestSelectionSortListOfChar()
        {
            List<char> result = SelectionSort.Sort<List<char>, char>(TestInitialiser.CharList, _cancellationToken, _progress);

            TestInitialiser.AssertChar(result);
        }

        [TestMethod]
        public void TestSelectionSortRandomListOfChar()
        {

        }

        [TestMethod]
        public void TestSelectionSortListOfString()
        {
            ArrayList result = SelectionSort.Sort<ArrayList, string>(TestInitialiser.StringList, _cancellationToken, _progress);

            TestInitialiser.AssertString(result);
        }

        [TestMethod]
        public void TestSelectionSortRandomListOfString()
        {

        }
    }
}
