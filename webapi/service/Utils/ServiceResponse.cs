namespace service.Utils
{
    public class ServiceResponse<T>
    {
        public static ServiceResponse<T> SetError(string error)
        {
            return new ServiceResponse<T>()
            {
                Error = true,
                ErrorMessage = error
            };
        }

        public static ServiceResponse<T> SetSuccess(T data)
        {
            return new ServiceResponse<T>()
            {
                Error = false,
                Data = data
            };
        }

        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
