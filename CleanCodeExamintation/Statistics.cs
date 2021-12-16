using MooGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination
{
    class Statistics : IStatistics
    {
        private string _filePath;

        public Statistics(string filePath)
        {
			_filePath = filePath;
        }
        public void AddScoreToTopList(string name, int numberOfGuesses)
        {
			StreamWriter output = new StreamWriter(_filePath, append: true);
			output.WriteLine(name + "#&#" + numberOfGuesses);
			output.Close();
		}
		
		public void showTopList()
        {
			StreamReader input = new StreamReader(_filePath);
			List<PlayerData> results = new List<PlayerData>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);
				PlayerData pd = new PlayerData(name, guesses);
				int pos = results.IndexOf(pd);
				if (pos < 0)
				{
					results.Add(pd);
				}
				else
				{
					results[pos].Update(guesses);
				}


			}
			results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
			Console.WriteLine("Player   games average");
			foreach (PlayerData p in results)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.Average()));
			}
			input.Close();
		}
    }
}
