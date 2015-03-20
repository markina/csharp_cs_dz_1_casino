using System;

namespace CasinoClient
{
	class Dice : Play
	{
		public override string getName ()
		{
			return "Dice";
		}

		public override int play (Logger logger, int score)
		{
			Console.WriteLine ("Напишите сумму 2 кубиков");
			int sum = getNumForDiceFromConsole ();
			Console.WriteLine ("Вы выбрали сумму: " + sum);
			logger.log ("Игрок ввел сумму: " + sum);
			Console.WriteLine ("Выпали кубики:");
			logger.log ("Выпали кубики:");

			Random random = new Random ();
			int firstCube = getPointsOnCube (random);
			int secondCube = getPointsOnCube (random);

			logger.log (firstCube + " " + secondCube);
			logger.log ("Игрок ввел сумму: " + sum);
			logger.log ("Выпало: " + (firstCube + secondCube));

			Console.WriteLine (firstCube + " " + secondCube);
			Console.WriteLine ("Сумма = " + (firstCube + secondCube));

			if (firstCube + secondCube == sum) {
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

		static int getPointsOnCube (Random random)
		{
			return random.Next (6) + 1;
		}

		static int getNumForDiceFromConsole ()
		{
			while (true) {
				string countString = Console.ReadLine ();
				try {
					int count = Convert.ToInt32 (countString);
					if (count < 2 || count > 12) {
						Console.WriteLine ("Сумма кубиков не может быть меньше 2 или больше 12");
						Console.WriteLine ("Введите еще раз");
						continue;
					}
					return count;
				} catch (FormatException) {
					Console.WriteLine ("Напишите, пожалуйста, целое число");
				}
			}
		}
	}
}