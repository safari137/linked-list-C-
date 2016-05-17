using System;
using System.Collections.Generic;
using LinkedList;

namespace LinkedListClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyLinkedList<int>();

            list.Add(0);
            list.Add(1);
            list.Add(2);

            Console.WriteLine("Item 1 : {0}", list.GetElemantAt(0));
            Console.WriteLine("Item 2 : {0}", list.GetElemantAt(1));
            Console.WriteLine("Item 3 : {0}", list.GetElemantAt(2));

            Console.WriteLine("Display as Array: ");
            Display(list.ToArray());
            Console.WriteLine();

            Console.WriteLine("Display in foreach :");
            Display(list);

            Console.WriteLine("\nNow let's remove the one in the middle.");
            var removed = list.Remove(1);
            Console.WriteLine("Removed : {0}", removed);

            Console.WriteLine();
            Display(list.ToArray());

            Console.WriteLine();

            Console.WriteLine("Let's remove the first item.");
            removed = list.Remove(0);
            Console.WriteLine("Removed : {0}", removed);

            Display(list.ToArray());

            Console.WriteLine("Count : " + list.Count);
        }

        static void Display(IEnumerable<int> list)
        {
            foreach (var item in list)
                Console.WriteLine(item);
        }
    }
}
