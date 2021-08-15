using ParkingAssistant;
using System;
using Xunit;


namespace ParkingAssist
{
    public class ParkingAssistantTests
    {
        [Fact]
        public void ParkPropInEmptyAirportAllocatedStand0()
        {
            AircraftStands stands = new(25, 50, 25);
            Airplane airplane = new("TST-0001", "KLM", PlaneSize.Prop, 180);
            int stand = stands.Arrival(airplane, DateTime.Now);
            Assert.Equal(0, stand);
        }

        [Fact]
        public void ParkJetInEmptyAirportAllocatedStand25()
        {
            AircraftStands stands = new(25, 50, 25);
            Airplane airplane = new("TST-0002", "RYA", PlaneSize.Jet, 180);
            int stand = stands.Arrival(airplane, DateTime.Now);
            Assert.Equal(25, stand);
        }

        [Fact]
        public void ParkJumboInEmptyAirportAllocatedStand75()
        {
            AircraftStands stands = new(25, 50, 25);
            Airplane airplane = new("TST-0003", "BAW", PlaneSize.Jumbo, 210);
            int stand = stands.Arrival(airplane, DateTime.Now);
            Assert.Equal(75, stand);
        }

        [Fact]
        public void Park26PropInEmptyAirportAllocatedStand0to26()
        {
            AircraftStands stands = new(25, 50, 25);
            for (int i = 1; i <= 26; i++)
            {
                Airplane airplane = new($"TST-{i:D4}", "KLM", PlaneSize.Prop, 180);
                int stand = stands.Arrival(airplane, DateTime.Now);
                Assert.Equal(i - 1, stand);
            }

            Assert.Equal(0, stands.Empty(PlaneSize.Prop));
            Assert.Equal(49, stands.Empty(PlaneSize.Jet));
            Assert.Equal(74, stands.Empty());
        }

        [Fact]
        public void Park51JetsInEmptyAirportAllocatedStand26to76()
        {
            AircraftStands stands = new(25, 50, 25);
            for (int i = 26; i <= 76; i++)
            {
                Airplane airplane = new($"TST-{i:D4}", "RYA", PlaneSize.Jet, 180);
                int stand = stands.Arrival(airplane, DateTime.Now);
                Assert.Equal(i - 1, stand);
            }

            Assert.Equal(25, stands.Empty(PlaneSize.Prop));
            Assert.Equal(0, stands.Empty(PlaneSize.Jet));
            Assert.Equal(24, stands.Empty(PlaneSize.Jumbo));
            Assert.Equal(49, stands.Empty());
        }

        [Fact]
        public void Park26JumboInEmptyAirportAllocatedStand75to99AndThrowsAnException()
        {
            AircraftStands stands = new(25, 50, 25);
            for (int i = 76; i <= 100; i++)
            {
                Airplane airplane = new($"TST-{i:D4}", "BAW", PlaneSize.Jumbo, 210);
                int stand = stands.Arrival(airplane, DateTime.Now);
                Assert.Equal(i - 1, stand);
            }

            Assert.Equal(0, stands.Empty(PlaneSize.Jumbo));
            Assert.Equal(75, stands.Empty());

            Airplane error = new("TST-0100", "BAW", PlaneSize.Jumbo, 210);
            var exception = Assert.Throws<StandSpaceException>(() => stands.Arrival(error, DateTime.Now));
            Assert.Equal("The Airport has no more allocated space for Jumbo Aircraft", exception.Message);
        }

        [Fact]
        public void ArrivalTheDepartureOfPlaneLeavesAirportEmpty()
        {
            AircraftStands stands = new(25, 50, 25);
            Airplane airplane = new("TST-0001", "KLM", PlaneSize.Prop, 180);
            int stand = stands.Arrival(airplane, DateTime.Now);
            Assert.Equal(0, stand);
            stands.Departure(airplane, DateTime.Now);
            Assert.Equal(100, stands.Empty());
        }

        [Fact]
        public void ArrivalTheDepartureOfPlaneTwiceThrowsAnException()
        {
            AircraftStands stands = new(25, 50, 25);
            Airplane airplane = new("TST-0001", "KLM", PlaneSize.Prop, 180);
            int stand = stands.Arrival(airplane, DateTime.Now);
            Assert.Equal(0, stand);
            stands.Departure(airplane, DateTime.Now);
            Assert.Equal(100, stands.Empty());

            var exception = Assert.Throws<AircraftNotFoundException>(() => stands.Departure(airplane, DateTime.Now));
            Assert.Equal("The Aircraft with Tail Number 'TST-0001' can not be found", exception.Message);
        }

        [Fact]
        public void RecommendStandInEmptyAirportForJetRecommends25()
        {
            AircraftStands stands = new(25, 50, 25);
            Airplane airplane = new($"TST-0002", "RYA", PlaneSize.Jet, 180);
            int recommendedStand = stands.RecommendParkingStand(airplane);
            Assert.Equal(25, recommendedStand);
        }

        [Fact]
        public void ParkJetInStand50OfEmptyAirportSucceedsWithJetAllocated50()
        {
            AircraftStands stands = new(25, 50, 25);
            Airplane airplane = new($"TST-0002", "RYA", PlaneSize.Jet, 180);
            int standNumber = stands.Arrival(airplane, DateTime.Now, 50);
            Assert.Equal(50, standNumber);
        }

        [Fact]
        public void TryToParkTwoJetsInStand50OfAirportThrowsAnException()
        {
            AircraftStands stands = new(25, 50, 25);
            Airplane airplane2 = new($"TST-0002", "RYA", PlaneSize.Jet, 180);
            int standNumber = stands.Arrival(airplane2, DateTime.Now, 50);
            Assert.Equal(50, standNumber);


            Airplane airplane3 = new($"TST-0003", "RYA", PlaneSize.Jet, 180);
            var exception = Assert.Throws<StandSpaceException>(() => stands.Arrival(airplane3, DateTime.Now, 50));
            Assert.Equal("Stand 50 is occupied by Aircraft with Tail Number 'TST-0002'", exception.Message);
        }

        [Fact]
        public void TryToParkJetInStand0OfEmptyAirportThrowsAnException()
        {
            AircraftStands stands = new(25, 50, 25);
            Airplane airplane = new($"TST-0002", "RYA", PlaneSize.Jet, 180);

            var exception = Assert.Throws<StandSpaceException>(() => stands.Arrival(airplane, DateTime.Now, 0));
            Assert.Equal("Stand 0 is too small for a Jet Aircraft", exception.Message);
        }
    }
}

