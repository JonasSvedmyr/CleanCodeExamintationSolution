using CleanCodeExamination;
using CleanCodeExamintation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamintation
{
    class UserInterface : IUserInterface
    {
        Dictionary<string, Action> commands;
        private IGame _game { get; set; }
        public UserInterface()
        {
            commands = new Dictionary<string, Action>
            {
                { "BullsAndCows",() =>_game = new BullsAndCows(this, new Statistics("BullsAndCows.txt"))},
                { "GuessNumber",() =>_game = new GuessNumber(this, new Statistics("GuessNumber.txt")) },
            };

        }
        public string GetUser()
        {
            Console.WriteLine("Enter your user name:\n");
            return Console.ReadLine();
        }

        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        public IGame SelectGame()
        {
            Console.WriteLine(GetGames());
            string answer = "";
            Action _action;
            do
            {
                answer = Console.ReadLine().Trim();
            }
            while (!commands.TryGetValue(answer, out _action));
            _action.Invoke();
            return _game;
        }
        private string GetGames()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Games: ");
            return builder.Append(String.Join(" ", commands.Keys)).ToString();
        }
        public void ShowToUser(string output)
        {
            Console.WriteLine(output);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
