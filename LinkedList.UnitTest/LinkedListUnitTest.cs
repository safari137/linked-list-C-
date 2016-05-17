using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.UnitTest
{
    [TestClass]
    public class LinkedListUnitTest
    {
        private readonly MyLinkedList<object> _list = new MyLinkedList<object>();

        [TestMethod]
        public void Constructor_SetsCount_To_0()
        {
            Assert.AreEqual(_list.Count, 0);
        }

        [TestMethod]
        public void Add_IncrementsCount_To_1()
        {
            var node = new Node<object>("object data");

            _list.Add(node);

            Assert.AreEqual(_list.Count, 1);
        }

        [TestMethod]
        public void ToArray_ConvertsList_ToArray()
        {
            var node = new Node<object>("object data");
            _list.Add(node);

            var listArray = _list.ToArray();

            Assert.IsInstanceOfType(listArray, typeof(Array));
            Assert.AreEqual(listArray.Length, 1);
        }

        [TestMethod]
        public void ToArray_ReturnsEmptyArray_WhenBaseNodeIsNull()
        {
            var listArray = _list.ToArray();

            Assert.AreEqual(listArray.Length, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Remove_ThrowsException_WhenIndexIsOutOfRane()
        {
            _list.Remove(10);
        }

        [TestMethod]
        public void Remove_ReturnsObjectRemoved()
        {
            var node = new Node<object>("stuff");
            _list.Add(node.Data);
            var removedNode = _list.Remove(0);

            Assert.AreEqual(node.Data, removedNode);
        }

        [TestMethod]
        public void Remove_CountDecrements_By_1()
        {
            var node = new Node<object>("dog");
            _list.Add(node);

            _list.Remove(0);

            Assert.AreEqual(_list.Count, 0);
        }

        [TestMethod]
        public void Remove_RemovesCorrectNode()
        {
            var nodeToStay = new Node<object>("stay");
            var nodeToRemove = new Node<object>("remove");

            _list.Add("remove");
            _list.Add("stay");

            _list.Remove(0);

            Assert.AreEqual(_list.GetElemantAt(0), nodeToStay.Data);
        }
    }
}
