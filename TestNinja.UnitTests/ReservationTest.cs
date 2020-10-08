using System.Security;

using NUnit.Framework;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTest
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnTrue()
        {
            //Arrange
            var reservation = new Reservation();
            var result = reservation.CanBeCancelledBy(new User {IsAdmin = true});
            //Act
            Assert.IsTrue(result);
        }


        [Test]
        public void CanBeCancelledBy_SameUserCancellingReservation_ReturnTrue()
        {
            var user = new User();
            //Arrange
            var reservation = new Reservation{MadeBy = user};

            //Act
            var result = reservation.CanBeCancelledBy(user);

            Assert.That(result, Is.True);
        }


        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnFalse()
        {
            //Arrange 
            var user = new User();
            //Arrange
            var reservation = new Reservation { MadeBy = user };

            //Act
            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
            //Act

        }
    }
}
