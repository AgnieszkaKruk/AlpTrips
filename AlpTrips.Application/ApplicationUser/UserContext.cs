using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AlpTrips.Application.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser GetCurrentUser();
    }

    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public CurrentUser GetCurrentUser()
        {
            var user = _httpContextAccessor?.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("context user is not present ");
            }

            var userId = user.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)!.Value;
            var userEmail = user.FindFirst(u => u.Type == ClaimTypes.Email)!.Value;
            var userName = user.FindFirst(ClaimTypes.Name)!.Value;

            return new CurrentUser(userId, userEmail, userName);
        }
    }
}
