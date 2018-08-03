using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public abstract class AbstractHeap
    {
        #region internal properties
        private int Capacity { get; set; }
        internal int Size { get; set; }
        internal int[] Nodes { get; set; }
        #endregion

        #region constructors
        public AbstractHeap(int capacity)
        {
            Capacity = capacity;
            Size = 0;
            Nodes = new int[Capacity];
        }
        #endregion

        #region helperMethods
        public void KeepSize()
        {
            if (Size == Capacity)
            {
                this.pop();
            }
        }

        public int getLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        public bool hasLeftChild(int parentIndex)
        {
            return getLeftChildIndex(parentIndex) < Size;
        }

        public int leftChild(int index)
        {
            return Nodes[getLeftChildIndex(index)];
        }

        public int getRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        public bool hasRightChild(int parentIndex)
        {
            return getRightChildIndex(parentIndex) < Size;
        }

        public int rightChild(int index)
        {
            return Nodes[getRightChildIndex(index)];
        }

        public int getParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        public bool hasParent(int childIndex)
        {
            return getParentIndex(childIndex) >= 0;
        }

        public int parent(int index)
        {
            return Nodes[getParentIndex(index)];
        }

        public void swap(int index1, int index2)
        {
            int temp = Nodes[index1];
            Nodes[index1] = Nodes[index2];
            Nodes[index2] = temp;
        }

        #endregion

        #region available public methods

        /// <summary>
        /// Gets the minimum element at the root of the tree
        /// </summary>
        /// <returns>Int value of minimum element</returns>
        /// <exception cref="">InvalidOperationException when heap is empty</exception>
        public int peek()
        {
            if (Size == 0)
                throw new InvalidOperationException("Heap is empty");

            return Nodes[0];
        }

        /// <summary>
        /// Removes the minimum element at the root of the tree
        /// </summary>
        /// <returns>Int value of minimum element</returns>
        /// <exception cref="">InvalidOperationException when heap is empty</exception>
        public int pop()
        {
            if (Size == 0)
                throw new InvalidOperationException("Heap is empty");

            int item = Nodes[0];
            Nodes[0] = Nodes[Size - 1];
            Size--;
            heapifyDown();
            return item;
        }

        /// <summary>
        /// Add a new item to heap, and keep the size in check
        /// </summary>
        /// <returns>void</returns>
        public void add(int item)
        {
            KeepSize();
            Nodes[Size] = item;
            Size++;
            heapifyUp();
        }
        #endregion

        #region abstract methods
        internal abstract void heapifyUp();
        internal abstract void heapifyDown();
        #endregion
    }

    public class MaxHeap : AbstractHeap
    {
        private int Capacity { get; set; }
        public MaxHeap(int capacity): base(capacity)
        {
            this.Capacity = capacity;
        }
        internal override void heapifyDown()
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int largerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index) > leftChild(index))
                {
                    largerChildIndex = getRightChildIndex(index);
                }

                if (Nodes[largerChildIndex] > Nodes[index])
                    swap(index, largerChildIndex);
                else
                    break;
                index = largerChildIndex;
            }
        }
        internal override void heapifyUp()
        {
            int index = Size - 1;

            while (hasParent(index) && parent(index) < Nodes[index])
            {
                swap(index, getParentIndex(index));
                index = getParentIndex(index);
            }
        }
    }
}