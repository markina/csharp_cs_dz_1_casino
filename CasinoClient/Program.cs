using System;

namespace CasinoClient
{
	class Program
	{
		static void Main (string[] args)
		{
			Game game = new Game ();
			Logger logger = new Logger ();
			DataBase dataBase;
			try {
				dataBase = new DataBase ();
			} catch (FormatException) {
				Console.WriteLine ("Информация о счетах испорчена");
				logger.log ("Информация о счетах испорчена");
				logger.close ();
				return;
			} catch (Exception) {
				Console.WriteLine ("Проблемы на сервере");
				logger.log ("Проблемы на сервере");
				logger.close ();
				return;
			}
			logger.log ("База успешно прочитана");
			logger.logDateBase (dataBase);

			while (true) {
				Console.WriteLine ("Добро пожаловать в казино!");
				Console.WriteLine ("Информация: ");
				Console.WriteLine ("'q' - назад");
				Console.WriteLine ("'y' - да");
				Console.WriteLine ("'n' - нет");
				Console.WriteLine ("В скобках будут написаны возможные действия");
				Console.WriteLine ("Пожалуйста, представьтесь: (q)");
				logger.log ("Ожидается игрок");
				string name;
				while (true) {
					name = Console.ReadLine ();
					if (name.Equals ("q")) {
						logger.log ("Завершение работы");
						Helper.printBye ();
						logger.close ();
						return;
					}
					if (name.Equals ("")) {
						Console.WriteLine ("Имя не должно быть пустой строкой");
						continue;
					}
					break;
				}
				if (dataBase.haveLogin (name)) {
					Console.WriteLine ("Мы рады Вам снова!");
					logger.log ("Имя игрока: " + name);
					logger.log ("Имя обноруженно в базе");

				} else {
					Console.WriteLine ("Вы новый игрок!");
					logger.log ("Имя игрока: " + name);
					logger.log ("Имя не обноруженно в базе");
					dataBase.addNewPrson (name);
					logger.log ("Имя добавлено в базу");
				}
				logger.logDateBase (dataBase);
				int score = dataBase.getScore (name);
				logger.logScore (score);
				Helper.printScore (score);

				while (true) {
					Console.WriteLine ("Вы хотите пополнить счет? (y/n/q)");
					char yOrNOrQ = Helper.getYOrNOrQFromConsole ();
					if (yOrNOrQ == 'q') {
						logger.log ("Игрок ушел");
						Helper.printBye ();
						final (name, score, dataBase);
						logger.logDateBase (dataBase);
						break;
					}
					if (yOrNOrQ == 'y') {
						Console.WriteLine ("Сколько Вы хотите внести?");
						int count = Helper.getNumberFromConsole ();
						logger.log ("Игрок пополнил счет на " + count);
						score += count;
						logger.logScore (score);
					} 

					Helper.printScore (score);

					while (true) {
						Console.WriteLine ("В какую игру Вы хотите сыграть? (b/d/r/q)");
						Console.WriteLine ("BlackJack(b), Dice(d), Roulette(r)");
						char choice = Helper.getChoiceGameOrQFromConsole ();
						if (choice == 'q') {
							break;
						}
						score = game.play (score, choice, logger);
					}
				}
			}
		}


		static void final (string name, int score, DataBase dataBase)
		{
			dataBase.putScore (name, score);
			dataBase.update ();
		}
	}
}
