using System;

namespace MyAttemptAtADoubleList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>();
            linkedList.Add("one");
            linkedList.Add("two");
            linkedList.Add("three");
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("FUCK three\n");
            linkedList.UpdateAtIndex("this ain't no three", 2);
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
