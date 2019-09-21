using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Mocking;
using Moq;

namespace TestNinjaTests
{
    [TestClass]
    public class BookingHelperTests
    {
        private Booking _existingbooking;
        private Mock<IBookingRepository> mockBookRepository;

        [TestInitialize]
        public void Initialize()
        {
            mockBookRepository = new Mock<IBookingRepository>();

            _existingbooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),
                Reference = "a",
            };

            mockBookRepository.Setup(br => br.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _existingbooking,
            }.AsQueryable());
        }

        [TestMethod]
        public void OverlappingBookExists_BookingStartAndFinishesAfterExistingBook_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_existingbooking.ArrivalDate, 2),
                DepartureDate = Before(_existingbooking.ArrivalDate),
                Reference = "a",

            }, mockBookRepository.Object);

            Assert.IsTrue(result.Equals(string.Empty));
        }

        [TestMethod]
        public void OverlappingBookExists_BookingStarstBeforeAndFinishesInTheMiddleOfExistingBook_ReturnBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_existingbooking.ArrivalDate, 2),
                DepartureDate = After(_existingbooking.ArrivalDate),
                Reference = "a",

            }, mockBookRepository.Object);

            Assert.IsTrue(result.Equals(_existingbooking.Reference));
        }

        [TestMethod]
        public void OverlappingBookExists_BookingStarstBeforeAndFinishesAfterExistingBook_ReturnBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_existingbooking.ArrivalDate, 2),
                DepartureDate = After(_existingbooking.DepartureDate),
                Reference = "a",

            }, mockBookRepository.Object);

            Assert.IsTrue(result.Equals(_existingbooking.Reference));
        }

        [TestMethod]
        public void OverlappingBookExists_BookingStarstAndFinishesInTheMiddleOfExistingBook_ReturnBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_existingbooking.ArrivalDate),
                DepartureDate = Before(_existingbooking.DepartureDate),
                Reference = "a",

            }, mockBookRepository.Object);

            Assert.IsTrue(result.Equals(_existingbooking.Reference));
        }

        [TestMethod]
        public void OverlappingBookExists_BookingStarstInTheMiddleAndFinishesAfterExistingBook_ReturnBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_existingbooking.ArrivalDate),
                DepartureDate = After(_existingbooking.DepartureDate),
                Reference = "a",

            }, mockBookRepository.Object);

            Assert.IsTrue(result.Equals(_existingbooking.Reference));
        }

        [TestMethod]
        public void OverlappingBookExists_BookingStarstAndFinishesAfterExistingBook_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_existingbooking.DepartureDate),
                DepartureDate = After(_existingbooking.DepartureDate),
                Reference = "a",

            }, mockBookRepository.Object);

            Assert.IsTrue(result.Equals(string.Empty));
        }

        [TestMethod]
        public void OverlappingBookExists_BookingOverlapsButNewBookingIsCancelled_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_existingbooking.DepartureDate),
                DepartureDate = After(_existingbooking.DepartureDate),
                Reference = "a",
                Status = "Cancelled",

            }, mockBookRepository.Object);

            Assert.IsTrue(result.Equals(string.Empty));
        }

        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime After(DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}
