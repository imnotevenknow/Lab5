namespace Lab5;

internal class MyDictionary<TKey, TValue>
{
    private readonly MyList<TKey> _keys;
    private readonly MyList<TValue> _values;

    public MyDictionary()
    {
        _keys = new MyList<TKey>();
        _values = new MyList<TValue>();
    }


    public TValue this[TKey key]
    {
        get
        {
            for (var i = 0; i < _keys.Count; i++)
            {
                if (_keys[i]?.Equals(key) == true)
                {
                    return _values[i];
                }
            }

            throw new KeyNotFoundException();
        }
        set
        {
            for (var i = 0; i < _keys.Count; i++)
            {
                if (_keys[i]?.Equals(key) != true)
                {
                    continue;
                }

                _values[i] = value;
                return;
            }

            _keys.Add(key);
            _values.Add(value);
        }
    }


    public ICollection<TKey> Keys { get; }


    public ICollection<TValue> Values { get; }

    public int Count
    {
        get => _keys.Count;
    }


    public bool IsReadOnly { get; }


    public void Add(KeyValuePair<TKey, TValue> item)
    {
        _keys.Add(item.Key);
        _values.Add(item.Value);
    }


    public void Clear()
    {
        // Clear the keys and values
        _keys.Clear();
        _values.Clear();
    }


    public bool Contains(KeyValuePair<TKey, TValue> item) =>
        // Check if the key exists
        ContainsKey(item.Key) &&
        // Check if the value exists
        ContainsValue(item.Value);

    // Return true if both exist
    private bool ContainsValue(TValue itemValue)
    {
        // Check if the value exists
        for (var i = 0; i < _values.Count; i++)
        {
            if (_values[i]?.Equals(itemValue) == true)
            {
                return true;
            }
        }

        return false;
    }


    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        // Copy the keys and values to the array
        TKey[] keyArray = new TKey[array.Length];
        TValue[] valueArray = new TValue[array.Length];

        _keys.CopyTo(keyArray, arrayIndex);
        _values.CopyTo(valueArray, arrayIndex);

        // Copy the key and value pairs to the array
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = new KeyValuePair<TKey, TValue>(keyArray[i], valueArray[i]);
        }


    }


    public bool Remove(KeyValuePair<TKey, TValue> item) => throw new NotImplementedException();

    public void Add(TKey key, TValue value)
    {
        this[key] = value;
    }


    public bool ContainsKey(TKey key)
    {
        // Check if the key exists
        for (var i = 0; i < _keys.Count; i++)
        {
            if (_keys[i]?.Equals(key) == true)
            {
                return true;
            }
        }

        return false;
    }


    public void Remove(TKey key)
    {
        for (var i = 0; i < _keys.Count; i++)
        {
            if (!_keys[i]?.Equals(key) == true)
            {
                continue;
            }

            _keys.RemoveAt(i);
            _values.RemoveAt(i);
            return;
        }

        throw new KeyNotFoundException();
    }

    #region Implementation of IEnumerable

    #endregion
}