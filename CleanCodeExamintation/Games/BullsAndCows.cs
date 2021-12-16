using CleanCodeExamintation.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination
{
    public class BullsAndCows : IGame
    {
		private static string _goal;
		private readonly IUserInterface _userInterface;
        private readonly IStatistics _statistics;

        public BullsAndCows(IUserInterface userInterface, IStatistics statistics)
        {
			_userInterface = userInterface;
			_statistics = statistics;
		}
		public string MakeGoal()
		{
			Random randomGenerator = new Random();
			_goal = "";
			for (int i = 0; i < 4; i++)
			{
				int random = randomGenerator.Next(10);
				string randomDigit = "" + random;
				while (_goal.Contains(randomDigit))
				{
					random = randomGenerator.Next(10);
					randomDigit = "" + random;
				}
				_goal = _goal + randomDigit;
			}
			return _goal;
		}

		public void Run(string name)
        {
				_goal = MakeGoal();
				_userInterface.ShowToUser("New game:\n");
				//comment out or remove next line to play real games!
				_userInterface.ShowToUser("For practice, number is: " + _goal + "\n");
				string guess = _userInterface.GetUserInput();

				int numberOfGuesses = 1;
				string bbcc = CheckAnswer(_goal, guess);
				_userInterface.ShowToUser(bbcc + "\n");
				while (bbcc != "BBBB,")
				{
					numberOfGuesses++;
					guess = _userInterface.GetUserInput();
					_userInterface.ShowToUser(guess + "\n");
					bbcc = CheckAnswer(_goal, guess);
					_userInterface.ShowToUser(bbcc + "\n");
				}
				_statistics.AddScoreToTopList(name, numberOfGuesses);
				_statistics.showTopList();
				_userInterface.ShowToUser("Correct, it took " + numberOfGuesses + " guesses");
		}

		public string CheckAnswer(string goal, string guess)
		{
			int cows = 0, bulls = 0;
			guess += "    ";     // if player entered less than 4 chars
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (goal[i] == guess[j])
					{
						if (i == j)
						{
							bulls++;
						}
						else
						{
							cows++;
						}
					}
				}
			}
			return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
		}
	}
}
