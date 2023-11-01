using mestwiz.config.api.entities;
using mestwiz.config.api.entities.Auth;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.AspNetCore.Mvc;

namespace mestwiz.config.api.Controllers
{
    [ApiController]
    [Consumes("application/xml", "application/json")]
    [Produces("application/xml", "application/json")]
    public class UserController: ControllerBase
    {

        private readonly ILUser lUser;

        public UserController(ILUser lUser)
        {
            this.lUser = lUser;
        }

        /// <summary>
        /// Obtiene usuario por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/Config/User/{id}")]
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await lUser.Get(id)) ;
        }

        [HttpPost]
        [Route("api/Config/User/Add")]
        public async Task<ActionResult> Add(User user)
        {
            return Ok(await lUser.Add(user));
        }

        /// <summary>
        /// Obtiene lista de Usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/Config/User")]
        public async Task<Response<List<User>>> Get()
        {
            return await lUser.Get();
        }

        /// <summary>
        /// Obtiene el Menu para el usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/Config/User/{user_id}/Menu")]
        public async Task<Response<List<UserMenu>>> GetMenu(string user_id)
        {
            return await lUser.GetMenu(user_id);
        }
    }
}
