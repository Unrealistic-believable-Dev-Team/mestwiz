using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Auth;
using mestwiz.config.data.entities.Functions;
using mestwiz.config.data.entities;
using Microsoft.AspNetCore.Mvc;
using mestwiz.config.api.logic.Interfaces;

namespace mestwiz.config.api.Controllers
{
    /// <summary>
    /// Controlador de Sesiones del Usuario
    /// </summary>
    [ApiController]
    public class SessionXUserController : ControllerBase
    {

        private readonly ILSessionXUser lSessionXUser;

        public SessionXUserController(ILSessionXUser lSessionXUser)
        {
            this.lSessionXUser = lSessionXUser;
        }

        /// <summary>
        /// Obtiene la Sesión de usuario de acuerdo al Id de Sesión,
        /// Se válida que el host de donde se hace la solicitud
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Config/User/Session/{id}")]
        public async Task<Response<SessionXUser>> Session(string id)
        {
            string userHost = Request.Headers["UserHost"];

            userHost = await userHost.IsNullString() ? Request.HttpContext.Connection.RemoteIpAddress.ToString() : userHost;

            Response<SessionXUser> response = await lSessionXUser.GetForLogin(id, userHost);

            return response;
        }

        /// <summary>
        /// Obtiene la Sesión de usuario de acuerdo al Id de Usuario,
        /// Se válida que el host de donde se hace la solicitud
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Config/User/{id}/Session")]
        public async Task<Response<SessionXUser>> UserSession(string id)
        {
            string userHost = Request.Headers["UserHost"];

            userHost = await userHost.IsNullString() ? Request.HttpContext.Connection.RemoteIpAddress.ToString() : userHost;

            Response<SessionXUser> response = await lSessionXUser.GetByUserId(id, userHost);

            return response;
        }


    }
}
