using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
	public enum Actions
	{
		Play,
		Repeat,
		End,
		New,
		HasWon,
		Tie
	}

	public class Game
	{
		Queue<Player> Players;
		List<int> WinBits;

		public Game (string n1, string n2)
		{
			Players = new Queue<Player> ();
			Players.Enqueue (new Player (n1, 'X'));
			Players.Enqueue (new Player (n2, 'O'));
			WinBits = new List<int> ();
		}

		public void Start ()
		{
			Player p;
			CreateBitfield ();
			UI.DisplayPlayField (PlayField (Players));
			do {
				p = MakeNextMove (Players.Dequeue ());
				Players.Enqueue (p);
				UI.DisplayPlayField (PlayField (Players));
				p = HasWon (p) ? new Player (p, Actions.HasWon) : NoFieldLeft () ? new Player (p, Actions.Tie) : p;

			} while (p.Action == Actions.Play);

			UI.GameOver (p);
		}

		public Player MakeNextMove (Player player)
		{
			Player p;
			do {
				p = UI.UserInput (player);
				if (p.Action == Actions.Play) {
					p = FieldIsFree (p) ? MakeMove (p) : new Player (p, Actions.Repeat);
				}
			} while (p.Action == Actions.Repeat);

			return p;
		}

		public int OccupiedFields ()
		{
			return Players.Aggregate (0, (acc, p) => acc | p.Moves);
		}

		public bool FieldIsFree (Player p)
		{
			return ((OccupiedFields () | p.Moves) & p.NextMove) == 0;
		}

		public Player MakeMove (Player p)
		{
			return new Player (p.Name, p.Sign, p.Moves | p.NextMove);
		}

		public bool NoFieldLeft ()
		{
			return OccupiedFields () == 511; // 111111111
		}

		public bool HasWon (Player p)
		{
			bool retval = false;
			foreach (int bits in WinBits) {
				retval |= ((p.Moves & bits) == bits);
			}
			return retval;
		}

		public string PlayField (Queue<Player> players)
		{
			string field = "";
			Player player;
			for (int bit = 1; bit < 512; bit <<= 1) {
				player = players.Where (p => (bit & p.Moves) != 0).FirstOrDefault ();
				field += player != null ? player.Sign.ToString () : " ";
			}
			return field;
		}

		public void CreateBitfield ()
		{
			WinBits.Add (Convert.ToInt32 ("001001001", 2));
			WinBits.Add (Convert.ToInt32 ("010010010", 2));
			WinBits.Add (Convert.ToInt32 ("100100100", 2));
			WinBits.Add (Convert.ToInt32 ("000000111", 2));
			WinBits.Add (Convert.ToInt32 ("000111000", 2));
			WinBits.Add (Convert.ToInt32 ("111000000", 2));
			WinBits.Add (Convert.ToInt32 ("100010001", 2));
			WinBits.Add (Convert.ToInt32 ("001010100", 2));
		}
	}
}
