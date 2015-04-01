using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using SortingAlgorithms.Algorithms;

namespace UnitTest
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        List<int> _randomIntList = new List<int>();
        List<char> _randomCharList = new List<char>();

        readonly CancellationToken _cancellationToken = new CancellationToken();
        readonly Progress<int> _progress = new Progress<int>();

        [TestInitialize()]
        public void Initialize()
        {
            _randomIntList = TestInitialiser.RandomIntList;
            _randomCharList = TestInitialiser.RandomCharList;
        }

        [TestMethod]
        public void TestBinarySearchTreeListOfInt()
        {
            var result = BinarySearchTree.Sort<int>(TestInitialiser.IntList, _cancellationToken, _progress);

            TestInitialiser.AssertInt(result);
        }

        [TestMethod]
        public void TestBinarySearchTreeRandomListOfInt()
        {
            var result = BinarySearchTree.Sort<int>(_randomIntList, _cancellationToken, _progress);

            TestInitialiser.AssertRandom<int>(result);
        }

        [TestMethod]
        public void TestBinarySearchTreeListOfChar()
        {
            var result = BinarySearchTree.Sort<char>(TestInitialiser.CharList, _cancellationToken, _progress);

            TestInitialiser.AssertChar(result);
        }

        [TestMethod]
        public void TestBinarySearchTreeRandomListOfChar()
        {
            var result = BinarySearchTree.Sort<char>(_randomCharList, _cancellationToken, _progress);

            TestInitialiser.AssertRandom<char>(result);
        }

        [TestMethod]
        public void TestBinarySearchTreeListOfString()
        {
            var result = BinarySearchTree.Sort<string>(TestInitialiser.StringList, _cancellationToken, _progress);

            TestInitialiser.AssertString(result);
        }

        [TestMethod]
        public void TestBinarySearchTreeRandomListOfString()
        {

        }
    }
}
