using System;
using System.Collections.Generic;

namespace CasinoClient
{
	static class Helper
	{
		static public void printScore (int score)
		{
			Console.WriteLine ("Ваш баланс: " + score);
		}


		static public int getNumberFromConsole ()
		{
			while (true) {
				string countString = Console.ReadLine ();
				if (countString.Equals ("q")) {
					return -1;
				}
				try {
					int count = Convert.ToInt32 (countString);
					return count;
				} catch (FormatException) {
					Console.WriteLine ("Напишите, пожалуйста, целое число");
				}
			}
		}

		static public char getYOrNOrQFromConsole ()
		{
			while (true) {
				string s = Console.ReadLine ();
				if (s.Equals ("n")) {
					return 'n';
				} else if (s.Equals ("y")) { 
					return 'y';
				} else if (s.Equals ("q")) {
					return 'q';
				}
				Console.WriteLine ("Введите одну букву: 'y', 'n' или 'q'");
			}
		}

		static public char getChoiceGameOrQFromConsole ()
		{

			while (true) {
				string s = Console.ReadLine ();
				if (s.Equals ("b") || s.Equals ("d") || s.Equals ("r") || s.Equals ("q")) {
					return s [0];
				} else {
					Console.WriteLine ("BlackJack(b), Dice(d), Roulette(r)");
					Console.WriteLine ("Введите одну букву: 'b', 'd', 'r' или 'q'");
				}
			}
		}

		static public void printWinMessage ()
		{
			Console.WriteLine ("*******************************************");
			Console.WriteLine ("************!!!ВЫ ВЫИГРАЛИ!!!**************");
			Console.WriteLine ("*******************************************");
		}

		static public void printLossMessage ()
		{
			Console.WriteLine ("------------------------------------------------------");
			Console.WriteLine ("---------------------Вы проиграли---------------------");
			Console.WriteLine ("------------------------------------------------------");
		}

		public static void printBye ()
		{
			Console.WriteLine ("------------------------------------------------------");
			Console.WriteLine ("---------------------Ждем Вас снова!------------------");
			Console.WriteLine ("------------------------------------------------------");
		}

		public static string getNumCard (int p)
		{
			p = (p + 1) % 13;
			if (p <= 10 && p >= 2) {
				return p.ToString ();
			} else if (p == 1) {
				return "Туз";
			} else if (p == 0) {
				return "Король";
			} else if (p == 11) {
				return "Валет";
			}
			return "Дама";
		}

		public static string getSuit (int p)
		{
			p = (p + 1) % 4;
			if (p == 1) {
				return "Черви";
			} else if (p == 2) {
				return "Буби";
			} else if (p == 3) {
				return "Крести";
			} else {
				return "Пики";
			}

		}

		public static int scoreCard (int p)
		{
			p = (p + 1) % 13;
			if (p <= 10 && p >= 2) {
				return p;
			} else if (p == 1) {
				return 11;
			}
			return 10;
		}

		public static string getNameCard (int card)
		{
			return getNumCard (card) + " " + getSuit (card);
		}

		public static int getTotalCards (List<int> clietsCards)
		{
			int total = 0;
			foreach (int card in clietsCards) {
				total += scoreCard (card);
			}
			return total;
		}
	}

}
