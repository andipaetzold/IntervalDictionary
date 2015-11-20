namespace Paetzold.Collections.IntervalDictionary.UnitTest
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntervalDictionaryTest
    {
        #region Clear

        [TestMethod]
        public void Clear()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            Assert.AreEqual(3, intervalDictionary.Count);

            intervalDictionary.Clear();

            Assert.AreEqual(0, intervalDictionary.Count);
        }

        #endregion

        #region Enumerator

        [TestMethod]
        public void GetEnumerator()
        {
            var intervalDictionary = new IntervalDictionary<int, string>();

            var intervalValuePair1 = new IntervalValuePair<int, string>(new Interval<int>(5, 10), "5 - 10");
            var intervalValuePair2 = new IntervalValuePair<int, string>(new Interval<int>(15, 20), "15 - 20");
            var intervalValuePair3 = new IntervalValuePair<int, string>(new Interval<int>(25, 25), "25 - 25");

            intervalDictionary.Add(intervalValuePair1);
            intervalDictionary.Add(intervalValuePair2);
            intervalDictionary.Add(intervalValuePair3);

            foreach (var pair in intervalDictionary)
            {
                Assert.IsTrue(
                    pair.Equals(intervalValuePair1) || pair.Equals(intervalValuePair2)
                    || pair.Equals(intervalValuePair3));
            }
        }

        [TestMethod]
        public void IEnumerableGetEnumerator()
        {
            var intervalDictionary = new IntervalDictionary<int, string>();

            var intervalValuePair1 = new IntervalValuePair<int, string>(new Interval<int>(5, 10), "5 - 10");
            var intervalValuePair2 = new IntervalValuePair<int, string>(new Interval<int>(15, 20), "15 - 20");
            var intervalValuePair3 = new IntervalValuePair<int, string>(new Interval<int>(25, 25), "25 - 25");

            intervalDictionary.Add(intervalValuePair1);
            intervalDictionary.Add(intervalValuePair2);
            intervalDictionary.Add(intervalValuePair3);

            foreach (var pair in (IEnumerable)intervalDictionary)
            {
                Assert.IsTrue(
                    pair.Equals(intervalValuePair1) || pair.Equals(intervalValuePair2)
                    || pair.Equals(intervalValuePair3));
            }
        }

        #endregion

        #region Remove

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveKeyArgumentNullException()
        {
            var intervalDictionary = new IntervalDictionary<string, string>
                                         {
                                             {
                                                 new Interval<string>("a", "c"),
                                                 "a - c"
                                             },
                                             {
                                                 new Interval<string>("h", "j"),
                                                 "h - j"
                                             },
                                             {
                                                 new Interval<string>("x", "z"),
                                                 "x - z"
                                             }
                                         };

            intervalDictionary.Remove(key: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveIntervalArgumentNullException()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            intervalDictionary.Remove(null);
        }

        #endregion

        #region Add

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddArgumentException1()
        {
            // ReSharper disable once UnusedVariable
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(7, 15), "7 - 15" }
                                         };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddArgumentException2()
        {
            // ReSharper disable once UnusedVariable
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(7, 9), "7 - 9" }
                                         };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddArgumentNullException1()
        {
            // ReSharper disable once UnusedVariable
            var intervalDictionary = new IntervalDictionary<int, string> { { null, "5 - 10" } };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddArgumentNullException2()
        {
            // ReSharper disable once UnusedVariable
            var intervalDictionary = new IntervalDictionary<int, string> { { new Interval<int>(5, 10), null } };
        }

        #endregion

        #region Properties

        [TestMethod]
        public void Count()
        {
            var intervalDictionary = new IntervalDictionary<int, string>();

            Assert.AreEqual(0, intervalDictionary.Count);

            intervalDictionary.Add(new Interval<int>(5, 10), "5 - 10");
            intervalDictionary.Add(new Interval<int>(15, 20), "15 - 20");
            intervalDictionary.Add(new Interval<int>(25, 25), "25 - 25");

            Assert.AreEqual(3, intervalDictionary.Count);

            intervalDictionary.Remove(new Interval<int>(15, 20));

            Assert.AreEqual(2, intervalDictionary.Count);
        }

        [TestMethod]
        public void ReadOnly()
        {
            var intervalDictionary = new IntervalDictionary<int, string>();

            Assert.AreEqual(false, intervalDictionary.IsReadOnly);
        }

        [TestMethod]
        public void Intervals()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            var intervals = intervalDictionary.Intervals;

            Assert.IsTrue(intervals.Contains(new Interval<int>(5, 10)));
            Assert.IsTrue(intervals.Contains(new Interval<int>(15, 20)));
            Assert.IsTrue(intervals.Contains(new Interval<int>(25, 25)));
        }

        [TestMethod]
        public void Values()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            var intervals = intervalDictionary.Values;

            Assert.IsTrue(intervals.Contains("5 - 10"));
            Assert.IsTrue(intervals.Contains("15 - 20"));
            Assert.IsTrue(intervals.Contains("25 - 25"));
        }

        #endregion

        #region CopyTo

        [TestMethod]
        public void CopyTo()
        {
            var intervalDictionary = new IntervalDictionary<int, string>();

            var intervalValuePair1 = new IntervalValuePair<int, string>(new Interval<int>(5, 10), "5 - 10");
            var intervalValuePair2 = new IntervalValuePair<int, string>(new Interval<int>(15, 20), "15 - 20");
            var intervalValuePair3 = new IntervalValuePair<int, string>(new Interval<int>(25, 25), "25 - 25");

            intervalDictionary.Add(intervalValuePair1);
            intervalDictionary.Add(intervalValuePair2);
            intervalDictionary.Add(intervalValuePair3);

            var a = new IntervalValuePair<int, string>[5];

            intervalDictionary.CopyTo(a, 0);

            Assert.AreEqual(intervalValuePair1, a[0]);
            Assert.AreEqual(intervalValuePair2, a[1]);
            Assert.AreEqual(intervalValuePair3, a[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyToArgumentNullException()
        {
            var intervalDictionary = new IntervalDictionary<int, string>();

            var intervalValuePair1 = new IntervalValuePair<int, string>(new Interval<int>(5, 10), "5 - 10");
            var intervalValuePair2 = new IntervalValuePair<int, string>(new Interval<int>(15, 20), "15 - 20");
            var intervalValuePair3 = new IntervalValuePair<int, string>(new Interval<int>(25, 25), "25 - 25");

            intervalDictionary.Add(intervalValuePair1);
            intervalDictionary.Add(intervalValuePair2);
            intervalDictionary.Add(intervalValuePair3);

            // ReSharper disable once AssignNullToNotNullAttribute
            intervalDictionary.CopyTo(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyToArgumentOutOfRangeException()
        {
            var intervalDictionary = new IntervalDictionary<int, string>();

            var intervalValuePair1 = new IntervalValuePair<int, string>(new Interval<int>(5, 10), "5 - 10");
            var intervalValuePair2 = new IntervalValuePair<int, string>(new Interval<int>(15, 20), "15 - 20");
            var intervalValuePair3 = new IntervalValuePair<int, string>(new Interval<int>(25, 25), "25 - 25");

            intervalDictionary.Add(intervalValuePair1);
            intervalDictionary.Add(intervalValuePair2);
            intervalDictionary.Add(intervalValuePair3);

            var a = new IntervalValuePair<int, string>[5];

            intervalDictionary.CopyTo(a, -1);
        }

        #endregion

        #region Indexer 

        [TestMethod]
        public void IndexerGetInterval()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            Assert.AreEqual("5 - 10", intervalDictionary[new Interval<int>(5, 10)]);
        }

        [TestMethod]
        public void IndexerSetInterval()
        {
            var intervalDictionary = new IntervalDictionary<int, string>();
            intervalDictionary[new Interval<int>(5, 10)] = "5 - 10";
            intervalDictionary[new Interval<int>(15, 20)] = "15 - 20";
            intervalDictionary[new Interval<int>(25, 25)] = "25 - 25";

            Assert.AreEqual("5 - 10", intervalDictionary[new Interval<int>(5, 10)]);
        }

        [TestMethod]
        public void IndexerGetKey()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            Assert.AreEqual("15 - 20", intervalDictionary[17]);
            Assert.AreEqual("25 - 25", intervalDictionary[25]);
        }

        [TestMethod]
        public void IndexerSetKey()
        {
            var intervalDictionary = new IntervalDictionary<int, string>();

            intervalDictionary[10] = "10 - 10";
            intervalDictionary[15] = "15 - 15";
            intervalDictionary[20] = "20 - 20";

            Assert.AreEqual("10 - 10", intervalDictionary[10]);
            Assert.AreEqual("15 - 15", intervalDictionary[15]);
            Assert.AreEqual("20 - 20", intervalDictionary[20]);
        }

        #endregion

        #region GetValue

        [TestMethod]
        public void GetValueInterval()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            Assert.AreEqual("5 - 10", intervalDictionary.GetValue(new Interval<int>(5, 10)));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetValueIntervalException()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            Assert.AreEqual("5 - 15", intervalDictionary.GetValue(new Interval<int>(5, 15)));
        }

        [TestMethod]
        public void TryGetValueInterval()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            string result;

            Assert.IsFalse(intervalDictionary.TryGetValue(new Interval<int>(5, 15), out result));
            Assert.IsTrue(intervalDictionary.TryGetValue(new Interval<int>(5, 10), out result));
            Assert.AreEqual("5 - 10", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryGetValueIntervalArgumentNullException()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            intervalDictionary.GetValue(null);
        }

        [TestMethod]
        public void GetValueKey()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            Assert.AreEqual("15 - 20", intervalDictionary.GetValue(15));
            Assert.AreEqual("15 - 20", intervalDictionary.GetValue(17));
            Assert.AreEqual("25 - 25", intervalDictionary.GetValue(25));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetValueKeyException()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            intervalDictionary.GetValue(30);
        }

        [TestMethod]
        public void TryGetValueBound()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            string result;

            Assert.IsFalse(intervalDictionary.TryGetValue(30, out result));
            Assert.IsTrue(intervalDictionary.TryGetValue(25, out result));
            Assert.AreEqual("25 - 25", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryGetValueBoundArgumentNullException()
        {
            var intervalDictionary = new IntervalDictionary<string, string>
                                         {
                                             {
                                                 new Interval<string>("a", "c"),
                                                 "a - c"
                                             },
                                             {
                                                 new Interval<string>("h", "j"),
                                                 "h - j"
                                             },
                                             {
                                                 new Interval<string>("x", "z"),
                                                 "x - z"
                                             }
                                         };

            intervalDictionary.GetValue(key: null);
        }

        #endregion

        #region Contains

        [TestMethod]
        public void Contains()
        {
            var intervalDictionary = new IntervalDictionary<int, string>();

            var intervalValuePair1 = new IntervalValuePair<int, string>(new Interval<int>(5, 10), "5 - 10");
            var intervalValuePair2 = new IntervalValuePair<int, string>(new Interval<int>(15, 20), "15 - 20");
            var intervalValuePair3 = new IntervalValuePair<int, string>(new Interval<int>(25, 25), "25 - 25");

            intervalDictionary.Add(intervalValuePair1);
            intervalDictionary.Add(intervalValuePair3);

            Assert.IsTrue(intervalDictionary.Contains(intervalValuePair1));
            Assert.IsFalse(intervalDictionary.Contains(intervalValuePair2));
            Assert.IsTrue(intervalDictionary.Contains(intervalValuePair3));
        }

        [TestMethod]
        public void ContainsKey()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            Assert.IsTrue(intervalDictionary.ContainsKey(5));
            Assert.IsTrue(intervalDictionary.ContainsKey(7));
            Assert.IsTrue(intervalDictionary.ContainsKey(25));
            Assert.IsFalse(intervalDictionary.ContainsKey(30));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsKeyArgumentNullException()
        {
            var intervalDictionary = new IntervalDictionary<string, string>
                                         {
                                             {
                                                 new Interval<string>("a", "c"),
                                                 "a - c"
                                             },
                                             {
                                                 new Interval<string>("h", "j"),
                                                 "h - j"
                                             },
                                             {
                                                 new Interval<string>("x", "z"),
                                                 "x - z"
                                             }
                                         };

            intervalDictionary.ContainsKey(null);
        }

        [TestMethod]
        public void ContainsInterval()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            Assert.IsTrue(intervalDictionary.ContainsInterval(new Interval<int>(5, 10)));
            Assert.IsTrue(intervalDictionary.ContainsInterval(new Interval<int>(17, 18)));
            Assert.IsTrue(intervalDictionary.ContainsInterval(new Interval<int>(25, 25)));
            Assert.IsFalse(intervalDictionary.ContainsInterval(new Interval<int>(17, 25)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsIntervalArgumentNullException()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            intervalDictionary.ContainsInterval(null);
        }

        [TestMethod]
        public void ContainsValue()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            Assert.IsTrue(intervalDictionary.ContainsValue("5 - 10"));
            Assert.IsFalse(intervalDictionary.ContainsValue("5 - 15"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsValueArgumentNullException()
        {
            var intervalDictionary = new IntervalDictionary<int, string>
                                         {
                                             { new Interval<int>(5, 10), "5 - 10" },
                                             { new Interval<int>(15, 20), "15 - 20" },
                                             { new Interval<int>(25, 25), "25 - 25" }
                                         };

            intervalDictionary.ContainsValue(null);
        }

        #endregion
    }
}
