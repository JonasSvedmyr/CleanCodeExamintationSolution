using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeExamination;
using CleanCodeExamintation.Interfaces;

namespace CleanCodeExaminationTests.Mockups
{
    class UserInterfaceMockup : IUserInterface
    {
        public void Clear()
        {
            
        }

        public void Exit()
        {
            
        }

        public string GetUser()
        {
            return "test";
        }

        public string GetUserInput()
        {
            return "";
        }

        public IGame SelectGame()
        {
            throw new NotImplementedException();
        }

        public void ShowToUser(string output)
        {
            
        }
    }
}
