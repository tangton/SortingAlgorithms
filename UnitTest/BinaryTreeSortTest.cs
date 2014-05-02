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

        [TestInitialize()]
        public void Initialize()
        {
            _randomIntegerList = TestInitialiser.RandomIntList;
        }

        [TestMethod]
        public void TestBinaryTreeSortListOfInt()
        {
            List<int> result = BinaryTreeSort.Sort<List<int>, int>(TestInitialiser.IntList, _cancellationToken);

            TestInitialiser.AssertInt(result);
        }

        [TestMethod]
        public void TestBinaryTreeSortRandomListOfInt()
        {
            List<int> result = BinaryTreeSort.Sort<List<int>, int>(_randomIntegerList, _cancellationToken);

            TestInitialiser.AssertRandom(result);
        }

        [TestMethod]
        public void TestBinaryTreeSortListOfChar()
        {
            List<char> result = BinaryTreeSort.Sort<List<char>, char>(TestInitialiser.CharList, _cancellationToken);

            TestInitialiser.AssertChar(result);
        }

        [TestMethod]
        public void TestBinaryTreeSortRandomListOfChar()
        {

        }

        [TestMethod]
        public void TestBinaryTreeSortListOfString()
        {
            ArrayList result = BinaryTreeSort.Sort<ArrayList, string>(TestInitialiser.StringList, _cancellationToken);

            TestInitialiser.AssertString(result);
        }

        [TestMethod]
        public void TestBinaryTreeSortRandomListOfString()
        {

        }
    }
}
