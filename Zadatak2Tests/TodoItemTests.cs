using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zadatak2.Tests
{
    [TestClass]
    public class TodoItemTests
    {
        [TestMethod]
        public void TodoItem()
        {
            var t = new TodoItem("test");
            Assert.AreEqual(t.Text,"test");
            Assert.IsFalse(t.IsCompleted);
        }

        [TestMethod]
        public void MarkAsCompletedTest()
        {
            var t = new TodoItem("test");
            Assert.IsFalse(t.IsCompleted);
            Assert.IsTrue(t.MarkAsCompleted());
            Assert.IsTrue(t.IsCompleted);
            Assert.IsFalse(t.MarkAsCompleted());
        }

        [TestMethod]
        public void EqualsTest()
        {
            var t1 = new TodoItem("test");
            var t2 = new TodoItem("test");
            Assert.AreNotEqual(t1, t2);
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