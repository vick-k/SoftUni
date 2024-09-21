namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class RailwayStationTests
    {
        private RailwayStation railwayStation;

        [SetUp]
        public void Setup()
        {
            railwayStation = new("station");
        }

        [Test]
        public void Ctor_ValidData_ShouldInitialize()
        {
            Assert.That(railwayStation.Name, Is.EqualTo("station"));
            Assert.That(railwayStation.ArrivalTrains, Is.Not.Null);
            Assert.That(railwayStation.DepartureTrains, Is.Not.Null);
            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(0));
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(0));
        }

        [Test]
        public void Name_NullOrWhiteSpace_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new RailwayStation(null));
            Assert.Throws<ArgumentException>(() => new RailwayStation(" "));
        }

        [Test]
        public void NewArrivalOnBoard_ValidData_ShouldAddToQueue()
        {
            railwayStation.NewArrivalOnBoard("train");

            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(1));
            Assert.That(railwayStation.ArrivalTrains.Peek(), Is.EqualTo("train"));
        }

        [Test]
        public void TrainHasArrived_ValidData_OtherTrainToArrive()
        {
            railwayStation.NewArrivalOnBoard("train");

            Assert.That("There are other trains to arrive before noTrain.", Is.EqualTo(railwayStation.TrainHasArrived("noTrain")));
        }

        [Test]
        public void TrainHasArrived_CorrectTrain()
        {
            railwayStation.NewArrivalOnBoard("train");

            Assert.That("train is on the platform and will leave in 5 minutes.", Is.EqualTo(railwayStation.TrainHasArrived("train")));
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(1));
            Assert.That(railwayStation.DepartureTrains.Dequeue(), Is.EqualTo("train"));
            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(0));
        }

        [Test]
        public void TrainHasLeft_ValidData_RemoveDeparture()
        {
            railwayStation.NewArrivalOnBoard("train");
            railwayStation.TrainHasArrived("train");

            Assert.That(false, Is.EqualTo(railwayStation.TrainHasLeft("noTrain")));
            Assert.That(true, Is.EqualTo(railwayStation.TrainHasLeft("train")));
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(0));
        }
    }
}