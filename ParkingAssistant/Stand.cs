namespace ParkingAssistant
{
    public class Stand
    {
        public int StandNumber { get; }
        public PlaneSize PlaneSize { get; }
        public string TailNumber { get; set; }

        public Stand(int standNumber, PlaneSize planeSize, string tailNumber)
        {
            StandNumber = standNumber;
            PlaneSize = planeSize;
            TailNumber = tailNumber;
        }
    }
}