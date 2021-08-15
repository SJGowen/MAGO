using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingAssistant
{
    public class AircraftStands
    {
        public List<Stand> Stands { get; set; } = new();

        public AircraftStands(int props, int jets, int jumbos)
        {
            for (int standNumber = 0; standNumber < props; standNumber++)
            {
                Stands.Add(new Stand(standNumber, PlaneSize.Prop, string.Empty));
            }

            for (int standNumber = props; standNumber < props + jets; standNumber++)
            {
                Stands.Add(new Stand(standNumber, PlaneSize.Jet, string.Empty));
            }

            for (int standNumber = props + jets; standNumber < props + jets + jumbos; standNumber++)
            {
                Stands.Add(new Stand(standNumber, PlaneSize.Jumbo, string.Empty));
            }
        }

        public int Arrival(Airplane airplane, DateTime arrival)
        {
            Stand stand = Stands.First(a => a.PlaneSize >= airplane.PlaneSize && a.TailNumber == string.Empty);
            stand.TailNumber = airplane.TailNumber;
            airplane.ArrivalDateTime = arrival;
            return stand.StandNumber;
        }
    }
}