using System.Security.Claims;

namespace GymLog.API.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserName
    {
        get
        {
            var name = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            if (string.IsNullOrEmpty(name))
                return name;

            var index = name.IndexOf('\\');
            return index >= 0 ? name[(index + 1)..] : name;
        }
    }
}
