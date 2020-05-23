using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LabNine
{
    public class TaskFour
    {
        internal static void Execute()
        {
            int min = 0;
            int max = 50000;
            Dictionary<string, int> sumsOfCubes= new Dictionary<string, int>();
            for(int n = 1; n<= max; n++)
            {
                for (int x = min; x <= Math.Pow(max, 1/3); x++)
                {
                    for (int y = min; y <= Math.Pow(max, 1 / 3); y++)
                    {
                        for (int z = min; z <= Math.Pow(max, 1 / 3); z++)
                        {
                            double sum = Math.Pow(x, 3) + Math.Pow(y, 3) + Math.Pow(z, 3);
                            if (sum > n)
                                break;
                            if (sum == n)
                                sumsOfCubes.Add("x: " + x + ", y: " + y + ", z: " + z, n);
                        }
                    }
                }
            }
            var lookup = sumsOfCubes.ToLookup(x => x.Value, y => y.Key).Where(y => y.Count() > 2);
            foreach (var sumOfCubes in sumsOfCubes)
            {
                Console.WriteLine(sumOfCubes.Key+": "+sumOfCubes.Value);
            }
            Console.WriteLine("More than two sums: ");
            foreach (var sumOfCubes in lookup)
            {
                Console.WriteLine(sumOfCubes.Key);
            }
        }
    }
}
