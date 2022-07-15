using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Faculty_Information_System_Application.Repositories
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration iconfiguration;
        private readonly FacultyInformationSystemContext _db;
        public JWTManagerRepository(IConfiguration iconfiguration, FacultyInformationSystemContext context)
        {
            this.iconfiguration = iconfiguration;
            this._db = context;
        }
        public MyJwtToken Authenticate(string username, string password, int roleLookupId)
        {

            var u = _db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password && u.RoleLookupId == roleLookupId);
            if (u == null)
                return null;

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, u.UserName),
                    new Claim(ClaimTypes.Role, u.RoleLookupId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new MyJwtToken { Token = tokenHandler.WriteToken(token) };
        }
    }
}
