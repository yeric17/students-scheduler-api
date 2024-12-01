


using Microsoft.AspNetCore.Http;
using StudentScheduler.infrastructure.Abstractions;

namespace StudentScheduler.infrastructure.Auth
{
    internal class ClaimsHelper : IClaimsHelper
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string? GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;

            return userId;
        }

        public List<string>? GetRoles()
        {
            var roles = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "role").Select(x => x.Value).ToList();
            return roles;
        }
    }
}
