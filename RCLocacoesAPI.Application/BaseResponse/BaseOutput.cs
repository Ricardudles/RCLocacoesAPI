namespace com.raizen.PGC.Application.Models
{
    public class BaseOutput<T> : Response
    {
        public BaseOutput()
        {
            Response = default;
        }

        public BaseOutput(T response)
        {
            Response = response;
        }

        public T Response { get; set; }
    }
}
