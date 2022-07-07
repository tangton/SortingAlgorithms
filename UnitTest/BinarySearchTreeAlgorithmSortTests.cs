using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using SortingAlgorithms.Library;

namespace UnitTest
{
    [TestClass]
    public class BinarySearchTreeAlgorithmSortTests
    {
        List<int> _intLists;
        List<char> _charLists;
        List<string> _stringList;

        readonly CancellationToken _cancellationToken = new CancellationToken();
        readonly Progress<int> _progress = new Progress<int>();


        [TestInitialize()]
        public void Initialize()
        {
            _intLists = new List<int> { 1, 10, 10, 5, 0, -1 };
            _charLists = new List<char> { 'z', 'b', 'a', 'b' };
            _stringList = new List<string> { "One", "Two", "Three", "Four" };
        }

        [TestMethod]
        public void TestSortListOfInt()
        {
            var sortingAlgorithm = new BinarySearchTreeAlgorithm();

            var result = sortingAlgorithm.Sort<int>(_intLists, _cancellationToken, _progress);

            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(0, result[1]);
            Assert.AreEqual(1, result[2]);
            Assert.AreEqual(5, result[3]);
            Assert.AreEqual(10, result[4]);
            Assert.AreEqual(10, result[5]);
        }

        [TestMethod]
        public void TestSortListOfChar()
        {
            var sortingAlgorithm = new BinarySearchTreeAlgorithm();

            var result = sortingAlgorithm.Sort<char>(_charLists, _cancellationToken, _progress);

            Assert.AreEqual('a', result[0]);
            Assert.AreEqual('b', result[1]);
            Assert.AreEqual('b', result[2]);
            Assert.AreEqual('z', result[3]);
        }

        [TestMethod]
        public void TestSortListOfString()
        {
            var sortingAlgorithm = new BinarySearchTreeAlgorithm();

            var result = sortingAlgorithm.Sort<string>(_stringList, _cancellationToken, _progress);

            Assert.AreEqual("Four", result[0]);
            Assert.AreEqual("One", result[1]);
            Assert.AreEqual("Three", result[2]);
            Assert.AreEqual("Two", result[3]);
        }
    }
}
