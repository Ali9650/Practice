

using System.Collections;

namespace Task1
{
    internal class CustomList<T> : IEnumerable<T>
    {
        private T[] array;
        private int count;
        private int capacity;
        public int Capacity { get => capacity; }
        public int Count { get => count; }


        public CustomList()
        {
            array = new T[4];
            capacity = array.Length;
        }

        public void GetAll()
        {
            for (int i = 0; i < capacity; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public void Add(T item)
        {
            if (count == capacity)
            {
                Array.Resize(ref array, capacity == 0 ? 4 : array.Length * 2);
                capacity = array.Length;
            }
            array[count] = item;
            count++;
        }

        public void Remove(T item)
        {
            var index = Array.IndexOf(array, item);
            if (index != -1)
            {
                for (int i = index; i < count; i++)
                    array[i] = array[i + 1];

                count--;
            }
        }

        public bool Contains(T item)
        {
            var index = Array.IndexOf(array, item);
            if (index != -1)
            {
                return true;
            }
            return false;
        }

        public bool Any(Predicate<T> predicate =null)
        {
            if (count > 0 && predicate is null) return true;

            for (int i=0; i<count; i++)
            {
                if (predicate(array[i]))
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            for (int i = 0; i < count; i++)
                array[i] = default;

            count = 0;
        }

        public T FirstOrDefault(Predicate<T> predicate=null)
        {
            if (count > 0 && predicate is null)
                return array[0];

            for (int i=0; i< count; i++)
            {
                if (predicate(array[i]))
                    return array[i];

            }
          

            return default;
        }

        public T ElementAtOrDefault(int index)
        {
            if (index >= 0 && index < count)
            {
                return array[index];
            }
            return default;
        }

        public T LastOrDefault(Predicate<T> predicate =null)
        {
            if (Any() && predicate is null)
                return array[count - 1];

           
            for (int i = count-1; i>=0; i--)
            {
                if (predicate(array[i]))   
                   return array[i];
            }

            return default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i=0; i< count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}