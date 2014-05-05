using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithmsBusinessAction;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

namespace UnitTest
{
    [TestClass]
    public class BinaryTreeSortTest
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
        public void TestBinaryTreeSortListOfInt()
        {
            List<int> result = BinaryTreeSort.Sort<List<int>, int>(TestInitialiser.IntList, _cancellationToken, _progress);

            TestInitialiser.AssertInt(result);
        }

        [TestMethod]
        public void TestBinaryTreeSortRandomListOfInt()
        {
            List<int> result = BinaryTreeSort.Sort<List<int>, int>(_randomIntegerList, _cancellationToken, _progress);

            TestInitialiser.AssertRandom(result);
        }

        [TestMethod]
        public void TestBinaryTreeSortListOfChar()
        {
            List<char> result = BinaryTreeSort.Sort<List<char>, char>(TestInitialiser.CharList, _cancellationToken, _progress);

            TestInitialiser.AssertChar(result);
        }

        [TestMethod]
        public void TestBinaryTreeSortRandomListOfChar()
        {

        }

        [TestMethod]
        public void TestBinaryTreeSortListOfString()
        {
            ArrayList result = BinaryTreeSort.Sort<ArrayList, string>(TestInitialiser.StringList, _cancellationToken, _progress);

            TestInitialiser.AssertString(result);
        }

        [TestMethod]
        public void TestBinaryTreeSortRandomListOfString()
        {

        }
    }
}
