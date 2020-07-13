using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using NUnit.Framework;
using System.Collections;

namespace HealthYes.Web.UnitTests.Core.Extensions
{
    [TestFixture]
    public class EnumerableExtensionsTester
    {
        [Test]
        public void IsEmptyReturnsTrueWhenListContainsZeroItems()
        {
            IList list = new List<int>();

            bool isEmpty = list.IsEmpty();

            Assert.IsTrue(isEmpty);
        }

        [Test]
        public void IsEmptyReturnsFalseWhenListContainsOneItem()
        {
            IList list = new List<int> {5};

            bool isEmpty = list.IsEmpty();
            
            Assert.IsFalse(isEmpty);
        }

        [Test]
        public void IsEmptyReturnsFalseWhenListContainsMultipleItems()
        {
            IList list = new List<int> {5};
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
                bool isEmpty = list.IsEmpty();
                Assert.IsFalse(isEmpty, string.Format("List with {0} items returned true for IsEmpty().", list.Count));
            }
        }

        [Test]
        public void HasSingleItemReturnsFalseWhenListContainsZeroItems()
        {
            IList list = new List<int>();

            bool hasSingleItem = list.HasSingleItem();

            Assert.IsFalse(hasSingleItem);
        }

        [Test]
        public void HasSingleItemReturnsTrueWhenListContainsOneItem()
        {
            IList list = new List<int> {5};

            bool hasSingleItem = list.HasSingleItem();

            Assert.IsTrue(hasSingleItem);
        }

        [Test]
        public void HasSingleItemReturnsFalseWhenListContainsMoreThanOneItem()
        {
            IList list = new List<int> { 5 };
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
                bool hasSingleItem = list.HasSingleItem();
                Assert.IsFalse(hasSingleItem, string.Format("List with {0} items returned true for HasSingleItem().", list.Count));
            }
        }

        [Test]
        public void CountReturnsZeroWhenNoElementsExistInGivenEnumerable()
        {
            IEnumerable enumerable = new List<int>();

            int count = enumerable.Count();

            Assert.AreEqual(0, count);
        }

        [Test]
        public void CountReturnsOneWhenOneElementExistsInGivenEnumerable()
        {
            IEnumerable enumerable = new List<int> {1};

            int count = enumerable.Count();

            Assert.AreEqual(1, count);
        }

        [Test]
        public void CountReturnsNumberOfElementsInGivenEnumerable()
        {
            IEnumerable<int> enumerable;

            for (int i = 2; i < 10; i++)
            {
                enumerable = new int[i];
                int count = enumerable.Count();
                Assert.AreEqual(i, count, string.Format("{0} expected but {1} returned.", i, count));
            }
        }
    }
}