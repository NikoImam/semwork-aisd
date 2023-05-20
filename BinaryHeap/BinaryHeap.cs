using System.Drawing;

namespace BinaryHeap
{
    public class MinHeap
    {
        private readonly int[] _elements;
        private int _size;

        public MinHeap(int size)
        {
            _elements = new int[size];
        }

        public MinHeap(int[] array)
        {
            _elements = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                Add(array[i]);
            }
        }

        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
        private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
        private bool IsRoot(int elementIndex) => elementIndex == 0;

        private int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
        private int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
        private int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        public bool IsEmpty => _size == 0;

        public int GetRoot()
        {
            if (_size == 0)
            {
                throw new Exception("Heap is empty");
            }

            return _elements[0];
        }

        public int ExtractMin()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var result = _elements[0];
            _elements[0] = _elements[_size - 1];
            _size--;

            HeapifyDown();

            return result;
        }

        public void Add(int element)
        {
            if (_size == _elements.Length)
            {
                throw new IndexOutOfRangeException();
            }

            _elements[_size] = element;
            _size++;

            HeapifyUp();
        }

        private void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (_elements[smallerIndex] >= _elements[index])
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }
        private void HeapifyUp()
        {
            var index = _size - 1;
            while (!IsRoot(index) && _elements[index] < GetParent(index))
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
    }
}