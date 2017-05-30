using BusinessServices.Interfaces;
using System.Collections.Generic;
using BusinessEntities.User;
using DAL.UnitOfWork;
using System.Linq;
using AutoMapper;
using DAL;
using BusinessServices.Profile;
using BusinessServices.Helper;

namespace BusinessServices.Implementation
{
    /// <summary>
    /// Offers service for the user specific CRUD operations
    /// </summary>
    public class UserServices : IUserServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor
        /// </summary>
        public UserServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Authenticate(string userName, string password)
        {
            var user = _unitOfWork.UserRepository.Get(w => w.LoginName == userName && w.Type == "External");
            if (user != null && user.TorUserID > 0)
            {
                SaltedHash hash = SaltedHash.Create(user.PasswordSalt, user.PasswordHash);
                if (hash.Verify(password))
                {
                    return user.TorUserID;
                }
                return 0;
            }

            return 0;
        }

        /// <summary>
        /// Fetches all users.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers()
        {
            var users = _unitOfWork.UserRepository.GetAll().ToList();
            if (users.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TorUser, User>();
                    cfg.AddProfile<TorProfile>();
                });
                var mapper = config.CreateMapper();
                //Mapper.CreateMap<TorUser, User>();
                var usersModel = mapper.Map<List<TorUser>, List<User>>(users);
                return usersModel;
            }
            return null;
        }


        public User GetUserById(int id)
        {
            var user = _unitOfWork.UserRepository.GetByID(id);
            if (user != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TorUser, User>();
                    cfg.AddProfile<TorProfile>();
                });
                var mapper = config.CreateMapper();
                var usersModel = mapper.Map<TorUser, User>(user);
                return usersModel;
            }

            return null;
        }

        public User GetUserByName(string name)
        {
            var user = _unitOfWork.UserRepository.Get(w => w.LoginName == name && w.Type == "External");
            if (user != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TorUser, User>();
                    cfg.AddProfile<TorProfile>();
                });
                var mapper = config.CreateMapper();
                var usersModel = mapper.Map<TorUser, User>(user);
                return usersModel;
            }

            return null;
        }
    }
}
