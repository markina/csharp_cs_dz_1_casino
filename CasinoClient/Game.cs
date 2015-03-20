using System;

namespace CasinoClient
{

	class Game
	{

		public int play (int score, char tagGame, Logger logger)
		{
			int bet;
			Play playGame = null; 

			if (tagGame.Equals ('b')) {
				playGame = new BlackJack ();
			} else if (tagGame.Equals ('r')) {
				playGame = new Roulette ();
			} else if (tagGame.Equals ('d')) {
				playGame = new Dice ();
			}
			logger.log ("Начинаем игру в " + playGame.getName () + "!");
			Console.WriteLine ("Начинаем игру в " + playGame.getName () + "!");  

			while (true) {
				Helper.printScore (score);
				Console.WriteLine ("Ваша ставка: (q)");
				bet = Helper.getNumberFromConsole ();
				if (bet == -1) {
					logger.log ("Игрок передумал играть в эту игру");
					Helper.printScore (score);
					return score;
				}
				if (bet > score) {
					Console.WriteLine ("Ставка не может превышать Ваш текущий счет");
				} else if (bet <= 0) {
					Console.WriteLine ("Ставка не может быть меньше либо равна 0");
				} else {
					Console.WriteLine ("Ваша ставка: {0:D}", bet);
					logger.log ("Игрок сделал ставку = " + bet);
					break;
				}
			}
			score -= bet;
			score = score + bet * playGame.play (logger, score);

			Helper.printScore (score);
			logger.logScore (score);
			return score;
		}
	}
}
