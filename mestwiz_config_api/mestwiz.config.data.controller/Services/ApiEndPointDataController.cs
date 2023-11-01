using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class ApiEndPointDataController: BaseDataController, IApiEndPointDataController
    {
        public ApiEndPointDataController(IDataController dataController): base(dataController) { }

        public async Task<ApiEndPoint> Get(string id)
        {
            return await this.GetEntity<ApiEndPoint>().Where(apie => apie.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ApiEndPoint>> Get()
        {
            return await this.GetEntity<ApiEndPoint>().ToListAsync();
        }

        public async Task<List<ApiEndPoint>> GetByType(string type)
        {
            return await this.GetEntity<ApiEndPoint>().Where(apie => apie.type == type).ToListAsync();
        }

        public async Task<bool> Delete(string id)
        {
            ApiEndPoint updatedApiEndPoint = await Get(id);
            this.GetEntity<ApiEndPoint>().Remove((ApiEndPoint)updatedApiEndPoint);
            await this.SaveChangesAsync();
            return true;
        }

        public async Task<ApiEndPoint> Add(ApiEndPoint apiEndPoint)
        {
            await this.GetEntity<ApiEndPoint>().AddAsync(apiEndPoint);
            await this.SaveChangesAsync();  
            return apiEndPoint;
        }

        public async Task<ApiEndPoint> Update(ApiEndPoint apiEndPoint)
        {

            ApiEndPoint updatedApiEndPoint = await Get(apiEndPoint.id);

            updatedApiEndPoint.port = apiEndPoint.port;
            updatedApiEndPoint.status = apiEndPoint.status;
            updatedApiEndPoint.type = apiEndPoint.type;
            updatedApiEndPoint.url = apiEndPoint.url;

            this.GetEntity<ApiEndPoint>().Update(updatedApiEndPoint);

            await this.SaveChangesAsync();

            return updatedApiEndPoint;
        } 
    }
}
