﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Responsible.Utilities.Extentions;

namespace Responsible.Utilities.Tests
{
    [TestClass]
    public class EnumTests
    {
        internal enum WeekDays
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7
        }

        [TestMethod]
        public void WeekDay_Distionary()
        {
            var result = EnumExtentions.EnumDictionary<WeekDays>();

            Assert.AreEqual(7, result.Count, "Dictionary count is not same");

            Assert.IsTrue(result.ContainsKey(1), "Does not contain key");
            Assert.IsTrue(result.ContainsKey(2), "Does not contain key");
            Assert.IsTrue(result.ContainsKey(3), "Does not contain key");
            Assert.IsTrue(result.ContainsKey(4), "Does not contain key");
            Assert.IsTrue(result.ContainsKey(5), "Does not contain key");
            Assert.IsTrue(result.ContainsKey(6), "Does not contain key");
            Assert.IsTrue(result.ContainsKey(7), "Does not contain key");

            Assert.IsTrue(result.ContainsValue(WeekDays.Monday.ToString()), "Does not contain value");
            Assert.IsTrue(result.ContainsValue(WeekDays.Tuesday.ToString()), "Does not contain value");
            Assert.IsTrue(result.ContainsValue(WeekDays.Wednesday.ToString()), "Does not contain value");
            Assert.IsTrue(result.ContainsValue(WeekDays.Thursday.ToString()), "Does not contain value");
            Assert.IsTrue(result.ContainsValue(WeekDays.Friday.ToString()), "Does not contain value");
            Assert.IsTrue(result.ContainsValue(WeekDays.Saturday.ToString()), "Does not contain value");
            Assert.IsTrue(result.ContainsValue(WeekDays.Sunday.ToString()), "Does not contain value");
        }

        [TestMethod]
        public void WeekDay_Distionary_Extention()
        {
            var result = WeekDays.Monday.EnumDictionary();

            Assert.AreEqual(7, result.Count, "Dictionary count is not same");

            Assert.IsTrue(result.ContainsKey(1), "Does not contain key");
            Assert.IsTrue(result.ContainsKey(2), "Does not contain key");
            Assert.IsTrue(result.ContainsKey(3), "Does not contain key");
            Assert.IsTrue(result.ContainsKey(4), "Does not contain key");
            Assert.IsTrue(result.ContainsKey(5), "Does not contain key");
            Assert.IsTrue(result.ContainsKey(6), "Does not contain key");
            Assert.IsTrue(result.ContainsKey(7), "Does not contain key");

            Assert.IsTrue(result.ContainsValue(WeekDays.Monday.ToString()), "Does not contain value");
            Assert.IsTrue(result.ContainsValue(WeekDays.Tuesday.ToString()), "Does not contain value");
            Assert.IsTrue(result.ContainsValue(WeekDays.Wednesday.ToString()), "Does not contain value");
            Assert.IsTrue(result.ContainsValue(WeekDays.Thursday.ToString()), "Does not contain value");
            Assert.IsTrue(result.ContainsValue(WeekDays.Friday.ToString()), "Does not contain value");
            Assert.IsTrue(result.ContainsValue(WeekDays.Saturday.ToString()), "Does not contain value");
            Assert.IsTrue(result.ContainsValue(WeekDays.Sunday.ToString()), "Does not contain value");
        }


        [TestMethod]
        public void WeekDay_StringList()
        {
            var result = WeekDays.Monday.EnumStringList();

            Assert.AreEqual(7, result.Count, "List count is not same");

            Assert.IsTrue(result.Contains(WeekDays.Monday.ToString()), "Does not contain value");
            Assert.IsTrue(result.Contains(WeekDays.Tuesday.ToString()), "Does not contain value");
            Assert.IsTrue(result.Contains(WeekDays.Wednesday.ToString()), "Does not contain value");
            Assert.IsTrue(result.Contains(WeekDays.Thursday.ToString()), "Does not contain value");
            Assert.IsTrue(result.Contains(WeekDays.Friday.ToString()), "Does not contain value");
            Assert.IsTrue(result.Contains(WeekDays.Saturday.ToString()), "Does not contain value");
            Assert.IsTrue(result.Contains(WeekDays.Sunday.ToString()), "Does not contain value");
        }

        [TestMethod]
        public void WeekDay_RecordIdentities()
        {
            var result = EnumExtentions.EnumRecordIdentities<WeekDays>();

            Assert.AreEqual(7, result.Count, "Dictionary count is not same");

            Assert.IsTrue(result.Any(x => x.Id == 1), "Does not contain key");
            Assert.IsTrue(result.Any(x => x.Id == 2), "Does not contain key");
            Assert.IsTrue(result.Any(x => x.Id == 3), "Does not contain key");
            Assert.IsTrue(result.Any(x => x.Id == 4), "Does not contain key");
            Assert.IsTrue(result.Any(x => x.Id == 5), "Does not contain key");
            Assert.IsTrue(result.Any(x => x.Id == 6), "Does not contain key");
            Assert.IsTrue(result.Any(x => x.Id == 7), "Does not contain key");

            Assert.IsTrue(result.Any(x => x.Name == WeekDays.Monday.ToString()), "Does not contain value");
            Assert.IsTrue(result.Any(x => x.Name == WeekDays.Tuesday.ToString()), "Does not contain value");
            Assert.IsTrue(result.Any(x => x.Name == WeekDays.Wednesday.ToString()), "Does not contain value");
            Assert.IsTrue(result.Any(x => x.Name == WeekDays.Thursday.ToString()), "Does not contain value");
            Assert.IsTrue(result.Any(x => x.Name == WeekDays.Friday.ToString()), "Does not contain value");
            Assert.IsTrue(result.Any(x => x.Name == WeekDays.Saturday.ToString()), "Does not contain value");
            Assert.IsTrue(result.Any(x => x.Name == WeekDays.Sunday.ToString()), "Does not contain value");
        }
    }
}
