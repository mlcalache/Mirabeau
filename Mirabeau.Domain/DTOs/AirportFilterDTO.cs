using Mirabeau.Domain.Enums;

namespace Mirabeau.Domain.DTOs
{
    public class AirportFilterDTO
    {
        public string IATA { get; set; }
        public string ISO { get; set; }
        public string Name { get; set; }
        public SizeEnum? Size { get; set; }
        public TypeEnum? Type { get; set; }
    }
}