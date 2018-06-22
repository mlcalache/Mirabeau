namespace Mirabeau.Domain
{
    public class Airport
    {
        // Variables are not following code specifications because it represents exactly the model from JSON

        public string continent { get; private set; }
        public string iata { get; private set; }
        public string iso { get; private set; }
        public double lat { get; private set; }
        public double lon { get; private set; }
        public string name { get; private set; }
        public string size { get; private set; }
        public int status { get; private set; }
        public string type { get; private set; }

        public static class AirportFactory
        {
            public static Airport Create(string continent, string IATA, string ISO, double lat, double lon, string name, string size, int status, string type)
            {
                return new Airport
                {
                    continent = continent,
                    iata = IATA,
                    iso = ISO,
                    lat = lat,
                    lon = lon,
                    name = name,
                    size = size,
                    status = status,
                    type = type
                };
            }
        }
    }
}