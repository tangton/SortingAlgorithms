using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithmsBusinessAction;
using System.Collections.Generic;
using System.Collections;

namespace UnitTest
{
    [TestClass]
    public class SortTest
    {
        List<int> testListInt = new List<int> { 1, 10, 10, 5 };
        List<char> testListChar = new List<char> { 'z', 'b', 'a', 'b' };
        ArrayList testListString = new ArrayList { "One", "Two", "Three", "Four" };

        [TestMethod]
        public void TestSelectionSortListOfInt()
        {
            List<int> result = SelectionSort.Sort<List<int>, int>(testListInt);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(5, result[1]);
            Assert.AreEqual(10, result[2]);
            Assert.AreEqual(10, result[3]);
        }

        [TestMethod]
        public void TestBubbleSortListOfInt()
        {
            List<int> result = BubbleSort.Sort<List<int>, int>(testListInt);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(5, result[1]);
            Assert.AreEqual(10, result[2]);
            Assert.AreEqual(10, result[3]);
        }

        [TestMethod]
        public void TestInsertionSortListOfInt()
        {
            List<int> result = InsertionSort.Sort<List<int>, int>(testListInt);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(5, result[1]);
            Assert.AreEqual(10, result[2]);
            Assert.AreEqual(10, result[3]);
        }

        [TestMethod]
        public void TestSelectionSortListOfChar()
        {
            List<char> result = SelectionSort.Sort<List<char>, char>(testListChar);

            Assert.AreEqual('a', result[0]);
            Assert.AreEqual('b', result[1]);
            Assert.AreEqual('b', result[2]);
            Assert.AreEqual('z', result[3]);
        }

        [TestMethod]
        public void TestBubbleSortListOfChar()
        {
            List<char> result = BubbleSort.Sort<List<char>, char>(testListChar);

            Assert.AreEqual('a', result[0]);
            Assert.AreEqual('b', result[1]);
            Assert.AreEqual('b', result[2]);
            Assert.AreEqual('z', result[3]);
        }

        [TestMethod]
        public void TestInsertionSortListOfChar()
        {
            List<char> result = InsertionSort.Sort<List<char>, char>(testListChar);

            Assert.AreEqual('a', result[0]);
            Assert.AreEqual('b', result[1]);
            Assert.AreEqual('b', result[2]);
            Assert.AreEqual('z', result[3]);
        }

        [TestMethod]
        public void TestSelectionSortArrayOfString()
        {
            ArrayList result = SelectionSort.Sort<ArrayList, string>(testListString);

            Assert.AreEqual("Four", result[0]);
            Assert.AreEqual("One", result[1]);
            Assert.AreEqual("Three", result[2]);
            Assert.AreEqual("Two", result[3]);
        }

        [TestMethod]
        public void TestBubbleSortArrayOfString()
        {
            ArrayList result = BubbleSort.Sort<ArrayList, string>(testListString);

            Assert.AreEqual("Four", result[0]);
            Assert.AreEqual("One", result[1]);
            Assert.AreEqual("Three", result[2]);
            Assert.AreEqual("Two", result[3]);
        }

        [TestMethod]
        public void TestInsertionSortArrayOfString()
        {
            ArrayList result = InsertionSort.Sort<ArrayList, string>(testListString);

            Assert.AreEqual("Four", result[0]);
            Assert.AreEqual("One", result[1]);
            Assert.AreEqual("Three", result[2]);
            Assert.AreEqual("Two", result[3]);
        }
    }
}
