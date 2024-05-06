using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models; 

namespace BLL.Interfaces
{
    public interface IUser
    {
        List<User> GetUsers();
        int Add(User model);
        Task<User> GetUserByUsernameAndPasswordAsync(string username, string password);

    }
}
