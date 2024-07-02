namespace NevesCS.NonStatic.Models.ValueTypes
{
    public struct CoordinatesValue
    {
        public CoordinatesValue()
        {
        }

        public CoordinatesValue(decimal longitude, decimal latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}
