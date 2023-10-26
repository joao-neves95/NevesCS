namespace NevesCS.NonStatic.ReferenceTypes
{
    public class Coordinates
    {
        public Coordinates(decimal longitude, decimal latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}
