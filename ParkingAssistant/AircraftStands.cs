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

        public int RecommendParkingStand(Airplane airplane)
        {
            try
            {
                Stand stand = Stands.First(a => a.PlaneSize >= airplane.PlaneSize && a.TailNumber == string.Empty);
                return stand.StandNumber;
            }
            catch (InvalidOperationException e)
            {
                if (e.Message == "Sequence contains no matching element")
                {
                    throw new StandSpaceException($"The Airport has no more allocated space for {airplane.PlaneSize} Aircraft");
                }

                throw;
            }
        }

        public int Arrival(Airplane airplane, DateTime arrival, int standNumber = -1)
        {
            try
            {
                Stand stand;
                if (standNumber == -1)
                {
                    stand = Stands.First(s => s.PlaneSize >= airplane.PlaneSize && s.TailNumber == string.Empty);
                }
                else
                {
                    stand = Stands.First(s => s.StandNumber == standNumber && s.PlaneSize >= airplane.PlaneSize && s.TailNumber == string.Empty);
                }
                stand.TailNumber = airplane.TailNumber;
                airplane.ArrivalDateTime = arrival;
                return stand.StandNumber;
            }
            catch (InvalidOperationException e)
            {
                if (e.Message == "Sequence contains no matching element")
                {
                    if (standNumber == -1 || Empty(airplane.PlaneSize) == 0)
                    {
                        throw new StandSpaceException($"The Airport has no more allocated space for {airplane.PlaneSize} Aircraft");
                    }
                    else
                    {
                        if (Stands[standNumber].TailNumber != "")
                        {
                            throw new StandSpaceException($"Stand {standNumber} is occupied by Aircraft with Tail Number '{Stands[standNumber].TailNumber}'");
                        }
                        else 
                        {
                            throw new StandSpaceException($"Stand {standNumber} is too small for a {airplane.PlaneSize} Aircraft");
                        }
                    }
                    
                }

                throw;
            }
        }

        public int Empty()
        {
            return Stands.Count(a => a.TailNumber == string.Empty);
        }

        public int Empty(PlaneSize size)
        {
            return Stands.Count(a => a.PlaneSize == size && a.TailNumber == string.Empty);
        }

        public void Departure(Airplane airplane, DateTime departure)
        {
            try
            {
                Stand stand = Stands.First(a => a.TailNumber == airplane.TailNumber);
                stand.TailNumber = string.Empty;
                airplane.DepartureDateTime = departure;
            }
            catch (InvalidOperationException e)
            {
                if (e.Message == "Sequence contains no matching element")
                {

                    throw new AircraftNotFoundException($"The Aircraft with Tail Number '{airplane.TailNumber}' can not be found");
                }

                throw;
            }
        }
    }
}