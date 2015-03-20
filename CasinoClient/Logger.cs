using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoClient
{
	public class Logger
	{
		System.IO.StreamWriter file;

		public Logger ()
		{
			file = new System.IO.StreamWriter ("../../casino.log", true);
			log ("-------------------Новая игра-------------------");
		}

		public void log (string str)
		{
			file.WriteLine ("[" + DateTime.Now + "] " + str);
		}

		public void close ()
		{
			log ("-------------------Конец игры-------------------");
			file.Close ();
		}

		public void logScore (int score)
		{
			file.WriteLine ("На счету: " + score);
		}

		public void logDateBase (DataBase dataBase)
		{
			file.WriteLine ("База:");
			foreach (string login in dataBase.logins.Keys) {
				file.WriteLine (login + " " + dataBase.logins [login]);
			}

		}

		public void logAllCards (List<int> clietsCards)
		{
			foreach (int card in clietsCards) {
				file.WriteLine (Helper.getNameCard (card));
			}
		}

		public void logWin ()
		{
			log ("Игрок побеждает");
		}

		public void logLoss ()
		{
			log ("Игрок проигрывает");
		}

		public void logWin2 ()
		{
			log ("Игрок получает двойную ставку");
		}

		public void logWin4 ()
		{
			log ("Игрок получает четырехкратную ставку");
		}

	}

}
