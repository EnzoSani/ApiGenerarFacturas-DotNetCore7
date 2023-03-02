using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.Helpers;
using AppGenerarFacturas.Models;
using AppGenerarFacturas.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppGenerarFacturas.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {   
        private readonly IUserService _userService;
        private readonly ApplicationDBContext _dbContext;
        private readonly JwtSettings _jwtSettings;
        public AccountController(ApplicationDBContext dbContext, JwtSettings jwtSettings, IUserService userService)
        {
            _dbContext = dbContext;
            _jwtSettings = jwtSettings;
            _userService = userService;
        }


        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins)
        {
            try
            {
                var Token = new UserTokens();
                var Valid = _dbContext.Users.Any(user => user.Name.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));

                if (Valid)
                {
                    var User = _dbContext.Users.FirstOrDefault(user => user.Name.Equals(userLogins.UserName,StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GetTokenKey(new UserTokens()
                    {
                        UserName = User.Name,
                        EmailId = User.Email,
                        Id = User.Id,
                        GuidId = Guid.NewGuid(),

                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Password");
                }
                return Ok(Token);
            }
            catch (Exception Ex)
            {

                throw new Exception("Get Token Error", Ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]

        public IActionResult GetUserList()
        {
            var userList = _userService.GetUserList();
            return Ok(userList);
        }
    }
}
