using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.Service
{
	public class CurrentUser:ICurrentUser
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CurrentUser(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}
        public List<string> RoleCodes => GetRoleClaim(ClaimTypes.Role) ?? new List<string>();
        string ICurrentUser.Name => GetClaimValue<string>(ClaimTypes.Name) ?? string.Empty;
        string ICurrentUser.Email => GetClaimValue<string>(ClaimTypes.Email) ?? string.Empty;
        Guid ICurrentUser.Id => Guid.Parse(GetClaimValue<string>(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());
        string ICurrentUser.UserName => GetClaimValue<string>("UserName") ?? string.Empty;

        private List<string> GetRoleClaim(string claimType)
		{
			var claim = _httpContextAccessor.HttpContext.User.FindAll(claimType);
			if (claim == null)
			{
				return default;
			}
			var claims = new List<string>();
			foreach (var claimValue in claim)
			{
				claims.Add(claimValue.Value);
			}
			return claims;
		}
		private T GetClaimValue<T>(string claimType)
		{
			var claim = _httpContextAccessor.HttpContext.User.FindFirst(claimType);
			if (claim == null)
			{
				return default;
			}

			return (T)Convert.ChangeType(claim.Value, typeof(T));
		}
	}
}
