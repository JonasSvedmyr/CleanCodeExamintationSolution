using CleanCodeExamination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamintation.Interfaces
{
    public interface IUserInterface
    {
        public void ShowToUser(string output);
        public string GetUserInput();
        public string GetUser();
        public IGame SelectGame();
        public void Clear();
        public void Exit();

    }
}
