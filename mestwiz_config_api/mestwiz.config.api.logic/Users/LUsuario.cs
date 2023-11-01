using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.logic.Users
{
    public class LUsuario: BaseLogic<IUsuarioDataController>, ILUsuario
    {
        public LUsuario(IUsuarioDataController usuarioDataController): base(usuarioDataController) { }

        public async Task<Response<User>> Get(string Id)
        {
            Response<User> response = new();
            response.data = await this.dataController.Get(Id);

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El usuario no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }
    }
}
