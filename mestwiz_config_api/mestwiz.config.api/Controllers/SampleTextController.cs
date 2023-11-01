
using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Samples;
using mestwiz.config.data.entities;
using Microsoft.AspNetCore.Mvc;

namespace mestwiz.config.api.Controllers
{
    [ApiController]
    public class SampleTextController : ControllerBase
    {
        [HttpGet]
        [Route("api/Config/SampleText/Configuration/Short")]
        public async Task<Response<SampleTextConfiguration>> GetForShort()
        {
            LSampleText lSampleText = new();
            Response<SampleTextConfiguration> response = await lSampleText.GetForShort();

            return response;
        }

        [HttpGet]
        [Route("api/Config/SampleText/Configuration/Long")]
        public async Task<Response<SampleTextConfiguration>> GetForLong()
        {
            LSampleText lSampleText = new();
            Response<SampleTextConfiguration> response = await lSampleText.GetForLong();

            return response;
        }

        [HttpGet]
        [Route("api/Config/SampleText/Short/{page}")]
        public async Task<Response<SampleText>> GetShort(int page)
        {
            LSampleText lSampleText = new();
            Response<SampleText> response = await lSampleText.GetShort(page);

            return response;
        }

        [HttpGet]
        [Route("api/Config/SampleText/Long/{page}")]
        public async Task<Response<SampleText>> GetLong(int page)
        {
            LSampleText lSampleText = new();
            Response<SampleText> response = await lSampleText.GetLong(page);

            return response;
        }
    }
}
