namespace UnitTest
{
    using IntervalDictionary;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntervalValuePairTest
    {
        #region ToString

        [TestMethod]
        public void String()
        {
            var intervalValuePair = new IntervalValuePair<int, string>(new Interval<int>(5, 10), "5 - 10");

            Assert.AreEqual("[5, 10]: 5 - 10", intervalValuePair.ToString());
        }

        #endregion
    }
}
