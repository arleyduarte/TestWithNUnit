using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
   public class HtmlFormatterTest
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseToString()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));
        }
    }
}
