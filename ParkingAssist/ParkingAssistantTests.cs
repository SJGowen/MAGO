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
    }
}

