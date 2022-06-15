using System;

namespace CustomLinkedList
{
    public class Programm
    {
        static void Main(string[] args)
        {
            CustomLinkedList<int> customList = new CustomLinkedList<int>();

            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);
            customList.Add(5);

            Console.WriteLine();
            Console.Write("Список: ");
            PrintList(customList);

            Console.WriteLine();
            Console.WriteLine("Чи мiстить список \"3\": " + customList.Contains(3));
            Console.WriteLine("Чи мiстить список \"6\": " + customList.Contains(6));

            Console.WriteLine();
            customList.Remove(1);
            customList.Remove(4);

            Console.WriteLine();
            Console.Write("Список: ");
            PrintList(customList);

            Console.WriteLine();
            int[] array = new int[customList.Count];
            customList.CopyTo(array, customList.Count - 1);
            Console.Write("Скопiйована матриця: ");
            PrintArray(array);

            Console.WriteLine();
            customList.Clear();

            Console.WriteLine();
            Console.Write("Очищений список: ");
            PrintList(customList);

        }
        public static void PrintList(CustomLinkedList<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
