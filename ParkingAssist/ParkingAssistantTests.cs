using System;
using Xunit;

namespace ParkingAssist
{
    public class ParkingAssistantTests
    {
        [Fact]
        public void ParkPropInEmptyAirportAllocatedStand00()
        {
            Stands stands = new Stands(25, 50, 25);
            Airplane airplane = new Airplane("TST-0001", "KLM", "Prop", 180);
            string stand = airplane.Park(stands);
            Assert.Equal("00", stand);
        }
    }
}
