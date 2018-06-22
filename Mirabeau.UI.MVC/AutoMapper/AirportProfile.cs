using AutoMapper;
using Mirabeau.Domain;
using Mirabeau.UI.MVC.Models;

namespace Mirabeau.UI.MVC.AutoMapper
{
    public class AirportProfile : Profile
    {
        public AirportProfile()
        {
            CreateMap<AirportViewModel, Airport>().ReverseMap();
        }
    }
}