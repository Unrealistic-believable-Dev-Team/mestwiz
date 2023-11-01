
using mestwiz.config.api.logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mestwiz.config.api.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILUsuario LUsuario;

        public UsuarioController(ILUsuario lUsuario)
        {
            this.LUsuario = lUsuario;
        }

        /// <summary>
        /// Obtiene usuario por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/Config/Usuario/{id}")]
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await LUsuario.Get(id));
        }
    }
}
