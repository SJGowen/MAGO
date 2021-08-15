using System;
using System.Runtime.Serialization;

namespace ParkingAssistant
{
    [Serializable]
    public class AircraftNotFoundException : Exception
    {
        public AircraftNotFoundException()
        {
        }

        public AircraftNotFoundException(string message) : base(message)
        {
        }

        public AircraftNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AircraftNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}