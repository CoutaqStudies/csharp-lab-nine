using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LabNine
{
    class TaskSeven
    {
        public static void Execute()
        {
            // вариант 2
            List<String> one = new List<string>();
            one.Add("b");
            one.Add("a");
            List<String> two = new List<string>();
            two.Add("a");
            two.Add("b");
            Console.WriteLine(AreListsEqual<String>(one, two));
            one.Add("b");
            one.Add("b");
            two.Add("a");
            two.Add("b");
            Console.WriteLine(AreListsEqual<String>(one, two));
        }
        public static Boolean AreListsEqual<T>(List<T> listOne, List<T> listTwo)
        {
            Dictionary<T, int> items = new Dictionary<T, int>();
            foreach(var item in listOne)
            {
                if(items.ContainsKey(item))
                    items[item]++;
                else
                    items.Add(item, 1);
            }
            foreach (var item in listTwo)
            {
                if (items.ContainsKey(item))
                    items[item]--;
                else
                    break;
            }
            foreach(var item in items)
            {
                if (item.Value != 0)
                    return false;
            }
            return true;
        }
        public static Boolean AreBadListsEqual<T>(DoublyLinkedList<T> listOne, DoublyLinkedList<T> listTwo)
        {
            Dictionary<T, int> items = new Dictionary<T, int>();
            foreach (var item in listOne)
            {
                if (items.ContainsKey(item))
                    items[item]++;
                else
                    items.Add(item, 1);
            }
            foreach (var item in listTwo)
            {
                if (items.ContainsKey(item))
                    items[item]--;
                else
                    break;
            }
            foreach (var item in items)
            {
                if (item.Value != 0)
                    return false;
            }
            return true;
        }
    }
}
