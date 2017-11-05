using GenericListLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zadatak2.Tests
{
    [TestClass]
    public class TodoRepositoryTests
    {
        [TestMethod]
        public void TodoRepository()
        {
            var repo = new TodoRepository(null);
            Assert.IsNotNull(repo.GetAll());
            Assert.AreEqual(repo.GetAll().Count, 0);

            GenericList<TodoItem> list = new GenericList<TodoItem>(1);
            var t1 = new TodoItem("1");
            var t2 = new TodoItem("2");
            list.Add(t1);
            list.Add(t2);
            var repo2 = new TodoRepository(list);
            Assert.IsNotNull(repo2.GetAll());
            Assert.AreEqual(repo2.GetAll().Count, 2);
        }

        [TestMethod]
        public void GetTest()
        {
            var repo = new TodoRepository(null);
            var t1 = new TodoItem("1");
            Assert.IsNull(repo.Get(t1.Id));
            repo.Add(t1);
            Assert.AreEqual(repo.Get(t1.Id), t1);
            repo.Remove(t1.Id);
            Assert.IsNull(repo.Get(t1.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddTest_ThrowsDuplicateTodoItemException()
        {
            var repo = new TodoRepository(null);
            var t1 = new TodoItem("1");
            repo.Add(t1);
            repo.Add(t1);
        }

        [TestMethod]
        public void AddTest()
        {
            var repo = new TodoRepository(null);
            Assert.AreEqual(repo.GetAll().Count, 0);
            for (var i = 0; i < 10; i++)
            {
                var t = new TodoItem("test");
                repo.Add(t);
            }
            Assert.AreEqual(repo.GetAll().Count, 10);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var repo = new TodoRepository(null);
            var t1 = new TodoItem("1");
            var t2 = new TodoItem("2");
            var t3 = new TodoItem("3");
            var t4 = new TodoItem("4");
            var t5 = new TodoItem("5");
            repo.Add(t1);
            repo.Add(t2);
            repo.Add(t3);
            repo.Add(t4);
            repo.Add(t5);

            Assert.IsTrue(repo.Remove(t2.Id));
            Assert.AreEqual(repo.GetAll().Count, 4);
            Assert.IsFalse(repo.Remove(t2.Id));
        }

        [TestMethod]
        public void UpdateTest()
        {
            var repo = new TodoRepository(null);
            var t1 = new TodoItem("1");
            Assert.AreEqual(repo.Update(t1), t1);
            Assert.AreEqual(repo.Update(t1), t1);
            t1.Text = "2";
            Assert.AreEqual(repo.Update(t1), t1);
        }

        [TestMethod]
        public void MarkAsCompletedTest()
        {
            var repo = new TodoRepository(null);
            var t1 = new TodoItem("1");
            repo.Add(t1);
            Assert.IsTrue(repo.MarkAsCompleted(t1.Id));
            Assert.IsFalse(repo.MarkAsCompleted(t1.Id));
            Assert.IsTrue(t1.IsCompleted);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var repo = new TodoRepository(null);
            var t1 = new TodoItem("1");
            var t2 = new TodoItem("2");
            var t3 = new TodoItem("3");
            var t4 = new TodoItem("4");
            var t5 = new TodoItem("5");
            repo.Add(t1);
            repo.Add(t2);
            repo.Add(t3);
            repo.Add(t4);
            repo.Add(t5);
            Assert.AreEqual(repo.GetAll().Count, 5);
        }

        [TestMethod]
        public void GetActiveTest()
        {
            var repo = new TodoRepository(null);
            var t1 = new TodoItem("1");
            var t2 = new TodoItem("2");
            var t3 = new TodoItem("3");
            var t4 = new TodoItem("4");
            var t5 = new TodoItem("5");
            repo.Add(t1);
            repo.Add(t2);
            repo.Add(t3);
            repo.Add(t4);
            repo.Add(t5);
            Assert.AreEqual(repo.GetActive().Count, 5);
            t1.MarkAsCompleted();
            Assert.AreEqual(repo.GetActive().Count, 4);
        }

        [TestMethod]
        public void GetCompletedTest()
        {
            var repo = new TodoRepository(null);
            var t1 = new TodoItem("1");
            var t2 = new TodoItem("2");
            var t3 = new TodoItem("3");
            var t4 = new TodoItem("4");
            var t5 = new TodoItem("5");
            repo.Add(t1);
            repo.Add(t2);
            repo.Add(t3);
            repo.Add(t4);
            repo.Add(t5);
            Assert.AreEqual(repo.GetCompleted().Count, 0);
            t1.MarkAsCompleted();
            Assert.AreEqual(repo.GetCompleted().Count, 1);
        }

        [TestMethod]
        public void GetFilteredTest()
        {
            var repo = new TodoRepository(null);
            var t1 = new TodoItem("1");
            var t2 = new TodoItem("2");
            var t3 = new TodoItem("3");
            var t4 = new TodoItem("4");
            var t5 = new TodoItem("5");
            repo.Add(t1);
            repo.Add(t2);
            repo.Add(t3);
            repo.Add(t4);
            repo.Add(t5);
            Assert.AreEqual(repo.GetFiltered(item => int.Parse(item.Text) > 2).Count, 3);
        }
    }
}