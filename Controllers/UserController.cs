using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using BusSystem.API.Model;
using BusSystem.API.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using using Microsoft.AspNetCore.Mvc.Versioning;

namespace BusSystem.API.Controllers
{
   // [Route("api/[controller]")]
    //[ApiController]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v.apiVersion}/sample")]
    public class UserController : ControllerBase
    {
        private UserServices _userServices;
        private readonly ILogger<UserController> _logger;
        public UserController(UserServices userServices, ILogger<UserController> logger)
        {
            _userServices = userServices;
        }
        [HttpGet]

        public IActionResult Get()
        {
            return new OkObjectResult("Using versioning");
        }
        [HttpPost("SaveUser")]
        public IActionResult SaveUser(User user)
        {
            _logger.LogInformation("User Created Successfully");
            return Ok(_userServices.SaveUser(user));
        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
             _logger.LogInformation("User Updated Successfully");
            return Ok(_userServices.UpdateUser(user));
        }
        [HttpGet("GetUser")]
        public IActionResult GetUser(int UserId)
        {
            return Ok(_userServices.GetUser(UserId));
        }
        [HttpGet("GetUserbyEmail")]
        public IActionResult GetUserbyEmail(string Email)
        {
            return Ok(_userServices.GetUserbyEmail(Email));
        }
        [HttpGet("GetAllUser()")]
        public List<User> GetAllUser()
        {
            return _userServices.GetAllUser();
        }

        #region LoginController
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = _userServices.GetUserbyEmail(model.Email);
            if (user != null && model.Password == user.Password)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("Name", user.Name.ToString())

                    }),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YEg6R89Mlv21JbwO")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Email or Password is incorrect." });
            }
        }
        #endregion

        #region EmailService
        [HttpGet("EmailService")]

        public IActionResult SendEmail(string name, string reciever) =>
            //string body = "Dear Sir/Ma'am, \n\n Hello " + name + ".Your email id " + reciever + " is succesfully registered with LOCOMOTIVE Bus Services \n\n Regards,\n Locomotive Bus Services Ltd.";
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("deepuadichanra@gmail.com"));
            //email.To.Add(MailboxAddress.Parse(reciever));
            //email.Subject = "Registration comfirmation mail.";
            //email.Body = new TextPart(TextFormat.Plain) { Text = body };
            //using var smtp = new SmtpClient();
            //smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.None);
            //smtp.Authenticate("deepuadichandra@gmail.com", "mr.sunny909");
            //smtp.Send(email);
            //smtp.Disconnect(true);

            Ok("200");
        #endregion

        #region GetUserProfile

        [HttpGet("GetUserProfile")]
        [Authorize]

        public  User GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            User user =  _userServices.GetUser(int.Parse(userId));
            return user;
        }

        #endregion

    }
}
