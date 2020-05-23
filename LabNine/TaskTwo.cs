using System;
using System.Collections.Generic;
using System.Text;

namespace LabNine
{
    class TaskTwo
    {
        public static void Execute()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Enter your expression:");
            String expression = Console.ReadLine();
            Stack<Char> parenthesis = new Stack<Char>();
            Boolean correct = true;
            foreach (char c in expression)
            {
                if (c.Equals('('))
                {
                    parenthesis.Push(c);
                }else if (c.Equals(')'))
                {
                    try
                    {
                        parenthesis.Pop();
                    }
                    catch
                    {
                        correct = false;
                        break;
                    }
                   
                }
            }
            if (parenthesis.Count != 0)
                correct = false;
            Console.WriteLine("The expression is " + (correct ? "" : "not ") + "correct");
        }
    }
}
