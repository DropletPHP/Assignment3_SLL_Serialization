using Assignment3.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    [TestFixture]
    public class SLLTest
    {
        private SLL list;
        private User user1;
        private User user2;
        private User user3;

        [SetUp]
        public void Setup()
        {
            list = new SLL();
            user1 = new User(1, "Alice", "alice@example.com", "password1");
            user2 = new User(2, "Bob", "bob@example.com", "password2");
            user3 = new User(3, "Carol", "carol@example.com", "password3");
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestPrepend()
        {
            list.AddFirst(user1);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user1, list.GetValue(0));
        }

        [Test]
        public void TestAppend()
        {
            list.AddLast(user1);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user1, list.GetValue(0));
        }

        [Test]
        public void TestInsertAtIndex()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            list.Add(user3, 1);
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(user3, list.GetValue(1));
        }

        [Test]
        public void TestReplace()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            list.Replace(user3, 1);
            Assert.AreEqual(user3, list.GetValue(1));
        }

        [Test]
        public void TestDeleteFromBeginning()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            list.RemoveFirst();
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user2, list.GetValue(0));
        }

        [Test]
        public void TestDeleteFromEnd()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            list.RemoveLast();
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user1, list.GetValue(0));
        }

        [Test]
        public void TestDeleteFromMiddle()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);
            list.Remove(1);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(user1, list.GetValue(0));
            Assert.AreEqual(user3, list.GetValue(1));
        }

        [Test]
        public void TestFindAndRetrieve()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            int index = list.IndexOf(user2);
            User retrievedUser = list.GetValue(index);
            Assert.AreEqual(user2, retrievedUser);
        }

        [Test]
        public void TestInsertAfter()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            list.InsertAfter(user1, user3);
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(user3, list.GetValue(1));
        }
    }
}
