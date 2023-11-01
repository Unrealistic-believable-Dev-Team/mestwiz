using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace mestwiz.config.api.Controllers
{

    /// <summary>
    /// Api para Endpoints de Apis Externas o internas.
    /// </summary>
    [OpenApiTag(" ApiEndPoint",
        Description = "Api para Endpoints de Apis Externas o internas.",
        DocumentationDescription = "Documentación externa",
        DocumentationUrl = "")
    ]
    [ApiController]
    public class ApiEndPointController : ControllerBase
    {

        private readonly ILApiEndPoint lApiEndPoint;

        public ApiEndPointController(ILApiEndPoint lApiEndPoint)
        {
            this.lApiEndPoint = lApiEndPoint;
        }


        /// <summary>
        /// Método para obtener el listado de Endpoints
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Config/ApiEndPoint")]
        public async Task<Response<List<ApiEndPoint>>> Get()
        {
            Response<List<ApiEndPoint>> response = await lApiEndPoint.Get();

            return response;
        }

        /// <summary>
        /// Actualiza un Elemento
        /// </summary>
        /// <param name="apiEndPoint"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Config/ApiEndPoint")]
        public async Task<Response<ApiEndPoint>> Update(ApiEndPoint apiEndPoint)
        {
            Response<ApiEndPoint> response = await lApiEndPoint.Update(apiEndPoint);

            return response;
        }

        /// <summary>
        /// Agrega un Elemento
        /// </summary>
        /// <param name="apiEndPoint"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Config/ApiEndPoint")]
        public async Task<Response<ApiEndPoint>> Add(ApiEndPoint apiEndPoint)
        {
            Response<ApiEndPoint> response = await lApiEndPoint.Add(apiEndPoint);

            return response;
        }

        /// <summary>
        /// Elimina un Elemento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/Config/ApiEndPoint/{id}")]
        public async Task<Response<bool>> Delete(string id)
        {
            Response<bool> response = await lApiEndPoint.Delete(id);

            return response;
        }

    }
}
