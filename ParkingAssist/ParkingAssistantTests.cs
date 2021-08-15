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
            int stand = stands.Park(airplane, DateTime.Now);
            Assert.Equal(0, stand);
        }

        [Fact]
        public void ParkJetInEmptyAirportAllocatedStand25()
        {
            AircraftStands stands = new(25, 50, 25);
            Airplane airplane = new("TST-0002", "RYA", PlaneSize.Jet, 180);
            int stand = stands.Park(airplane, DateTime.Now);
            Assert.Equal(25, stand);
        }
    }
}

