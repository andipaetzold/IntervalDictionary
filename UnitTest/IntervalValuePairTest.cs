namespace Paetzold.Collections.IntervalDictionary.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Paetzold.Collections.IntervalDictionary;

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
