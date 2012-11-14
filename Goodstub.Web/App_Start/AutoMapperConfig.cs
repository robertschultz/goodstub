using AutoMapper;
using Goodstub.Domain;
using Goodstub.Web;
using Goodstub.Web.Models;

namespace Goodstub.Web
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });
        }
    }

    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<SignUpModel, IUser>();
        }
    }
}