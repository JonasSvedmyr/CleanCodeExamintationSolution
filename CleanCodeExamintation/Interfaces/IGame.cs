using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination
{
    public interface IGame
    {
        public string MakeGoal();
        public void Run(string name);
        public string CheckAnswer(string goal, string guess);
    }
}
