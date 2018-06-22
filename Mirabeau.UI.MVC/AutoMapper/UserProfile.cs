using AutoMapper;
using Mirabeau.Domain.Entities;
using Mirabeau.UI.MVC.Models;

namespace Mirabeau.UI.MVC.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginViewModel, User>().ReverseMap();
        }
    }
}