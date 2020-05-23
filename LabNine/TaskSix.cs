using System;
using System.Collections.Generic;
using System.Text;

namespace LabNine
{
    class TaskSix
    {
        internal static void Execute()
        {
            /* BinaryTree<string> tree = new BinaryTree<String>();
             tree.Add("test", null);
             foreach(var branch in tree)
             {
                 Console.WriteLine(branch);
             }*/
            String[] countries = { "BRA", "CHI", "COL", "URU", "FRA", "NIG", "GER", "ALG", "NED", "MEX", "CRC", "GRE", "ARG", "SWI", "BEL", "USA" };
            String win = String.Empty;
            List<string> justImagineItsATree = new List<string>();
            Console.WriteLine(Play(countries, justImagineItsATree));
            foreach(var item in justImagineItsATree)
            {
                Console.WriteLine(item);
            }
            
        }
        public static String Play(String[] countries, List<string> tree, int gamesLeft = 3, int winnerAmount = 8)
        {
            if (gamesLeft == 0)
            {
                String x = "";
                return Match(countries[0], countries[1],ref x);
            }
            String[] winners  = new String[winnerAmount];
            for (int j = 0; j< winners.Length*2; j+=2)
            {
                tree.Add(gamesLeft + "====>" + Match(countries[j], countries[j+1], ref winners[j/2]));
            }
            return Play(winners, tree, gamesLeft - 1, winners.Length/2);

        }
        public static String Match(String TeamOne, String TeamTwo, ref String Winner)
        {
            Random r = new Random();
            int ScoreOne = r.Next(0, 5);
            int ScoreTwo = r.Next(0, 5);
            if (ScoreOne > ScoreTwo)
            {
                Winner = TeamOne;
                return MatchString(TeamOne, ScoreOne, TeamTwo, ScoreTwo);
            }
            else
            {
                Winner = TeamTwo;
                return MatchString(TeamTwo, ScoreTwo, TeamOne, ScoreOne);
            }

        }
        public static String MatchString(String TeamOne, int ScoreOne, String TeamTwo, int ScoreTwo)
        {
            return TeamOne + " - " + TeamTwo + " :  " + ScoreOne + " - " + ScoreTwo;
        }
    }
}
