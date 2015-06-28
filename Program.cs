using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game("Player 1", "Player 2");
            g.Start();
            Console.ReadLine();

        }
    }
}
