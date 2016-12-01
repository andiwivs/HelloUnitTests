using NUnit.Framework;
using System;

namespace MruListExercise
{
    class MruListTests
    {
        [Test]
        public void AddOneItem()
        {
            string item = "Test";
            MruList list = new MruList();

            list.Add(item);

            Assert.AreSame(list.Items[0], item);
        }

        [Test]
        public void AddTwoItems()
        {
            string item1 = "Test1";
            string item2 = "Test2";
            MruList list = new MruList();

            list.Add(item1);
            list.Add(item2);

            Assert.AreSame(list.Items[0], item2);
            Assert.AreSame(list.Items[1], item1);
        }

        [Test]
        public void AddDuplicate()
        {
            string item1 = "Test1";
            MruList list = new MruList();

            list.Add(item1);
            list.Add(item1);

            Assert.AreSame(list.Items[0], item1);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => { string test = list.Items[1]; });
            Assert.AreEqual(ex.ParamName, "index");
        }

        [Test]
        public void DuplicateHasMoved()
        {
            string item1 = "Test1";
            string item2 = "Test2";
            MruList list = new MruList();

            list.Add(item1);
            list.Add(item2);
            list.Add(item1);

            Assert.AreSame(list.Items[0], item1);
            Assert.AreSame(list.Items[1], item2);
        }

        [Test]
        public void AddNull()
        {
            MruList list = new MruList();

            var ex = Assert.Throws<ArgumentException>(() => { list.Add(null); });

            Assert.AreEqual(ex.ParamName, "item");
        }

        [Test]
        public void AddEmptyString()
        {
            MruList list = new MruList();

            var ex = Assert.Throws<ArgumentException>(() => { list.Add(String.Empty); });

            Assert.AreEqual(ex.ParamName, "item");
        }

        [Test]
        public void ExceedCapacity()
        {
            MruList list = new MruList(1);

            string item1 = "Item1";
            string item2 = "Item2";

            list.Add(item1);
            list.Add(item2);

            Assert.AreSame(list.Items[0], item2);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => { string test = list.Items[1]; });
            Assert.AreEqual(ex.ParamName, "index");
        }

        [Test]
        public void InvalidCapacity()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => { MruList list = new MruList(0); });
            Assert.AreEqual(ex.ParamName, "capacity");
        }
    }
}
