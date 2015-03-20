using System;
using System.IO;
using System.Collections.Generic;

namespace CasinoClient
{
	public class DataBase
	{
		const String nameFile = "../../DataBase.txt";
		public Dictionary<string, int> logins = new Dictionary<string, int> ();

		public DataBase ()
		{
			FileInfo fileInfo;
			FileStream fileStream;
			try {
				fileInfo = new FileInfo (nameFile);
				fileStream = fileInfo.OpenRead ();
			} catch {
				throw;
			}
			StreamReader reader = new StreamReader (fileStream);
			while (!reader.EndOfStream) {
				string login = reader.ReadLine ();
				int score = Convert.ToInt32 (reader.ReadLine ());

				if (logins.ContainsKey (login)) {
					throw new Exception ();
				}
				logins [login] = score;
			}
			reader.Close ();
			fileStream.Close ();
		}

		internal bool haveLogin (string name)
		{
			return logins.ContainsKey (name);
		}

		internal void addNewPrson (string name)
		{
			logins [name] = 0;
		}

		internal int getScore (string name)
		{
			return logins [name];
		}

		internal void update ()
		{
			StreamWriter writer = new StreamWriter (nameFile);
			foreach (string login in logins.Keys) {
				writer.WriteLine (login);
				writer.WriteLine (logins [login]);
			}
			writer.Close ();
		}

		internal void addToScore (int count, string name)
		{
			logins [name] += count;
		}

		internal void putScore (string name, int score)
		{
			logins [name] = score;
		}
	}
}
