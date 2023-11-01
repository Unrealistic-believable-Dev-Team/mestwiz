using mestwiz.config.data.access.Services;
using Microsoft.AspNetCore.Mvc;
using mestwiz.config.api.entities.Auth;
using mestwiz.config.api.logic.Auth;
using mestwiz.config.api.entities;
using mestwiz.config.data.entities;
using mestwiz.config.data.entities.Functions;
using mestwiz.config.api.Helpers;
using NSwag.Annotations;
using mestwiz.config.data.access;
using mestwiz.config.api.logic.Interfaces;

namespace mestwiz.config.api.Controllers
{
    /// <summary>
    /// Api para Autenticación del Usuario
    /// </summary>
    [OpenApiTag("Auth",
        Description = "Api para Autenticación del Usuario",
        DocumentationDescription = "Documentación externa",
        DocumentationUrl = "")
    ]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ILUser lUser;
        private readonly ILSessionXUser lSessionxuser;

        public AuthController(ILUser lUser, ILSessionXUser lSessionXUser)
        {
            this.lUser = lUser;
            this.lSessionxuser = lSessionXUser;
        }

        [HttpPost]
        [Route("api/Config/Auth/Register")]
        public async Task<Response<User>> Register(UserRegister user)
        {
            string userHost = Request.Headers["UserHost"];
            userHost = await userHost.IsNullString() ? Request.HttpContext.Connection.RemoteIpAddress.ToString() : userHost;

            Response<User> response = await lUser.Register(user, userHost);
          
           return response;
        }

        /// <summary>
        /// Create Session for User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Config/Auth/Login")]
        public async Task<Response<User>> Login(UserLogin user)
        {
            string userHost = Request.Headers["UserHost"];
            userHost = await userHost.IsNullString() ? Request.HttpContext.Connection.RemoteIpAddress.ToString() : userHost;

            Response<User> response = await lUser.Login(user, userHost);
           
            return response;
        }

        /// <summary>
        /// Delete Session from User by Session ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Config/Auth/Logout/Session/{id}")]
        public async Task<Response<bool>> Logout(string id)
        {
            Response<bool> response = await lSessionxuser.Delete(id);

            return response;
        }

        /// <summary>
        /// Test Method For Auth
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Config/Auth/User/Prueba")]
        public async Task<ActionResult> Prueba(UserLogin userLogin)
        {
            return Ok(Settings.DBConnectionString.SimpleEncrypt());
        }
    }
}
