using CleanCodeExamination;
using System;

namespace CleanCodeExamintation
{
    class Program
    {
        public static void Main(string[] args)
        {
            var userInterface = new UserInterface();
            Controller controller = new Controller(userInterface);
            controller.Run();
        }
    }
}
