using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.AspNetCore.Mvc;

namespace mestwiz.config.api.Controllers
{
    /// <summary>
    /// Controlador para Permisos del Rol
    /// </summary>
    [ApiController]
    public class PermisionXRoleController : ControllerBase
    {

        private readonly ILPermissionXRole lPermissionXRole;

        public PermisionXRoleController(ILPermissionXRole lPermissionXRole)
        {
            this.lPermissionXRole = lPermissionXRole;
        } 

        /// <summary>
        /// Obtiene el Permiso por Rol de acuerdo al Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Config/Permission/{id}/Role")]
        public async Task<Response<PermissionXRole>> Get(int id)
        {
            
            Response<PermissionXRole> response = await lPermissionXRole.Get(id);

            return response;
        }

        /// <summary>
        /// Obtiene el Permiso por Rol de acuerdo al Id del rol
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Config/Permissions/Role/{id}")]
        public async Task<Response<List<PermissionXRole>>> GetByRoleId(int id)
        {
            Response<List<PermissionXRole>> response = await lPermissionXRole.GetByRoleId(id);

            return response;
        }

        /// <summary>
        /// Obtiene los Permisos por rol de acuerdo al Id de permiso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Config/Permissions/{id}/Role")]
        public async Task<Response<List<PermissionXRole>>> GetByPermissionId(int id)
        {
            Response<List<PermissionXRole>> response = await lPermissionXRole.GetByPermissionId(id);

            return response;
        }

        /// <summary>
        /// Obtiene los Permisos por rol de acuerdo al Id de Permiso e Id de Rol
        /// </summary>
        /// <param name="perm_id"></param>
        /// <param name="role_id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Config/Permission/{perm_id}/Role/{role_id}")]
        public async Task<Response<List<PermissionXRole>>> GetByPermissionAndRoleId(int perm_id, int role_id)
        {
            Response<List<PermissionXRole>> response = await lPermissionXRole.GetByPermissionAndRoleId(perm_id, role_id);

            return response;
        }
    }
}
