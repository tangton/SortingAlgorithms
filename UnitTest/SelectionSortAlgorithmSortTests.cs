using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using SortingAlgorithms.Library;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class SelectionSortAlgorithmSortTests
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
            var sortingAlgorithm = new SelectionSortAlgorithm();

            var result = sortingAlgorithm.Sort<int>(_intLists, _cancellationToken, _progress);
            var resultList = result.ToList();

            Assert.AreEqual(-1, resultList[0]);
            Assert.AreEqual(0, resultList[1]);
            Assert.AreEqual(1, resultList[2]);
            Assert.AreEqual(5, resultList[3]);
            Assert.AreEqual(10, resultList[4]);
            Assert.AreEqual(10, resultList[5]);
        }

        [TestMethod]
        public void TestSortListOfChar()
        {
            var sortingAlgorithm = new SelectionSortAlgorithm();

            var result = sortingAlgorithm.Sort<char>(_charLists, _cancellationToken, _progress);
            var resultList = result.ToList();

            Assert.AreEqual('a', resultList[0]);
            Assert.AreEqual('b', resultList[1]);
            Assert.AreEqual('b', resultList[2]);
            Assert.AreEqual('z', resultList[3]);
        }

        [TestMethod]
        public void TestSortListOfString()
        {
            var sortingAlgorithm = new SelectionSortAlgorithm();

            var result = sortingAlgorithm.Sort<string>(_stringList, _cancellationToken, _progress);
            var resultList = result.ToList();

            Assert.AreEqual("Four", resultList[0]);
            Assert.AreEqual("One", resultList[1]);
            Assert.AreEqual("Three", resultList[2]);
            Assert.AreEqual("Two", resultList[3]);
        }
    }
}
