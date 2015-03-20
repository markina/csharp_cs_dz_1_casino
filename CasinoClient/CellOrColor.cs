namespace CasinoClient
{
	public class CellOrColor
	{
		public bool isColor;
		public char color;
		public int number;


		public CellOrColor (char ch)
		{
			isColor = true;
			color = ch == 'r' ? 'r' : 'b';
		}

		public CellOrColor (int num, char ch)
		{
			isColor = false;
			color = ch == 'r' ? 'r' : 'b';
			number = num;
		}
	}

}