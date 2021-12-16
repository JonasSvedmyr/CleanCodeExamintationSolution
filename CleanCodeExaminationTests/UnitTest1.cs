using CleanCodeExaminationTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanCodeExamination;

namespace CleanCodeExaminationTests
{
    [TestClass]
    public class UnitTest1
    {
        GuessNumber guessNumber;
        BullsAndCows bullsAndCows;
        [TestInitialize]
        public void TestInitialize()
        {
            guessNumber = new GuessNumber(new UserInterfaceMockup(), new StatisticsMockup());
            bullsAndCows = new BullsAndCows(new UserInterfaceMockup(), new StatisticsMockup());
        }
        [TestMethod]
        public void TestGuessNumberGoalGeneration()
        {
            var goal = guessNumber.MakeGoal();
            var success = int.Parse(goal) < 101 && int.Parse(goal) > 0 ? true : false;
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void TestGuessNumberCheckAnswerCorrect()
        {
            var answer = guessNumber.CheckAnswer("5", "5");
            Assert.AreEqual(answer,"Correct");
        }
        [TestMethod]
        public void TestGuessNumberCheckAnswerToHigh()
        {
            var answer = guessNumber.CheckAnswer("5", "10");
            Assert.AreEqual(answer, "Lower");
        }
        [TestMethod]
        public void TestGuessNumberCheckAnswerToLow()
        {
            var answer = guessNumber.CheckAnswer("5", "1");
            Assert.AreEqual(answer, "Higher");
        }

        [TestMethod]
        public void TestBullsAndCowsGoalGeneration()
        {
            var goal = bullsAndCows.MakeGoal();
            var success = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(i == j)
                    {
                        continue;
                    }
                    else
                    {
                        if (goal[i] == goal[j])
                        {
                            success = false; 
                        }
                    }
                }
            }
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void TestBullsAndCowsCheckAnswerAllCorrect()
        {
            var answer = bullsAndCows.CheckAnswer("1234", "1234");
            Assert.AreEqual("BBBB,", answer);
        }
        [TestMethod]
        public void TestBullsAndCowsCheckAnswerTwoBulls()
        {
            var answer = bullsAndCows.CheckAnswer("1234", "1255");
            Assert.AreEqual("BB,", answer);
        }
        [TestMethod]
        public void TestBullsAndCowsCheckAnswerTwoCows()
        {
            var answer = bullsAndCows.CheckAnswer("1234", "5713");
            Assert.AreEqual(",CC", answer);
        }
        [TestMethod]
        public void TestBullsAndCowsCheckAnswerOneBullTwoCows()
        {
            var answer = bullsAndCows.CheckAnswer("1234", "1427");
            Assert.AreEqual("B,CC", answer);
        }
    }
}
