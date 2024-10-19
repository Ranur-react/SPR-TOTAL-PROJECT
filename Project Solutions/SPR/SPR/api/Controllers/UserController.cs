using api.Base;
using api.Models;
using api.Models.ViewModel;
using api.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UsersRepository, int>
    {
        private readonly UsersRepository usersRepository;
        public IConfiguration _Configuration;
        public UserController(UsersRepository usersRepository, IConfiguration configuration) : base(usersRepository)
        {
            this.usersRepository = usersRepository;
            this._Configuration = configuration;
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginForm loginVM)
        {
            try
            {
                var result = usersRepository.Login(loginVM);
                if (result > 0)
                {
                    if (result == 3)
                    {
                        return BadRequest(new RequestLoginsForms { status = StatusCodes.Status400BadRequest, result = result, message = "Password salah" });
                    }

                    if (result == 2)
                    {
                        return BadRequest(new RequestLoginsForms { status = StatusCodes.Status400BadRequest, result = result, message = "Username tidak ditemukan" });
                    }

                    else
                    {
                        // return Ok("Login Berhasil");
                        var get = usersRepository.CheckDataAccount(loginVM.Username);
                        var calaims = new List<Claim> {
                            new Claim("Username",get.Username),
                            new Claim("Email",get.Email),
                            new Claim("Role",get.RoleId.ToString()),
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _Configuration["Jwt:Issuer"],
                            _Configuration["Jwt:Audience"],
                            calaims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn

                            );
                        var idToken = new JwtSecurityTokenHandler().WriteToken(token);
                        calaims.Add(new Claim("TokenSecurity", idToken.ToString()));
                        return Ok(new RequestLoginsForms { status = StatusCodes.Status200OK, idToken = idToken, result = result, message = "Login Berhasil" });
                        //return Ok(new RequestLoginsForms { status = HttpStatusCode.OK, IdToken = idToken, Result = result, Message = "Login Berhasil" });

                    }
                }
                else
                {
                    return BadRequest(new RequestLoginsForms { status = StatusCodes.Status400BadRequest, result = result, message = "Login Gagal, Anda belum registrasi" });

                }
            }
            catch (Exception e)
            {
                return BadRequest(new RequestLoginsForms { status = StatusCodes.Status417ExpectationFailed, errors = e.Message + "~Login Controller" });
            }
        }
        [Route("Register")]
        [HttpPost]
        public ActionResult Register(FormRegister entity)
        {
            try
            {
                var result = usersRepository.Register(entity);
                switch (result)
                {
                    case 1:
                        return Ok(new { status = StatusCodes.Status201Created, result, message = $"Data Berhasil Tersimpan ke [{ControllerContext.ActionDescriptor.ControllerName}]" });
                    //return Ok(result);
                    case 2:
                        return Ok(new { status = StatusCodes.Status201Created, result, message = $"Data Berhasil Tersimpan ke [{ControllerContext.ActionDescriptor.ControllerName}] dan kedalam Employee Table" });
                    case 3:
                        return Ok(new { status = StatusCodes.Status200OK, result, message = $"Data sudah ada [{ControllerContext.ActionDescriptor.ControllerName}]" });
                    default:
                        return BadRequest(new { status = StatusCodes.Status400BadRequest, result, message = $" Data gagal Ditambahkan , ada kekeliruan dalam data yang dikirimkan, hubungi adminstrator [{ControllerContext.ActionDescriptor.ControllerName}]" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = StatusCodes.Status417ExpectationFailed, errors = e.Message });
            }
        }


    }
}
