using System;
using System.Collections.Generic;

namespace LabNine
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GeographicalUnit> countries = new List<GeographicalUnit>();
            List<LogEntry> log = new List<LogEntry>();
            ConsoleApp.Execute(countries, log);
        }
    }
}
