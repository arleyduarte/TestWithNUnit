using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {

        private DemeritPointsCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new DemeritPointsCalculator();
        }
        [Test]
        [TestCase(0,0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCall_ReturnDemeritPoints(int speed, int expectedResult)
        {
            var result = calculator.CalculateDemeritPoints(speed);


            Assert.That(result, Is.EqualTo(expectedResult));


        }

        [Test]
        public void CalculateDemeritPoints_Speeding_ReturnPoints()
        {
            var result = calculator.CalculateDemeritPoints(65 + 15);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-1)]
        public void CalculateDemeritPoints_SpeedIsNegative_ThrowArgumentOutOfRangeException(int speed)
        {


            Assert.That(() => calculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

        }
    }
}
