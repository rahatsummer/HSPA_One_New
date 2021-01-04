using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IUserRepository
    {
         Task<User> AuthenticateUser(string userName, string password);
    }
}