
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ArgIsNull_ThrowArgNullException()
        {
            var stack = new Stack<string>();

            Assert.That(()=> stack.Push(null), Throws.ArgumentNullException);
        }


        [Test]
        public void Push_ValidArg_AddObject()
        {
            var stack = new Stack<string>();

            stack.Push("a");

            Assert.That(stack.Count, Is.EqualTo(1));
        }


        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();



            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }



        [Test]
        public void Pop_WithObjectsStack_ReturnObject()
        {
            var stack = new Stack<string>();

            stack.Push("a");
            stack.Push("b");
            stack.Push("c");




            Assert.That(stack.Pop(), Is.EqualTo("c"));

            Assert.That(stack.Pop(), Is.EqualTo("b"));
        }

        [Test]
        public void Peek_WithObjectsStack_ReturnObject()
        {
            var stack = new Stack<string>();

            stack.Push("a");
            stack.Push("b");
            stack.Push("c");




            Assert.That(stack.Peek(), Is.EqualTo("c"));

            Assert.That(stack.Peek(), Is.EqualTo("c"));
        }
    }
}
