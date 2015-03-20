using System;
using System.Collections.Generic;

namespace CasinoClient
{
	class BlackJack : Play
	{
		public override string getName ()
		{
			return "BlackJack";
		}

		public override int play (Logger logger, int score)
		{
			Console.WriteLine ("Вы получаете 2 карты:");
			Random random = new Random ();
			List<int> clietsCards = new List<int> ();
			List<int> croupiersCards = new List<int> ();

			clietsCards.Add (getExclusiveNumber (random, clietsCards));
			clietsCards.Add (getExclusiveNumber (random, clietsCards));

			printAllCard (clietsCards);
			printOpponentTotal (clietsCards);

			while (true) {
				Console.WriteLine ("Еще карту? (y/n)");
				if (Helper.getYOrNOrQFromConsole () == 'y') {
					clietsCards.Add (getExclusiveNumber (random, clietsCards));
					printAllCard (clietsCards);
					printOpponentTotal (clietsCards);
					if (!checkTotal (clietsCards)) {
						logger.log ("Игрок получает карты:");
						logger.logAllCards (clietsCards);
						logger.log ("Количество набранных очков: " + Helper.getTotalCards (clietsCards));
						logger.log ("Перебор");
						logger.log ("Игрок проигрывает");
						Console.WriteLine ("Перебор");
						Helper.printLossMessage ();
						return 0;
					}
				} else {
					Console.WriteLine ("Ок");
					logger.log ("Игрок получает карты:");
					logger.logAllCards (clietsCards);
					printOpponentTotal (clietsCards);
					logger.log ("Количество набранных очков: " + Helper.getTotalCards (clietsCards));
					break;
				} 
			}

			logger.log ("Крупье получает карты:");
			Console.WriteLine ("Крупье набирает карты:");
			croupiersCards.Add (getExclusiveNumber (random, croupiersCards));
			croupiersCards.Add (getExclusiveNumber (random, croupiersCards));
			printAllCard (croupiersCards);
			printMyTotal (croupiersCards);

			while (true) {
				if (Helper.getTotalCards (croupiersCards) <= 16) {
					croupiersCards.Add (getExclusiveNumber (random, croupiersCards));
					printAllCard (croupiersCards);
					printMyTotal (croupiersCards);
					if (!checkTotal (croupiersCards)) {
						logger.logAllCards (croupiersCards);
						logger.log ("Количество набранных очков: " + Helper.getTotalCards (croupiersCards));
						logger.log ("Перебор");
						Console.WriteLine ("Перебор");
						Helper.printWinMessage ();
						logger.logWin ();
						logger.logWin2 ();
						return 2;
					}
				} else {
					Console.WriteLine ("Добор закончен");
					logger.logAllCards (croupiersCards);
					logger.log ("Количество набранных очков у казино: " + Helper.getTotalCards (croupiersCards));
					logger.log ("Количество набранных очков у игрока: " + Helper.getTotalCards (clietsCards));

					printOpponentTotal (clietsCards);
					printMyTotal (croupiersCards);
					if (Helper.getTotalCards (croupiersCards) < Helper.getTotalCards (clietsCards)) {
						Helper.printWinMessage ();
						logger.logWin ();
						logger.logWin2 ();
						return 2;
					} else {
						Helper.printLossMessage ();
						logger.logLoss ();
						return 0;
					}
				}
			}
		}


		static bool checkTotal (List<int> cards)
		{
			return Helper.getTotalCards (cards) <= 21;
		}

		static void printOpponentTotal (List<int> cords)
		{
			int count = Helper.getTotalCards (cords);
			if (count >= 11 && count <= 20 || (count % 10) > 4 || (count % 10) == 0) {
				Console.WriteLine ("У Вас {0:D} очков", count);
			} else {
				Console.WriteLine ("У Вас {0:D} очка", count);
			}
		}

		static void printMyTotal (List<int> cords)
		{
			int count = Helper.getTotalCards (cords);
			if (count >= 11 && count <= 20 || (count % 10) > 4 || (count % 10) == 0) {
				Console.WriteLine ("У казино {0:D} очков", count);
			} else {
				Console.WriteLine ("У казино {0:D} очка", count);
			}
		}

		static int getExclusiveNumber (Random random, List<int> cards)
		{
			while (true) {
				int newCard = random.Next (52);
				if (!cards.Contains (newCard)) {
					return newCard;
				}
			}
		}

		static void printAllCard (List<int> clietsCards)
		{
			foreach (int card in clietsCards) {
				Console.WriteLine (Helper.getNameCard (card));
			}
		}
	}
}
