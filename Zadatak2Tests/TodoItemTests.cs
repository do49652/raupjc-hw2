using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zadatak2.Tests
{
    [TestClass]
    public class TodoItemTests
    {
        [TestMethod]
        public void MarkAsCompletedTest()
        {
            var t = new TodoItem("test");
            Assert.AreEqual(t.IsCompleted, false);
            Assert.AreEqual(t.MarkAsCompleted(), true);
            Assert.AreEqual(t.IsCompleted, true);
            Assert.AreEqual(t.MarkAsCompleted(), false);
        }

        [TestMethod]
        public void EqualsTest()
        {
            var t1 = new TodoItem("test");
            var t2 = new TodoItem("test");
            Assert.AreEqual(t1.Equals(t2), false);
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            var t1 = new TodoItem("test");
            var t2 = new TodoItem("test");
            Assert.AreNotEqual(t1.GetHashCode(), t2.GetHashCode());
        }
    }
}