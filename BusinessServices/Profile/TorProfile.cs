using BusinessEntities.User;
using DAL;

namespace BusinessServices.Profile
{
    public class TorProfile : AutoMapper.Profile
    {
        public TorProfile()
        {
            CreateMap<TorUser, User>();
        }
    }
}