using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IApiEndPointDataController: IBaseDataController
    {
        public Task<ApiEndPoint> Get(string id);

        public Task<List<ApiEndPoint>> Get();

        public Task<List<ApiEndPoint>> GetByType(string type);

        public Task<bool> Delete(string id);

        public Task<ApiEndPoint> Add(ApiEndPoint apiEndPoint);

        public Task<ApiEndPoint> Update(ApiEndPoint apiEndPoint);
    }
}
