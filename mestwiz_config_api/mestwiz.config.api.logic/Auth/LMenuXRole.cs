
using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.logic.Auth
{
    public class LMenuXRole : BaseLogic<IMenuXRoleDataController>, ILMenuXRole
    {
        public LMenuXRole(IMenuXRoleDataController dataController) : base(dataController) { }

        public async Task<Response<MenuXRole>> Get(int id)
        {
            Response<MenuXRole> response = new();
            response.data = await this.dataController.Get(id);

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Menú no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<MenuXRole>>> GetByRoleId(int role_id)
        {
            Response<List<MenuXRole>> response = new();
            response.data = await this.dataController.GetByRoleId(role_id);

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Menú no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<MenuXRole>>> GetByMenuId(int menu_id)
        {
            Response<List<MenuXRole>> response = new();
            response.data = await this.dataController.GetByMenuId(menu_id);

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Menú no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<MenuXRole>> GetByRoleAndMenuId(int menu_id, int role_id)
        {
            Response<MenuXRole> response = new();
            response.data = await this.dataController.GetByRoleAndMenuId(menu_id, role_id);

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Menú no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }
    }
}
