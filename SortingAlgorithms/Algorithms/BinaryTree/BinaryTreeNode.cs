using System;

namespace SortingAlgorithms.Algorithms.BinaryTree
{
    public class BinaryTreeNode<T> where T : IComparable<T>
    {
        private bool _valueSet = false;

        private T _value = default(T);
        private BinaryTreeNode<T> _leftNode = null;
        private BinaryTreeNode<T> _rightNode = null;

        public T Value 
        { 
            get { return _value; } 
        }

        public BinaryTreeNode<T> LeftNode 
        {
            get { return _leftNode; }
        }

        public BinaryTreeNode<T> RightNode 
        {
            get { return _rightNode; }
        }

        public BinaryTreeNode()
        {

        }

        public BinaryTreeNode(T value)
        {
            _value = value;
            _valueSet = true;
        }

        public void Insert(T value)
        {
            if (_leftNode == null && _rightNode == null && _valueSet == false)
            {
                _value = value;
                _valueSet = true;
            }
            else if (value.CompareTo(_value) < 0)
            {
                if (_leftNode == null)
                {
                    _leftNode = new BinaryTreeNode<T>(value);
                }
                else
                {
                    _leftNode.Insert(value);
                }
            }
            else
            {
                if (_rightNode == null)
                {
                    _rightNode = new BinaryTreeNode<T>(value);
                }
                else
                {
                    _rightNode.Insert(value);
                }
            }
        }
    }
}
