
using mestwiz.config.data.controller.Interfaces;

namespace mestwiz.config.api.logic
{
    public class BaseLogic<T>: IBaseLogic<T> where T : class
    {
        protected readonly T dataController;

        public void Dispose()
        {
            ((IBaseDataController)this.dataController)?.Dispose();
        }

        public BaseLogic(T dataController)
        {
            this.dataController = dataController;
        }
    }
}




