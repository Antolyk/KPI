using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomLinkedList
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        public delegate void DataEventHandler(string message, T data, string index);
        public delegate void EventHandler(string message);

        public event DataEventHandler AddAction = delegate { };
        public event DataEventHandler DeleteAction = delegate { };
        public event EventHandler ClearAction = delegate { };

        CustomLinkedListNode<T> Head;
        CustomLinkedListNode<T> Tail;
        public int count;

        public CustomLinkedList()
        {
            AddAction += ShowMessageWithData;
            DeleteAction += ShowMessageWithData;
            ClearAction += ShowMessageWithoutData;
        }

        public void Add(T data)
        {
            if (data == null) throw new ArgumentNullException("Відсутні дані!");

            CustomLinkedListNode<T> node = new CustomLinkedListNode<T>(data);

            if (Head == null)
            {
                Head = node;
                Tail = node;
                Tail.Next = Head;
            }
            else
            {
                node.Next = Head;
                Tail.Next = node;
                Tail = node;
            }
            count++;

            this.AddAction?.Invoke("Було додано новi данi: ", data, "add");
        }
        public bool Remove(T data)
        {
            if (data == null) throw new ArgumentNullException("Вiдсутнi данi!");

            CustomLinkedListNode<T> current = Head;
            CustomLinkedListNode<T> previous = null;

            if (IsEmpty) return false;

            do
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current == Tail)
                            Tail = previous;
                    }
                    else
                    {
                        if (count == 1)
                        {
                            Head = Tail = null;
                        }
                        else
                        {
                            Head = current.Next;
                            Tail.Next = current.Next;
                        }
                    }
                    count--;
                    this.DeleteAction?.Invoke("Було видалено данi ", data, "delete");
                    return true;
                }

                previous = current;
                current = current.Next;
            } while (current != Head);

            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
            this.ClearAction?.Invoke("Видалено всi данi");
        }

        public bool Contains(T data)
        {
            if (data == null) throw new ArgumentNullException("Відсутні дані!");
            CustomLinkedListNode<T> current = Head;
            if (current == null) return false;
            do
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            while (current != Head);
            return false;
        }

        public CustomLinkedListNode<T> GetCustomLinkedListNodeByIndex(int index)
        {
            var counter = 0;

            if (Head == null)
            {
                throw new ArgumentException("Iндекс вийшов за рамки!");
            }

            if (index >= Count)
            {
                return null;
            }

            var temp = Head;

            while (temp != null)
            {
                if (counter == index)
                {
                    return temp;
                }

                counter++;
                temp = temp.Next;
            }

            throw new ArgumentException("Iндекс вийшов за рамки!");
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if ((uint)arrayIndex >= array.Length)
                throw new ArgumentException("Iндекс вийшов за рамки!");

            var index = 0;

            while (array.Length > index)
            {
                var CustomLinkedListNode = GetCustomLinkedListNodeByIndex(index);
                if (CustomLinkedListNode == null)
                {
                    return;
                }

                array[index] = CustomLinkedListNode.Data;

                index++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            CustomLinkedListNode<T> current = Head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != Head);
        }

        public static void ShowMessageWithData(string message, T data, string index)
        {
            Console.Write(message);
            switch (index)
            {
                case "add":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "delete":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
            Console.WriteLine(data);
            Console.ResetColor();
        }
        public static void ShowMessageWithoutData(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}