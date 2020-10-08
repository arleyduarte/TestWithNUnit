
using NuGet.Frameworks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests



    {

        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
            
        }
        [Test]
        public void GetOddNumbers_LimitIsGraterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Is.EquivalentTo(new []{1,2,5}));

            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
