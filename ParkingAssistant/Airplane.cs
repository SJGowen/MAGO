using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingAssistant
{
    public class Airplane
    {
        public string TailNumber { get; init; }
        public string Airline { get; init; }
        public PlaneSize PlaneSize { get; init; }
        public int GroundTimeEstimate { get; init; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }

        public Airplane(string tailNumber, string airline, PlaneSize planeSize, int groundTimeEstimate)
        {
            TailNumber = tailNumber;
            Airline = airline;
            PlaneSize = planeSize;
            GroundTimeEstimate = groundTimeEstimate;
        }
    }
}