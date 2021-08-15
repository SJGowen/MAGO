using System;
using System.Runtime.Serialization;

namespace ParkingAssistant
{
    [Serializable]
    public class AirplaneNotFoundException : Exception
    {
        public AirplaneNotFoundException()
        {
        }

        public AirplaneNotFoundException(string message) : base(message)
        {
        }

        public AirplaneNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AirplaneNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}