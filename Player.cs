using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
	public class Player
	{
		public readonly string Name;
		public readonly char Sign;
		public readonly int Moves;
		public readonly int NextMove;
		public readonly Actions Action;

		public Player (string Name, char Sign, int Moves = 0, int NextMove = 0, Actions Action = Actions.Play)
		{
			this.Name = Name;
			this.Sign = Sign;
			this.Moves = Moves;
			this.NextMove = NextMove;
			this.Action = Action;
		}

		public Player (Player p, int NextMove = 0, Actions Action = Actions.Play)
		{
			this.Name = p.Name;
			this.Moves = p.Moves;
			this.Sign = p.Sign;
			this.NextMove = NextMove;
			this.Action = Action;
		}

		public Player (Player p, Actions Action = Actions.Play)
		{
			this.Name = p.Name;
			this.Moves = p.Moves;
			this.Sign = p.Sign;
			this.NextMove = p.NextMove;
			this.Action = Action;
		}
	}
}
