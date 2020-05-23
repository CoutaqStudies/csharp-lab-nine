using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LabNine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<GeographicalUnit> countries = new List<GeographicalUnit>();
            List<LogEntry> log = new List<LogEntry>();
            DoublyLinkedList<GeographicalUnit> badCountries = new DoublyLinkedList<GeographicalUnit>();
            DoublyLinkedList<LogEntry> badLog = new DoublyLinkedList<LogEntry>();
            //ConsoleAppButShittyList.Execute(badCountries, badLog);
            while (true)
            {
                TaskTwo.Execute();
            }
        }
    }
}
