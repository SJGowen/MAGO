using System;
using System.Runtime.Serialization;

namespace ParkingAssistant
{
    [Serializable]
    public class StandSpaceException : Exception
    {
        public StandSpaceException()
        {
        }

        public StandSpaceException(string message) : base(message)
        {
        }

        public StandSpaceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StandSpaceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}