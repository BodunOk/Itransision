using System;
using System.Collections.Generic;
using System.Linq;
using Task3.Interfaces;
using Task3.Services;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] t = new string[] {"asdasd", "dasd", "asdasda2w", "qweqwree", "dgdfgfdg", "asdqww", "qwdsasgfs"};
            List<string> listOfMoves = Enumerable.ToList<string>(args);
            if (!Game.CheckInput(Enumerable.ToList<string>(args))) 
            {
                Console.WriteLine("Проверьте корректность переданных аргументов!\nПример:>java -jar gamr.jar rock paper scissors lizard Spock");
                return;
            }

            CompMove compMove = new CompMove(args);
            UserMove userMove = new UserMove(args);

            var keyMove = compMove.MakeMove();

            while (true)
            {
                Console.WriteLine($"HMAC:\n{compMove.HMAC}\n");
                Game.MenuOutput(listOfMoves);
                int yourMove = userMove.MakeMove();
                if (yourMove == -1)
                {
                    Console.Clear();
                    continue;
                }
                if (yourMove == 0) return;
                Console.WriteLine($"\nYour move: {args[--yourMove]}");
                string[] keyAndMove = keyMove.Split(" ");
                Console.WriteLine($"\nComputer move: {keyAndMove[1]}");
                Console.WriteLine("\n" + Game.GetResult(listOfMoves.IndexOf(keyAndMove[1]), yourMove, listOfMoves));
                Console.WriteLine($"\nHMAC key: {keyAndMove[0]}");
                Console.ReadLine();
                break;
            }
        }
    }
}
