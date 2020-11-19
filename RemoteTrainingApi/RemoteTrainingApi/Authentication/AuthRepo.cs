using CryptoHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RemoteTrainingApi.Users.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTrainingApi.Authentication
{
    public class AuthRepo : IAuthRepo
    {
        private readonly Token _token;
        private readonly RTADbContext _db;

        public AuthRepo(IOptions<Token> token, RTADbContext db)
        {
            _token = token.Value;
            _db = db;
        }

        public async Task<Tuple<bool, string>> Login(LoginModel loginModel)
        {
            string token = string.Empty;

            if (!await IsValidUser(loginModel.Email, loginModel.Password)) return new Tuple<bool, string>(false, token);

            var user = await _db.User.Where(o => o.Email == loginModel.Email).SingleOrDefaultAsync();
            if (user == null) return new Tuple<bool, string>(false, token);

            var claim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, loginModel.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_token.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _token.Issuer,
                _token.Audience,
                claim,
                expires: DateTime.Now.AddDays(_token.AccessExpiration),
                signingCredentials: credentials
            );
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return new Tuple<bool, string>(true, token);

        }

        public async Task<bool> Register(RegisterModel userRegistrationModel)
        {
            if (await UserExists(userRegistrationModel.Email)) return false;

            if (userRegistrationModel != null && !string.IsNullOrWhiteSpace(userRegistrationModel.Email) && !string.IsNullOrWhiteSpace(userRegistrationModel.Password))
            {


                try
                {
                    await _db.SaveChangesAsync();

                    await _db.User.AddAsync(new User()
                    {
                        FirstName = userRegistrationModel.FirstName,
                        LastName = userRegistrationModel.LastName,
                        Email = userRegistrationModel.Email,
                        Password = Crypto.HashPassword(userRegistrationModel.Password),
                    });

                    await _db.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            return false;
        }

        public async Task<bool> UserExists(string username = null, int? up_id = null)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                return await _db.User.Where(o => o.Email == username).AnyAsync();
            }

            return up_id != null ? await _db.User.Where(o => o.UserId == up_id).AnyAsync() : false;
        }

        public async Task<bool> IsValidUser(string email, string password)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                var user = await _db.User.Where(o => o.Email == email).SingleOrDefaultAsync();

                if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }

    public interface IAuthRepo
    {
        Task<Tuple<bool, string>> Login(LoginModel loginModel);
        Task<bool> Register(RegisterModel registrationModel);
    }
}
