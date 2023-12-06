using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using RhommieBank.Services.MasterAPI.Data;
using RhommieBank.Services.MasterAPI.Models.Dto;
using RhommieBank.Services.MasterAPI.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace RhommieBank.Services.MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAPIController : ControllerBase
    {

        private readonly RhommieBankDbContext _db;
        private ResponseDto _res;
        private IMapper _mapper;
        private readonly IConfiguration _config;
        public LoginAPIController(RhommieBankDbContext db, IMapper mapper, IConfiguration config)
        {
            _db = db;
            _mapper = mapper;
            _res = new ResponseDto();
            _config = config;
        }
        [HttpPost]
        public ResponseDto Login(UserLoginViewModel user)
        {

            var uvm = new UserViewModel();

            if(user != null)
            {
                var getUser = _db.UserLogins.Where(x => x.username == user.username).FirstOrDefault();
                if(getUser == null)
                {
                    _res.IsSuccess = false;
                    _res.Message = "Invalid Username";
                }
                else
                {
                    if(getUser.password != user.password)
                    {
                        _res.IsSuccess = false;
                        _res.Message = "Invalid Password";
                    }
                    else
                    {
                        _res.IsSuccess = true;
                        

                        uvm.username = getUser.username;
                        uvm.password = getUser.password;
                        uvm.email = getUser.email;
                        uvm.nickname = getUser.nickname;
                        uvm.isAdmin = getUser.isAdmin;
                        uvm.imagePath = getUser.imagePath;
                        uvm.Token = GetToken(uvm);

                        var principal = ValidateToken(uvm.Token);

                        _res.Result = uvm;
                        _res.Message = "Login successful";
                    }
                }
            }

            return _res;
        }

        private ClaimsPrincipal ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]))
                };

                // Validasi token
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out _);

                return principal;
            }
            catch (Exception ex)
            {
                // Tangani kesalahan validasi token
                // Log ex.Message atau lakukan penanganan kesalahan sesuai kebutuhan
                return null;
            }
        }

        string GetToken(UserViewModel user)
        {
            var claims = new[] { 
                new Claim(JwtRegisteredClaimNames.Sub,_config["jwt:Subject"] ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString()),
                new Claim("UserName",user.username ?? ""),
                new Claim("Password",user.password ?? ""),
                new Claim("Email",user.email ?? ""),
                new Claim("NickName",user.nickname ?? ""),
                new Claim("IsAdmin",user.isAdmin.ToString()),
                new Claim("ImagePath",user.imagePath ?? ""),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? ""));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signIn);

            string Token = new JwtSecurityTokenHandler().WriteToken(token);

            return Token;
        }
    }
}
