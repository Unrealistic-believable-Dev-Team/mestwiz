using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.logic.Auth
{
    public class LMenu : BaseLogic<IMenuDataController>, ILMenu
    {
        public LMenu(IMenuDataController dataController) : base(dataController) { }

        public async Task<Response<Menu>> Get(int id)
        {
            Response<Menu> response = new();
            response.data = await this.dataController.Get(id);

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Menú no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<Menu>>> Get()
        {
            Response<List<Menu>> response = new();
            response.data = await this.dataController.Get();

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Menú no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }
    }
}
