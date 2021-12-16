using CleanCodeExamintation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination
{
    public class GuessNumber : IGame
    {
        private IStatistics _statistics;
        private IUserInterface _userInterface;

        public Random random { get; set; }
        public GuessNumber(IUserInterface userInterface, IStatistics statistics)
        {
            _statistics = statistics;
            _userInterface = userInterface;
            random = new Random();
        }
        public string CheckAnswer(string goal, string guess)
        {
            var _goal = int.Parse(goal);
            if (!int.TryParse(guess, out int _guess) )
            {
                return "Invalid input";
            }
            if(_goal == _guess)
            {
                return "Correct";
            }
            else if (_goal > _guess)
            {
                return "Higher";
            }
            else if (_goal < _guess)
            {
                return "Lower";
            }
            else
            {
                return "Wrong";
            }
        }

        public string MakeGoal()
        {
            return random.Next(0, 100 + 1).ToString();
        }

        public void Run(string name)
        {
            var goal = MakeGoal();
            string Answer ="";
            int numberOfGuesses = 0;
            _userInterface.ShowToUser("Guess a number between 1 and 100");
            do
            {
                Answer = CheckAnswer(goal, _userInterface.GetUserInput());
                numberOfGuesses++;
                if(Answer != "Correct")
                {
                    _userInterface.ShowToUser(Answer);
                }
            }
            while (Answer != "Correct");

            _statistics.AddScoreToTopList(name, numberOfGuesses);
            _statistics.showTopList();
            _userInterface.ShowToUser("Correct, it took " + numberOfGuesses + " guesses");
        }
    }
}
