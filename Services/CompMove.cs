using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Task3.Interfaces;

namespace Task3.Services
{
    class CompMove : IMove<string>
    {
        private readonly List<string> moves;

        public string HMAC { get; set; }

        public CompMove(string [] _moves)
        {
            moves = Enumerable.ToList<string>(_moves);
        }
        public string MakeMove()
        {
            var key = GetSecretKey();
            var move = GetMove();
            GetHMAC(move,key);
            StringBuilder moveKey = new StringBuilder(key + " " + move);
            return moveKey.ToString();
        }
        private string GetSecretKey()
        {
            var rng = new RNGCryptoServiceProvider();
            var bytes = new byte[16];
            rng.GetBytes(bytes);
            return BitConverter.ToString(bytes).Replace("-", "");
        }
        private string GetHMAC(string text, string key)
        {
            using (var hmacsha = new HMACSHA256(Encoding.UTF8.GetBytes(key))) 
            {
                var hash = hmacsha.ComputeHash(Encoding.UTF8.GetBytes(text));
                return HMAC = BitConverter.ToString(hash).Replace("-", "");
            }
        }
        private string GetMove()
        {
            var random = new Random();
            int index = random.Next(moves.Count);
            return moves[index];
        }
    }
}
