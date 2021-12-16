using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination
{
    public interface IStatistics
    {
        public void showTopList();
        public void AddScoreToTopList(string name, int nGuess);
    }
}
