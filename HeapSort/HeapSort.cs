using BinaryHeap;
namespace HeapSort
{
    public static class HeapSort
    {
        public static int[] Sort(int[] array)
        {
            //создаем двоичную кучу из элементов массива
            var heap = new MinHeap(array);
            //извлекаем корень(минимальный элемент) n раз
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = heap.ExtractMin();
            }

            return array;
        }
    }
}