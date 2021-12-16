using CleanCodeExamination;
using CleanCodeExamintation.Interfaces;

namespace CleanCodeExamintation
{
    public class Controller
    {
        private bool _playOn { get; set; } = true;
        private string _user { get; set; }
        private IGame _game { get; set; }
        private IUserInterface _userInterface { get; set; }

        public Controller(IUserInterface userInterface)
        {
            _userInterface = userInterface;
            _user = _userInterface.GetUser();
            _game = _userInterface.SelectGame();
        }
        private bool CheckIfAnswerIsNo(string answer)
        {
            return answer != null && answer != "" && answer.Substring(0, 1) == "n";
        }

        private bool CheckIfAnswerIsYes(string answer)
        {
            return answer != null && answer != "" && answer.Substring(0, 1) == "y";
        }

        private void CheckToContinue()
        {
            _userInterface.ShowToUser("Continue?(y/n)");
            var answer = _userInterface.GetUserInput();
            if (CheckIfAnswerIsNo(answer))
            {
                _userInterface.ShowToUser("Another game?(y/n)");
                answer = _userInterface.GetUserInput();
                if (CheckIfAnswerIsYes(answer))
                {
                    _userInterface.Clear();
                    _game = _userInterface.SelectGame();
                }
                else
                {
                    _playOn = false;
                }
            }
        }

        public void Run()
        {
            while (_playOn)
            {
                _userInterface.Clear();
                _game.Run(_user);
                CheckToContinue();
            }
            _userInterface.Exit();
        }
    }
}