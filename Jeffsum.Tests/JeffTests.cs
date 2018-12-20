using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Jeffsum.Tests
{
    [TestClass]
    public class JeffTests
    {
        [TestMethod]
        public void ReceiveOneJeff()
        {
            var jeffs = Goldblum.ReceiveTheJeff(1);

            Assert.AreEqual(1, jeffs.Count());
            Assert.IsTrue(jeffs.First().Length > 0);
        }

        [TestMethod]
        public void ReceiveMultiJeff()
        {
            var random = new Random();
            var count = random.Next(1, 10);
            var jeffs = Goldblum.ReceiveTheJeff(count);

            Assert.AreEqual(count, jeffs.Count());
            for (var i = 0; i < count; i++)
                Assert.IsTrue(jeffs.ElementAt(i).Length > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooManyJeffs()
        {
            Goldblum.ReceiveTheJeff(100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NotEnoughJeffs()
        {
            Goldblum.ReceiveTheJeff(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeJeffs()
        {
            Goldblum.ReceiveTheJeff(-1);
        }

        [TestMethod]
        public void ValidRanges()
        {
            var count = 5;
            Assert.IsTrue(count.ValidRange(4, 6));
        }

        [TestMethod]
        public void ToLowRange()
        {
            var count = 3;
            Assert.IsFalse(count.ValidRange(4, 6));
        }

        [TestMethod]
        public void ToHighRange()
        {
            var count = 7;
            Assert.IsFalse(count.ValidRange(4, 6));
        }
    }
}
