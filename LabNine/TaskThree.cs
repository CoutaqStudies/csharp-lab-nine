using System;
using System.Text;

namespace LabNine
{
    internal class TaskThree
    {
        internal static void Execute()
        {
            Console.OutputEncoding = Encoding.UTF8;
            CircularLinkedList<String> names = new CircularLinkedList<String>();
            String[] namesArray = { "Имя0", "Имя1", "Имя2", "Имя3", "Имя4", "Имя5" };
            Console.WriteLine("Names: ");
            foreach(String name in namesArray)
            {
                Console.Write(name+" ");
                names.Add(name);
            }
            Console.Write("\nEnter your считалочка:");
            String sentence = Console.ReadLine();
            int start;
            Console.Write("Starting player:");
            while (true)
            {
                try
                {
                    start = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Write("no. Try again:");
                }
            }
            String result =  names.ItemAtIndexButWithCoolGraphics(sentence.Trim().Split(' '), start);
            Console.WriteLine("Результат: "+result);
        }
    }
}