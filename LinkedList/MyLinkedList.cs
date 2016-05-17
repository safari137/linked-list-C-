using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _headNode;

        private Node<T> LastNode
        {
            get
            {
                var curNode = _headNode;
                while (curNode.Next != null)
                    curNode = curNode.Next;

                return curNode;
            }
        }


        public int Count { get; set; }

        public void Add(T data)
        {
            Count++;

            var node = new Node<T>(data);

            if (_headNode == null)
                _headNode = node;

            else if (_headNode.Next == null)
                _headNode.Next = node;

            else
                LastNode.Next = node;
        }

        public T[] ToArray()
        {
            var listArray = new T[Count];

            if (Count == 0)
                return listArray;

            var curNode = _headNode;

            var index = 0;
            do
            {
                listArray[index++] = curNode.Data;
                curNode = curNode.Next;
            } while (curNode != null);

            return listArray;
        }

        public T Remove(int indexToRemove)
        {
            if (indexToRemove > Count - 1 || indexToRemove < 0)
                throw new IndexOutOfRangeException();

            var curNode = _headNode;
            Node<T> lastNode = null;

            for (var i = 0; i <= indexToRemove && curNode != null; i++)
            {
                if (indexToRemove == i)
                {
                    if (lastNode != null)
                        lastNode.Next = curNode.Next;
                    
                    else 
                        _headNode = (Count > 1) ? curNode.Next : null;

                    Count--;
                    return curNode.Data;
                }

                lastNode = curNode;
                curNode = curNode.Next;
            }

            throw new Exception("Unable to locate node");
        }

        public T GetElemantAt(int elementIndex)
        {
            var curNode = _headNode;

            if (elementIndex > Count - 1 || elementIndex < 0)
                throw new IndexOutOfRangeException();

            for (var i = 0; i <= elementIndex && curNode != null; i++)
            {
                if (elementIndex == i)
                    return curNode.Data;

                curNode = curNode.Next;
            }

            throw new Exception("Unable to locate node");
        }

        public IEnumerator<T> GetEnumerator()
        {
            var curNode = _headNode;

            while (curNode != null)
            {
                yield return curNode.Data;
                curNode = curNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
