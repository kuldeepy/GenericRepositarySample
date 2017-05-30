using BusinessEntities.User;
using System.Collections.Generic;

namespace BusinessServices.Interfaces
{
    /// <summary>
    /// User Services Contract
    /// </summary>
    public interface IUserServices
    {
        int Authenticate(string userName, string password);

        User GetUserByName(string name);
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
    }
}
