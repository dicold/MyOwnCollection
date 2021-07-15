using System;
using System.Collections;

/*
    Реализовать коллекцию:
        + получение максимального элемента О(1)
        + доступ по индексу О(1)
        + вставка О(1)
        + вставка по индексу О(n)
        + удаление O(n)
        + удаление по индексу O(n)
        + итерация в foreach
        
    Элементами коллекции могут быть только числа (int, double, ...)
    В случае некорректных входных данных, коллекция должна выбрасывать исключения
*/

public class MyOwnColl<T> : IEnumerable
                        where T : IComparable<T> // позволяет сравнивать два Т объекта
{
    private T[] collection = new T[0];
    public int Count { get; private set; }
    private T max_el;

    // получение максимального элемента
    public T Max() => max_el;

    // доступ по индексу
    public T Get(int i)
    {
        if (i < 0 || i >= Count)
            throw new IndexOutOfRangeException();
        else
            return collection[i];
    }

    // вставка
    public void Add(T value)
    {
        if (!IsNumber(value))
            throw new ArgumentException("Collection elements can only be numbers (int, double, ...)."); //Exception("Collection elements can only be numbers (int, double, ...!");
        else
        {
            Array.Resize<T>(ref collection, collection.Length + 1);
            collection[Count] = value;
            Count++;

            if (value.CompareTo(max_el) > 0)
                max_el = value;
        }
    }

    // вставка по индексу
    public void Insert(int index, T value)
    {
        if (!IsNumber(value))
            throw new ArgumentException("Collection elements can only be numbers (int, double, ...)."); //Exception("Collection elements can only be numbers (int, double, ...!");
        else
        {
            Array.Resize<T>(ref collection, collection.Length + 1);
            for (int i = collection.Length - 1; i > index; i--)
                collection[i] = collection[i - 1];
            collection[index] = value;
            Count++;

            if (value.CompareTo(max_el) > 0)
                max_el = value;
        }
    }

    // удаление
    public void Remove(T value) => RemoveAt(IndexOf(value));

    // удаление по индексу
    public void RemoveAt(int index)
    {
        if ((index >= 0) && (index < Count))
        {
            if (collection[index].CompareTo(max_el) >= 0)
                max_el = GetMaxExcept(index);
            for (int i = index; i < Count - 1; i++)
            {
                collection[i] = collection[i + 1];
            }
            Count--;
            Array.Resize<T>(ref collection, Count);
        }
    }

    private T GetMaxExcept(int index)
    {
        T max = collection[0];
        for (int i = 1; i < Count; i++)
            if (index != i && collection[i - 1].CompareTo(collection[i]) < 0)
                max = collection[i];
        return max;
    }

    // поиск индекса элемента
    public int IndexOf(T value)
    {
        for (int i = 0; i < Count; i++)
            if (value.CompareTo(collection[i]) == 0)
                return i;
        return -1;
    }

    public bool IsNumber(T value)
    {
        return value is sbyte
            || value is byte
            || value is short
            || value is ushort
            || value is int
            || value is uint
            || value is long
            || value is ulong
            || value is float
            || value is double
            || value is decimal;
    }

    public IEnumerator GetEnumerator()
    {
        for (int index = 0; index < Count; index++)
        {
            yield return collection[index];
        }
    }
}
