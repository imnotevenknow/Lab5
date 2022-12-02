namespace Lab5;

public class MyList<T>
{
    private T[] _array;

    public MyList()
    {
        _array = Array.Empty<T>();
        Count = 0;
    }

    public T this[int index]
    {
        get => _array[index];
        set => _array[index] = value;
    }

    public int Count { get; private set; }

    public void Add(T item)
    {
        T[] tempArray = new T[Count + 1];
        for (var i = 0; i < Count; i++)
        {
            tempArray[i] = _array[i];
        }

        tempArray[Count] = item;
        _array = tempArray;
        Count++;
    }

    public void RemoveAt(int index)
    {
        T[] tempArray = new T[Count - 1];
        for (var i = 0; i < index; i++)
        {
            tempArray[i] = _array[i];
        }

        for (var i = index; i < Count - 1; i++)
        {
            tempArray[i] = _array[i + 1];
        }

        _array = tempArray;
        Count--;
    }

    public int IndexOf(T item)
    {
        for (var i = 0; i < Count; i++)
        {
            if (_array[i]?.Equals(item) == true)
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(T item) => IndexOf(item) != -1;

    public void Clear()
    {
        _array = Array.Empty<T>();
        Count = 0;
    }

    public void Insert(int index, T item)
    {
        T[] tempArray = new T[Count + 1];
        for (var i = 0; i < index; i++)
        {
            tempArray[i] = _array[i];
        }

        tempArray[index] = item;
        for (var i = index + 1; i < Count + 1; i++)
        {
            tempArray[i] = _array[i - 1];
        }

        _array = tempArray;
        Count++;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        for (var i = 0; i < Count; i++)
        {
            array[arrayIndex + i] = _array[i];
        }
    }

    public T[] ToArray()
    {
        T[] tempArray = new T[Count];
        for (var i = 0; i < Count; i++)
        {
            tempArray[i] = _array[i];
        }

        return tempArray;
    }

    public void Sort()
    {
        Array.Sort(_array, 0, Count);
    }

    public void Sort(IComparer<T> comparer)
    {
        Array.Sort(_array, 0, Count, comparer);
    }
}

public static class MyListExtensionMethods
{
    public static T[] GetArray<T>(this MyList<T> list)
    {
        T[] tempArray = new T[list.Count];
        for (var i = 0; i < list.Count; i++)
        {
            tempArray[i] = list[i];
        }

        return tempArray;
    }
}