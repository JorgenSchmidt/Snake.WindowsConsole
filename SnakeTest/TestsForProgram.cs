using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;

namespace SnakeTest
{
    [TestClass]
    public class TestsForProgram
    { 

        [TestMethod]
        public void TimeCountDown_secondsToString_01()
        {
            TimeCountDown time = new TimeCountDown(3, 0);
            Assert.AreEqual("3:00", time.secondsToString(0));
        }

        [TestMethod]
        public void TimeCountDown_secondsToString_02()
        {
            TimeCountDown time = new TimeCountDown(3, 1);
            Assert.AreEqual("4:01", time.secondsToString(60));
        }

        [TestMethod]
        public void TimeCountDown_secondsToString_03()
        {
            TimeCountDown time = new TimeCountDown(0, 1);
            Assert.AreEqual("0:59", time.secondsToString(58));
        }

    }
}
