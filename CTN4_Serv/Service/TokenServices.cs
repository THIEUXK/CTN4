using CTN4_Data.Models.DB_CTN4;
using CTN4_Ser.ViewModel;
using CTN4_Serv.Service.IService;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.DB_Context;

namespace CTN4_Serv.Service
{
	public class TokenServices : ITokenService
	{
		public DB_CTN4_ok _db;
		public TokenServices()
		{
			_db = new DB_CTN4_ok();
		}
		private const double EXPIRY_DURATION_MINUTES = 30;
		public string BuildToken(string key, string issuer, NhanVien user)
		{
			var Cv = _db.ChucVus.FirstOrDefault(p => p.Id == user.IdChucVu);
			if (Cv == null)
			{
				return "";
			}
			//thg này chưa cí chúc vụ trong sql vào fake đi 
			var claims = new[] {

				new Claim(ClaimTypes.Name, user.TenDangNhap),
				new Claim(ClaimTypes.Role, Cv.TenChucVu),
				new Claim(ClaimTypes.NameIdentifier, Cv.Id.ToString())
			};

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
			var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
				expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);
			return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
		}

		public string BuildTokens(string key, string issuer, KhachHang user)
		{
			var Cv = _db.KhachHangs.FirstOrDefault(p => p.Id == user.Id);
			if (Cv == null)
			{
				return "";
			}
				var claims = new[] {

				new Claim(ClaimTypes.Name, user.TenDangNhap),
				new Claim(ClaimTypes.Role, "Khach Hang"),
				new Claim(ClaimTypes.NameIdentifier, Cv.Id.ToString())
			};

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
			var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
				expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);
			return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
		}

		//public string GenerateJSONWebToken(string key, string issuer, UserDTO user)
		//{
		//    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
		//    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

		//    var token = new JwtSecurityToken(issuer, issuer,
		//      null,
		//      expires: DateTime.Now.AddMinutes(120),
		//      signingCredentials: credentials);

		//    return new JwtSecurityTokenHandler().WriteToken(token);
		//}
		public bool IsTokenValid(string key, string issuer, string token)
		{
			var mySecret = Encoding.UTF8.GetBytes(key);
			var mySecurityKey = new SymmetricSecurityKey(mySecret);

			var tokenHandler = new JwtSecurityTokenHandler();
			try
			{
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = issuer,
					ValidAudience = issuer,
					IssuerSigningKey = mySecurityKey,
				}, out SecurityToken validatedToken);
			}
			catch
			{
				return false;
			}
			return true;
		}
	}
}
