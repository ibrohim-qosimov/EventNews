using EventNews.API.Abstractions;
using EventNews.API.DTOs;
using EventNews.API.Models.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventNews.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailSender _emailSender;
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;
        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IEmailSender emailSender, IMemoryCache memoryCache, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _emailSender = emailSender;
            _memoryCache = memoryCache;
            _configuration = configuration;
        }

        public async Task<BaseResponse> Register(RegisterDTO dto)
        {
            var isEmailExist = await _userRepository.GetUsers(x => x.Email == dto.Email);

            if (isEmailExist.Any())
            {
                return new BaseResponse()
                {
                    IsSuccess = false,
                    Error = "Already registered"
                };
            }

            var salt = Guid.NewGuid().ToString();
            var hashedPassword = _passwordHasher.Encrypt(dto.Password, salt);

            var newUser = new User()
            {
                Email = dto.Email,
                Password = hashedPassword,
                Salt = salt,
            };

            await _userRepository.Add(newUser);

            return new BaseResponse()
            {
                IsSuccess = true,
                Error = ""
            };
        }

        public async Task<BaseResponse> Login(LoginDTO dto)
        {
            var isEmailExist = await _userRepository.GetUsers(x => x.Email == dto.Email);

            if (!isEmailExist.Any())
            {
                return new BaseResponse()
                {
                    IsSuccess = false,
                    Error = "User not found"
                };
            }

            var user = isEmailExist.First();

            var isPasswordMatch = _passwordHasher.Verify(user.Password, dto.Password, user.Salt);

            if (isPasswordMatch == false)
            {
                return new BaseResponse()
                {
                    IsSuccess = false,
                    Error = "Password is incorrect"
                };
            }

            var random = new Random();

            var otpMessage = random.Next(100000, 999999);
            var isOtpSent = await _emailSender.SendMessageAsync(user.Email, otpMessage);

            if (isOtpSent.IsSuccess == false)
            {

                _memoryCache.Set(user.Email, otpMessage, DateTimeOffset.FromUnixTimeSeconds(120));

                return new BaseResponse()
                {
                    IsSuccess = false,
                    Error = "Failes while sending one time password"
                };
            }

            return new BaseResponse() { IsSuccess = true };
        }

        public async Task<TokenResponse> VerifyOtp(string email, int otp)
        {
            var exist = await _userRepository.GetUsers(x => x.Email == email);
            if (!exist.Any())
                throw new NotImplementedException();

            var user  = exist.FirstOrDefault();
            var otpMessage = _memoryCache.Get(email).ToString();

            if (otpMessage != otp.ToString())
            {
                return null;
            }

            string token = await GenerateJWT(user);

            return new TokenResponse()
            {
                Token = token,
            };
        }

        private async Task<string> GenerateJWT(User user)
        {
            if (user == null)
                return "null";

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Key"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_configuration["JWTSettings:Expire"]!);

            var role = (int)user.Role;
            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                new Claim("email", user.Email),
                new Claim("Role", role.ToString()),
                new Claim("UserId", user.Id.ToString()),
            };



            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JWTSettings:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: credentials);

            var responseToken = new JwtSecurityTokenHandler().WriteToken(token);

            return responseToken;
        }
    }
}