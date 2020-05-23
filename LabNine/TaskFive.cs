using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LabNine
{
    class TaskFive
    {
        public static void Execute()
        {
            String text = File.ReadAllText("./TaskFive.txt");
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach(string word in text.Trim().Split(' '))
            {
                if (dictionary.ContainsKey(word))
                    dictionary[word]++;
                else
                    dictionary.Add(word, 1);
            }
            int i = 0;
            foreach (KeyValuePair<string, int> word in dictionary.OrderBy(key => key.Value).OrderByDescending(key => key.Value))
            {
                if (i >= 10)
                    break;
                i++;
                Console.WriteLine(word.Key+" is used "+word.Value+" times.");
            }
        }
    }
}
