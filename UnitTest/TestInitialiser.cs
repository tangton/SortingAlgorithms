using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public static class TestInitialiser
    {
        static List<int> _intList = new List<int> { 1, 10, 10, 5, 0, -1 };
        static List<int> _randomIntList = GetAndInitializeRandomIntList();

        static List<char> _charList = new List<char> { 'z', 'b', 'a', 'b' };
        static ArrayList _stringList = new ArrayList { "One", "Two", "Three", "Four" };

        public static List<int> IntList
        {
            get
            {
                return _intList;
            }
        }

        public static List<char> CharList
        {
            get
            {
                return _charList;
            }
        }

        public static ArrayList StringList
        {
            get
            {
                return _stringList;
            }
        }

        private static List<int> GetAndInitializeRandomIntList()
        {
            List<int> randomIntList = new List<int>();

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                randomIntList.Add(random.Next(1000));
            }

            return randomIntList;
        }

        public static List<int> RandomIntList
        {
            get
            {
                return _randomIntList;
            }
        }

        public static void AssertInt(IList result)
        {
            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(0, result[1]);
            Assert.AreEqual(1, result[2]);
            Assert.AreEqual(5, result[3]);
            Assert.AreEqual(10, result[4]);
            Assert.AreEqual(10, result[5]);
        }

        public static void AssertRandom(IList result)
        {
            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue((int)result[i] <= (int)result[i + 1]);
            }
        }

        public static void AssertChar(IList result)
        {
            Assert.AreEqual('a', result[0]);
            Assert.AreEqual('b', result[1]);
            Assert.AreEqual('b', result[2]);
            Assert.AreEqual('z', result[3]);
        }

        public static void AssertString(IList result)
        {
            Assert.AreEqual("Four", result[0]);
            Assert.AreEqual("One", result[1]);
            Assert.AreEqual("Three", result[2]);
            Assert.AreEqual("Two", result[3]);
        }
    }
}
