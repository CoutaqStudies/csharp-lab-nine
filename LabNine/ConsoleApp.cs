using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LabNine
{
    public class ConsoleApp
    {
        const int SHOW = 1, ADD = 2, DELETE = 3, UPDATE = 4, SEARCH = 5, SHOWLOG = 6, EXIT = 7;
        public static void Execute(List<GeographicalUnit> countries, List<LogEntry> log)
        {
            #region PROMPT
            String prompt = "1 – Просмотр таблицы\n2 – Добавить запись\n3 – Удалить запись\n4 – Обновить запись\n5 – Поиск записей\n6 – Просмотреть лог\n7 - Выход";
            Console.WriteLine(prompt);
            int input = 0;
            try
            {
                input = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Execute(countries, log);
            }
            #endregion
            switch (input)
            {
                #region SHOW
                case SHOW:
                    String output = String.Empty;
                    if (countries.Count == 0)
                        output = ("The list is empty!");
                    else
                        foreach (GeographicalUnit country in countries)
                            output += country.GetInfoTable();
                    Console.WriteLine(output);
                    Execute(countries, log);
                    break;
                #endregion
                #region ADD
                case ADD:
                    Console.Write("Please enter the country: ");
                    string name = Console.ReadLine();
                    Console.Write("Please enter the capital: ");
                    string capital = Console.ReadLine();
                    int population;
                    while (true)
                    {
                        try
                        {
                            Console.Write("Please enter the population: ");
                            population = int.Parse(Console.ReadLine());
                            if (population < 0)
                                throw new FormatException();
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.Write("Incorrect input, try again: ");
                        }
                    }
                    GeographicalUnit.FormOfGov form;
                    while (true)
                    {
                        try
                        {
                            Console.Write("Please enter the form of government: ");
                            form = (GeographicalUnit.FormOfGov)Enum.Parse(typeof(GeographicalUnit.FormOfGov), Console.ReadLine().ToUpper());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.Write("Incorrect input, try again: ");
                        }
                    }
                    countries.Add(new GeographicalUnit(name, capital, population, form));
                    Console.WriteLine($"Added {name} to the list.");
                    log = AddEntry(new LogEntry(name, LogEntry.Action.ADD), log);
                    Execute(countries, log);
                    break;
                #endregion
                #region DELETE
                case DELETE:
                    int entry;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Which entry do you want to remove? ");
                            entry = int.Parse(Console.ReadLine());
                            if (entry > countries.Count || entry < 1)
                            {
                                throw new FormatException();
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.Write("Incorrect input, try again: ");
                        }
                    }
                    Console.WriteLine($"Removed {countries[entry - 1].GetName()} from the list.");
                    log = AddEntry(new LogEntry(countries[entry - 1].GetName(), LogEntry.Action.DELETE), log);
                    countries.RemoveAt(entry - 1);
                    Execute(countries, log);
                    break;
                #endregion
                #region UPDATE
                case UPDATE:
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Which entry do you want to update? ");
                            entry = int.Parse(Console.ReadLine());
                            if (entry > countries.Count || entry < 1)
                            {
                                throw new FormatException();
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.Write("Incorrect input, try again: ");
                        }
                    }
                    Console.Write("Please enter the country: ");
                    name = Console.ReadLine();
                    Console.Write("Please enter the capital: ");
                    capital = Console.ReadLine();
                    while (true)
                    {
                        try
                        {
                            Console.Write("Please enter the population: ");
                            population = int.Parse(Console.ReadLine());
                            if (population < 0)
                            {
                                throw new FormatException();
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.Write("Incorrect input, try again: ");
                        }
                    }
                    while (true)
                    {
                        try
                        {
                            Console.Write("Please enter the form of government: ");
                            form = (GeographicalUnit.FormOfGov)Enum.Parse(typeof(GeographicalUnit.FormOfGov), Console.ReadLine().ToUpper());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.Write("Incorrect input, try again: ");
                        }
                    }
                    Console.WriteLine($"Updated {name}.");
                    countries.RemoveAt(entry - 1);
                    countries.Insert(entry - 1, new GeographicalUnit(name, capital, population, form));
                    log = AddEntry(new LogEntry(name, LogEntry.Action.UPDATE), log);
                    Execute(countries, log);
                    break;
                #endregion
                #region SEARCH
                case SEARCH:
                    List<GeographicalUnit> old_countries = countries.ToList();
                    List<GeographicalUnit> removeList = new List<GeographicalUnit>();
                    Console.WriteLine("Filters: Population size and form of government.");
                    Console.WriteLine("Choose the filter: ");
                    if (Console.ReadLine().ToUpper() == "FORM")
                    {
                        Console.WriteLine("Federation(F) or Unitary state(US): ");
                        if (Console.ReadLine().ToUpper() == "F")
                        {
                            foreach (GeographicalUnit country in old_countries)
                            {
                                if (country.GetForm().Equals(GeographicalUnit.FormOfGov.US))
                                    removeList.Add(country);

                            }
                        }
                        else
                        {
                            foreach (GeographicalUnit country in old_countries)
                            {
                                if (country.GetForm().Equals(GeographicalUnit.FormOfGov.F))
                                    removeList.Add(country);
                            }
                        }
                    }
                    else
                    {
                        int number;
                        Console.WriteLine("Less or More: ");
                        if (Console.ReadLine().ToUpper() == "LESS")
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.Write("Less then ");
                                    number = int.Parse(Console.ReadLine());
                                    if (number < 0)
                                        throw new FormatException();
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.Write("Incorrect input, try again: ");
                                }
                            }
                            foreach (GeographicalUnit country in old_countries)
                            {
                                if (country.GetPopulation() > number)
                                    removeList.Add(country);
                            }
                        }
                        else
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.Write("More then ");
                                    number = int.Parse(Console.ReadLine());
                                    if (number < 0)
                                        throw new FormatException();
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.Write("Incorrect input, try again: ");
                                }
                            }
                            foreach (GeographicalUnit country in old_countries)
                            {
                                if (country.GetPopulation() < number)
                                    removeList.Add(country);
                            }
                        }
                    }
                    foreach (GeographicalUnit country in removeList)
                    {
                        countries.Remove(country);
                    }
                    output = "\n--------------------------------------\n";
                    if (countries.Count == 0)
                        output = ("The list is empty!");
                    else
                    {
                        foreach (GeographicalUnit country in countries)
                        {
                            output += country.GetInfoTable();
                        }
                    }

                    Console.WriteLine(output);
                    countries = old_countries.ToList();
                    Execute(countries, log);
                    break;
                #endregion
                #region SHOWLOG
                case SHOWLOG:
                    output = "";
                    foreach (LogEntry i in log)
                    {
                        output += i.logFormatted() + "\n";
                    }
                    output += ($"\n{LongestIdleTime(log)} - Самый долгий период бездействия пользователя");
                    Console.WriteLine(output);
                    Execute(countries, log);
                    break;
                #endregion
                #region EXIT
                case EXIT:
                    return;
                    #endregion
            }
        }
        public static List<LogEntry> AddEntry(LogEntry entry, List<LogEntry> list, int size = 50)
        {
            List<LogEntry> newList = list.ToList();
            if (list.Count() < size)
            {
                newList.Add(entry);
            }
            else
            {
                newList.RemoveAt(0);
                newList.Add(entry);
            }
            return newList;
        }
        public static String LongestIdleTime(List<LogEntry> log)
        {
            TimeSpan startTime, endTime;
            String idle = "";
            if (log.Count() == 1 || log.Count == 0)
                idle = "00:00:00";
            else
            {
                for (int i = 0; i < log.Count() - 1; i++)
                {
                    startTime = TimeSpan.ParseExact(log[i].getTime(), @"h\:mm\:ss", CultureInfo.InvariantCulture);
                    endTime = TimeSpan.ParseExact(log[i + 1].getTime(), @"h\:mm\:ss", CultureInfo.InvariantCulture);
                    double diffInSeconds = (endTime - startTime).TotalSeconds;
                    TimeSpan time = TimeSpan.FromSeconds(diffInSeconds);
                    idle = time.ToString(@"h\:mm\:ss");
                }
            }
            return idle;
        }
    }
}