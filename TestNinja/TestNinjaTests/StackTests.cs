using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinjaTests
{
    [TestClass]
    public class StackTests
    {
        private Stack<string> stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new Stack<string>();
        }

        [TestMethod]
        public void Push_WhenCalled_AddItemToStack()
        {
            stack.Push("item");

            Assert.IsTrue(stack.Count == 1);
        }
 
        [TestMethod]
        public void Push_NullItem_ThrowsArgurmentNullException()
        {
            string item = null;
            Assert.ThrowsException<ArgumentNullException>(() => stack.Push(item));
        }

        [TestMethod]
        public void Pop_WhenCalled_RemoveItemFromStack()
        {
            stack.Push("item0");
            stack.Push("item1");

            Assert.IsTrue(stack.Count == 2);
            Assert.IsTrue(stack.Pop().Equals("item1"));
            Assert.IsTrue(stack.Pop().Equals("item0"));
            Assert.IsTrue(stack.Count == 0);
        }

        [TestMethod]
        public void Pop_WhenStackIsEmpty_ThrowsInvalidOperationException()
        {
            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        public void Peek_WhenCalled_ReturnsTopOfStack()
        {
            stack.Push("item0");
            stack.Push("item1");

            Assert.IsTrue(stack.Count == 2);
            Assert.IsTrue(stack.Peek().Equals("item1"));
            Assert.IsTrue(stack.Count == 2);
        }

        public void Peek_WhenStackIsEmpty_ThrowsInvalidOperationException()
        {
            Assert.ThrowsException<InvalidOperationException>(() => stack.Peek());
        }
    }
}
