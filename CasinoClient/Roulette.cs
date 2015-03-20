using System;

namespace CasinoClient
{
	class Roulette : Play
	{
		public override string getName ()
		{
			return "Roulette";
		}

		public override int play (Logger logger, int score)
		{

			Console.WriteLine ("Выберите конкретную ячейку или цвет(r/b или число r/b) ");
			CellOrColor cell = getCellOrColorFromConsole ();

			Console.WriteLine ("Вы выбрали: " + getStringCell (cell));
			logger.log ("Игрок выбирает: " + getStringCell (cell));

			Random random = new Random ();
			CellOrColor randomCell = getRandomCell (random);

			Console.WriteLine ("Выпала ячейка: " + getStringCell (randomCell));
			logger.log ("Выпала ячейка: " + getStringCell (randomCell));

			if (cell.isColor && randomCell.color == cell.color) {
				Helper.printWinMessage ();
				logger.logWin ();
				logger.logWin2 ();
				return 2;
			}
			if (cell.isColor && randomCell.color != cell.color) {
				Helper.printLossMessage ();
				logger.logLoss ();
				return 0;
			}
			if (cell.color == randomCell.color && cell.number == randomCell.number) {
				Helper.printWinMessage ();
				logger.logWin ();
				logger.logWin4 ();
				return 4;
			} else {
				Helper.printLossMessage ();
				logger.logLoss ();
				return 0;
			}
		}

		static string getStringCell (CellOrColor cell)
		{
			if (cell.isColor && cell.color == 'r') {
				return "красный цвет";	
			} else if (cell.isColor && cell.color == 'b') {
				return "черный цвет";
			} else {
				if (cell.color == 'r') {
					return cell.number + " красное";
				} else {
					return cell.number + " черное";
				}
			}
		}


		CellOrColor getCellOrColorFromConsole ()
		{

			while (true) {
				string str = Console.ReadLine ();
				if (str.Equals ("r") || str.Equals ("R")) {
					return new CellOrColor ('r');
				} else if (str.Equals ("b") || str.Equals ("B")) {
					return new CellOrColor ('b');
				}
				if (str.Length <= 1 || str [str.Length - 2] != ' ') {
					printFormat ();
					continue;
				}
				string strNum = str.Substring (0, str.Length - 2);
				string strColor = str.Substring (str.Length - 1, 1);

				int num;
				try {
					num = Convert.ToInt32 (strNum);
					if (num >= 37 || num < 0) {
						printFormat ();
						continue;
					}
				} catch (FormatException) {
					printFormat ();
					continue;
				}
				if (strColor.Equals ("r") || strColor.Equals ("R")) {
					return new CellOrColor (num, 'r');
				} else if (strColor.Equals ("b") || strColor.Equals ("B")) {
					return new CellOrColor (num, 'b');
				}
			}

		}

		static void printFormat ()
		{
			Console.WriteLine ("Напишите, пожалуйста, в формате: ");
			Console.WriteLine ("Если это цвет: введите 'r' или 'b'");
			Console.WriteLine ("Если это конкретная ячейка: введите номер, потом 'r' или 'b', например \"5 r\"");
		}

		static CellOrColor getRandomCell (Random random)
		{
			int d = random.Next (2);
			return new CellOrColor (random.Next (37), d == 1 ? 'r' : 'b');
		}
	}
}