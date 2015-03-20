namespace CasinoClient
{
	public abstract class Play
	{
		public abstract string getName ();

		public abstract int play (Logger logger, int score);
	}
}
