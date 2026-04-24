using System.Collections;

namespace CollectionsPractice.MyLinkedList;

public class MyNode<T>
{
    public T Value { get; set; }
    public MyNode<T>? Next { get; set; }
    public MyNode(T value) => Value = value;
}

public class MyLinkedList<T> : IEnumerable<T>
{
    private MyNode<T>? _head;

    public void Add(T value)
    {
        if (_head == null)
            _head = new MyNode<T>(value);
        else
        {
            var temp = _head;
            while (temp.Next != null)
                temp = temp.Next;
            temp.Next = new MyNode<T>(value);
        }
    }

    // Реализуйте GetEnumerator, чтобы работал foreach!
    public IEnumerator<T> GetEnumerator()
    {
        var temp = _head;
        while (temp != null)
        {
            yield return temp.Value;
            temp = temp.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

