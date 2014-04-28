﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithmsBusinessAction;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class SelectionSortTest
    {
        [TestMethod]
        public void TestSelectionSortListOfInt()
        {
            List<int> testList = new List<int> { 1, 10, 10, 5 };

            List<int> result = SelectionSort.Sort<List<int>, int>(testList);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(5, result[1]);
            Assert.AreEqual(10, result[2]);
            Assert.AreEqual(10, result[3]);
        }

        [TestMethod]
        public void TestSelectionSortListOfChar()
        {
            List<char> testList = new List<char> { 'z', 'b', 'a', 'b' };

            List<char> result = SelectionSort.Sort<List<char>, char>(testList);

            Assert.AreEqual('a', result[0]);
            Assert.AreEqual('b', result[1]);
            Assert.AreEqual('b', result[2]);
            Assert.AreEqual('z', result[3]);
        }
    }
}
