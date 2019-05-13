using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiUserRegistration.Models;

namespace WebApiUserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;


        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManage)
        {
            _userManager = userManager;
            _signInManager = signInManage;
        }

        [HttpPost]
        [Route("Register")]
        //post: /api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser() {
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = model.Password,
                FullName = model.FullName
            };
            try
            {
                var result = _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(await result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        } 

    }
}