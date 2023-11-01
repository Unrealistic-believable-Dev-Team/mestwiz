namespace mestwiz.config.api.entities
{
    public class Response<T> : Object
    {

        public Message message { get; set; }

        public T data { get; set; }

        public Response()
        {
            this.message = new Message() { };
            this.data = Activator.CreateInstance<T>();
        }
    }

    public class Message
    {
        public ResponseStatus status { get; set; }
        public List<MessageError> errors { get; set; }

        public Message()
        {
            errors = new List<MessageError>();
            status = ResponseStatus.Success;
        }

        public void AddError(MessageError error)
        {
            if (error.TypeMessageError == TypeMessageError.Exception)
                status = ResponseStatus.InternalError;

            errors.Add(error);
        }
    }

    public class MessageError
    {
        public TypeMessageError TypeMessageError { get; set; }
        public string Error { get; set; }

        public MessageError()
        {
            this.TypeMessageError = TypeMessageError.Exception;
        }

    }

}