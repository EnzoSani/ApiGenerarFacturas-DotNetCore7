using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AutoMapper;
using Azure.Core;
using JwtWebApiDotNet7.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppGenerarFacturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public AuthController(ApplicationDBContext dbContext, IMapper mapper,
                               IAuthService authService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> Register(UserCredentials request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = _mapper.Map<User>(request);
            user.PasswordHash = passwordHash;

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            var userResponse = _mapper.Map<UserResponse>(user);

            return Ok(userResponse);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> Login(UserCredentials request)
        {

           var user = _dbContext.Users.FirstOrDefault(u=> u.Name == request.UserName 
                                                      && u.Password == request.Password);

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("User or Password is wrong");
            }

            if (user == null)
            {
                return BadRequest("User or Password is wrong");
            }
            if(!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("User or Password is wrong");
            }


            var userResponse = _mapper.Map<UserResponse>(user);

            string token = await _authService.CreateToken(userResponse);

            return Ok(token);
        }
    }
}
