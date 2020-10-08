using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();
          var result = controller.GetCustomer(0);
          Assert.That(result, Is.TypeOf<NotFound>());

          //Notfound object or one of its deriatives
          Assert.That(result, Is.InstanceOf<NotFound>());
        }
    }
}
