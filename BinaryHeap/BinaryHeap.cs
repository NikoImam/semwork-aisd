using System.Drawing;

namespace BinaryHeap
{
    public class MinHeap
    {
        private int[]? _heap;
        private int _size = 0;

        public MinHeap(int size)
        {
            _heap = new int[size];
        }

        public MinHeap(int[] elements)
        {
            BuildHeap(elements);
        }

        private int GetLeftChildIndex(int index) => 2 * index + 1;
        private int GetRightChildIndex(int index) => 2 * index + 2;
        private int GetParentIndex(int index) => (index - 1) / 2;
        private bool IsRoot(int index) => index == 0;

        public void BuildHeap(int[] elements)
        {
            _size = elements.Length;
            _heap = elements;

            for (int i = (_size - 1) / 2; i >= 0; i--)
                HeapifyDown(i);
        }
        public void Add(int n)
        {
            if (_size == _heap!.Length)
                throw new IndexOutOfRangeException("No free space in heap.");

            _heap[_size] = n;
            _size++;
            HeapifyUp(_size - 1);
        }
        public void Replace(int index, int value)
        {
            if (value < _heap![index])
            {
                _heap[index] = value;
                HeapifyUp(index);
            }
            else
            {
                _heap[index] = value;
                HeapifyDown(index);
            }
        }
        public int PeekMin()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException("Heap is empty");
            }

            return _heap![0];
        }
        public int ExtractMin()
        {
            if (_size > 0)
            {
                var result = _heap![0];
                _heap[0] = _heap[_size - 1];
                _size--;
                HeapifyDown(0);
                return result;
            }
            throw new IndexOutOfRangeException("Heap is empty");
        }
        private void HeapifyDown(int index)
        {
            var leftChild = GetLeftChildIndex(index);
            var rightChild = GetRightChildIndex(index);
            var min = index;
            if (leftChild < _size && _heap![leftChild] < _heap[min])
                min = leftChild;

            if (rightChild < _size && _heap![rightChild] < _heap[min])
                min = rightChild;

            if (min != index)
            {
                Swap(min, index);
                HeapifyDown(min);
            }
        }
        private void HeapifyUp(int index)
        {
            while (!IsRoot(index) && _heap![index] < _heap[GetParentIndex(index)])
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _heap![firstIndex];
            _heap[firstIndex] = _heap[secondIndex];
            _heap[secondIndex] = temp;
        }
    }

}