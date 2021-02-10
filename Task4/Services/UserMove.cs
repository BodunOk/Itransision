using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task3.Interfaces;

namespace Task3.Services
{
    class UserMove : IMove<int>
    {
        private readonly List<string> moves;
        public UserMove(string[] _moves)
        {
            moves = Enumerable.ToList<string>(_moves);
        }
        public int MakeMove()
        {
            Console.Write("Enter your move: ");
            int moveNum;
            if (!int.TryParse(Console.ReadLine(), out moveNum)) return -1;
            if (moveNum < 0 || moveNum > moves.Count()) return -1;
            return moveNum;
        }
    }
}
