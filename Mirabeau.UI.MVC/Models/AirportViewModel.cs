using System.ComponentModel;

namespace Mirabeau.UI.MVC.Models
{
    public class AirportViewModel
    {
        [DisplayName("Continent")]
        public string Continent { get; private set; }

        [DisplayName("IATA")]
        public string IATA { get; private set; }

        [DisplayName("ISO")]
        public string ISO { get; private set; }

        [DisplayName("Latitude")]
        public double Latitude { get; private set; }

        [DisplayName("Longitude")]
        public double Longitude { get; private set; }

        [DisplayName("Name")]
        public string Name { get; private set; }

        [DisplayName("Size")]
        public string Size { get; private set; }

        [DisplayName("Status")]
        public int Status { get; private set; }

        [DisplayName("Type")]
        public string Type { get; private set; }
    }
}