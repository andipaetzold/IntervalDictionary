namespace UnitTest
{
    using System;
    using IntervalDictionary;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntervalTest
    {
        #region Intersects

        [TestMethod]
        public void Intersects()
        {
            IInterval<int> interval1 = new Interval<int>(5, 10);
            IInterval<int> interval2 = new Interval<int>(7, 15);
            IInterval<int> interval3 = new Interval<int>(0, 5);

            Assert.IsTrue(interval1.Intersects(interval2));
            Assert.IsTrue(interval2.Intersects(interval1));

            Assert.IsTrue(interval1.Intersects(interval3));
            Assert.IsTrue(interval3.Intersects(interval1));

            Assert.IsFalse(interval2.Intersects(interval3));
            Assert.IsFalse(interval3.Intersects(interval2));
        }

        #endregion

        #region Contains

        [TestMethod]
        public void Contains()
        {
            IInterval<int> interval = new Interval<int>(5, 10);

            Assert.IsTrue(interval.Contains(5));
            Assert.IsTrue(interval.Contains(7));
            Assert.IsTrue(interval.Contains(10));

            Assert.IsFalse(interval.Contains(4));
            Assert.IsFalse(interval.Contains(11));
        }

        #endregion

        #region CompareTo

        [TestMethod]
        public void CompareTo()
        {
            IInterval<int> interval = new Interval<int>(5, 15);

            Assert.IsTrue(interval.CompareTo(20) > 0);
            Assert.IsTrue(interval.CompareTo(10) == 0);
            Assert.IsTrue(interval.CompareTo(0) < 0);
        }

        #endregion

        #region Equals

        [TestMethod]
        public void Equals()
        {
            IInterval<int> interval1 = new Interval<int>(5, 15);
            IInterval<int> interval2 = new Interval<int>(5, 15);
            IInterval<int> interval3 = new Interval<int>(5, 20);

            Assert.IsTrue(interval1.Equals(interval2));
            Assert.IsFalse(interval1.Equals(interval3));
        }

        #endregion

        #region ToString

        [TestMethod]
        public void String()
        {
            IInterval<int> interval = new Interval<int>(5, 10);

            Assert.AreEqual("[5, 10]", interval.ToString());
        }

        #endregion

        #region Constructor

        [TestMethod]
        public void ConstructorDefault()
        {
            IInterval<int> interval = new Interval<int>(5, 10);

            Assert.AreEqual(5, interval.LowerBound);
            Assert.AreEqual(10, interval.UpperBound);
        }

        [TestMethod]
        public void ConstructorWrongOrder()
        {
            IInterval<int> interval = new Interval<int>(10, 5);

            Assert.AreEqual(5, interval.LowerBound);
            Assert.AreEqual(10, interval.UpperBound);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorNullException1()
        {
            IInterval<string> interval = new Interval<string>("a", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorNullException2()
        {
            IInterval<string> interval = new Interval<string>(null, "b");
        }

        #endregion
    }
}
