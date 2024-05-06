using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string username, string password);
    }
}
