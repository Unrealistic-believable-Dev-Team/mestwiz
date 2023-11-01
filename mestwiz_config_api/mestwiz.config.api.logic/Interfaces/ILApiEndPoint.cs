using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILApiEndPoint : IBaseLogic<IApiEndPointDataController>, IDisposable
    {
        public Task<Response<List<ApiEndPoint>>> Get();

        public Task<Response<ApiEndPoint>> Update(ApiEndPoint apiEndPoint);

        public Task<Response<ApiEndPoint>> Add(ApiEndPoint apiEndPoint);

        public Task<Message> ValidateNew(ApiEndPoint apiEndPoint);

        public Task<Response<bool>> Delete(string id);
    }
}
