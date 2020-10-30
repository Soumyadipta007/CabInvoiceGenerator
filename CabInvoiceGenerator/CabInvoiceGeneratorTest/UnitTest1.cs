using NUnit.Framework;
using CabInvoiceGenerator;
namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void GivenDistanceAndTimeReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator();
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }
        [Test]
        public void GivenMultipleRideReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator();
            Ride[] rides = { new Ride(2.0, 5), new Ride(2.0, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 50.0);
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenUserIdReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator();
            Ride[] rides = { new Ride(2.0, 5), new Ride(2.0, 5) };
            RideRepository rideRepo = invoiceGenerator.rideRepository;
            rideRepo.AddRide("100", rides);
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("100");            
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 50.0);
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenNormalDistanceAndTimeShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }
        [Test]
        public void GivenPremiumDistanceAndTimeShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 40;
            Assert.AreEqual(expected, fare);
        }
        [Test]
        public void GivenNormalMultipleRideShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(2.0, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 50.0);
            Assert.AreEqual(expectedSummary, summary);
        }
    }
}