using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
	public static class UI
	{
		public static Player UserInput (Player p)
		{
			int nextMove = 0;
			Actions action;

			Console.Write (p.Name + ": ");
			string input = Console.ReadLine ().ToLower ();
			action = input == "neu" ? Actions.New : 
                     input == "ende" ? Actions.End : 
                     (nextMove = Translate (input)) == 0 ? Actions.Repeat : Actions.Play;
			return new Player (p, nextMove, action);
		}

		public static int Translate (string input)
		{
			int move = 0;
			int row;
			int col;
			char[] arr = new char[2];

			if (input.Length == 2) {
				arr = input.ToLower ().ToCharArray ();
				col = arr [0] - 'a';
				row = arr [1] - '0';
				if (IsInRange (col, row)) {
					move = 1 << (col + 3 * row);
				}
			}
			return move;
		}

		public static bool IsInRange (int col, int row)
		{
			return !(col < 0 || col > 2 || row < 0 || row > 2);
		}

		public static void GameOver (Player p)
		{
			Console.WriteLine (
				(p.Action == Actions.HasWon) ? (p.Name + " has won!")
                : (p.Action == Actions.Tie) ? "Game ended in a tie." 
                : "Game ceased"
			);
		}

		public static void DisplayPlayField (string field)
		{
			var n = Enumerable.Range (0, 3);
			var rows = n.Select (r => r + field.Substring (3 * r, 3)).ToList ();
			Console.WriteLine (" ABC");
			rows.ForEach (Console.WriteLine);
		}
	}
}
