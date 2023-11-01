using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using mestwiz.config.data.entities.Functions;

namespace mestwiz.config.api.logic.Administration
{
    public class LApiEndPoint : BaseLogic<IApiEndPointDataController>, ILApiEndPoint
    {
        public LApiEndPoint(IApiEndPointDataController dataController) : base(dataController) { }

        public async Task<Response<List<ApiEndPoint>>> Get()
        {
            Response<List<ApiEndPoint>> response = new();
            response.data = await this.dataController.Get();

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "No hay End Points Registrados", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }


        public async Task<Response<ApiEndPoint>> Update(ApiEndPoint apiEndPoint)
        {
            Response<ApiEndPoint> response = new();

            try
            {
                response.data = await this.dataController.Update(apiEndPoint);

                response.message.status = ResponseStatus.Success;
            }
            catch (Exception e)
            {
                response.message.AddError(new MessageError() { Error = e.Message });
            }

            return response;
        }

        public async Task<Response<ApiEndPoint>> Add(ApiEndPoint apiEndPoint)
        {
            Response<ApiEndPoint> response = new();

            try
            {
                apiEndPoint.id = await apiEndPoint.GetNewId();
                response.message = await ValidateNew(apiEndPoint);

                if (response.message.status != ResponseStatus.Success)
                    return response;

                response.data = await this.dataController.Add(apiEndPoint);

                response.message.status = ResponseStatus.Success;
            }
            catch (Exception e)
            {
                response.message.AddError(new MessageError() { Error = e.Message });
            }

            return response;
        }


        public async Task<Message> ValidateNew(ApiEndPoint apiEndPoint)
        {
            Message _Message = new();

            if(apiEndPoint == null)
            {
                _Message.AddError(new MessageError() { Error = "ApiEndPoint no valido" });
                return _Message;
            }

            if (await apiEndPoint.id.IsNullString())
                _Message.AddError(new MessageError() { Error = "ApiEndPoint no valido, Id es obligatorio" });
            if (await apiEndPoint.status.IsNullString())
                _Message.AddError(new MessageError() { Error = "ApiEndPoint no valido, Status es obligatorio" });
            if (await apiEndPoint.url.IsNullString())
                _Message.AddError(new MessageError() { Error = "ApiEndPoint no valido, URL es obligatorio" });

            if (await apiEndPoint.type.IsNullString())
                _Message.AddError(new MessageError() { Error = "ApiEndPoint no valido, Type es obligatorio" });

            return _Message;
        }

        public async Task<Response<bool>> Delete(string id)
        {
            Response<bool> response = new();

            try
            {
                response.data = await this.dataController.Delete(id);

                response.message.status = ResponseStatus.Success;
            }
            catch (Exception e)
            {
                response.message.AddError(new MessageError() { Error = e.Message });
            }

            return response;
        }
    }
}
