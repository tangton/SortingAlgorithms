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
        List<int> _randomIntList = new List<int>();
        List<char> _randomCharList = new List<char>();

        CancellationToken _cancellationToken = new CancellationToken();
        Progress<int> _progress = new Progress<int>();

        [TestInitialize()]
        public void Initialize()
        {
            _randomIntList = TestInitialiser.RandomIntList;
            _randomCharList = TestInitialiser.RandomCharList;
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
            List<int> result = SelectionSort.Sort<List<int>, int>(_randomIntList, _cancellationToken, _progress);

            TestInitialiser.AssertRandom<int>(result);
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
            List<char> result = SelectionSort.Sort<List<char>, char>(_randomCharList, _cancellationToken, _progress);

            TestInitialiser.AssertRandom<char>(result);
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
