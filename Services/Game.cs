using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Task3.Services
{
    static class Game
    {
        public static string GetResult(int compMove, int userMove, List<string> moves)
        {

            if (compMove == userMove) return "Draw";

            List<string> winMoves = new List<string>();
            int half = (moves.Count() - 1) / 2;

            for (int i = 0, j = userMove + 1; i < half; i++, j++)
            {
                if (j == moves.Count()) j = 0;
                winMoves.Add(moves[j]);
            }

            return winMoves.Contains(moves[compMove]) ? "You lose!" : "You win!";
        }
        public static bool CheckInput(List<string> input)
        {
            return (input.Count >= 3 
                    && input.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).ToList<string>().Count() == 0
                    && input.Count() % 2 != 0
                    );
        }
        public static void MenuOutput(List<string> menu)
        {
            byte iterator = 1;
            Console.WriteLine("Available moves\n");
            foreach(var moves in menu)
            {
                Console.WriteLine($"{iterator++} - {moves}\n");
            }
            Console.WriteLine("0 - exit\n");
        }

    }
}
