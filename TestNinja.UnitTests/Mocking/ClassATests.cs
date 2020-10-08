using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Moq;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public  class ClassATests
    {

        [Test]
        public void MethodA_IsCalledMethodB()
        {

            var classB = new Mock<IClassB>();

            classB.Setup(cb => cb.MethodB("A"));


            //Act
            var classA  = new ClassA(classB.Object);
            classA.MethodA("A");


            classB.Verify(cb => cb.MethodB("X"));

        }



        [Test]
        public void MethodA_ParamIsNull_NoCallMethodB()
        {

            var classB = new Mock<IClassB>();

            classB.Setup(cb => cb.MethodB("A"));


            //Act
            var classA = new ClassA(classB.Object);
            classA.MethodA(null);


            classB.Verify(cb => cb.MethodB("X"), Times.Never);

        }
    }
}
