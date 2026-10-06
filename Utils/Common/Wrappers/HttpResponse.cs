using System.Collections.Generic;

namespace Common.Wrappers
{
    public class HttpResponse<T>
    {
        public bool Succeeded { get; set; } = true;
        public T Result { get; set; }
        public List<string> ValidationErrors { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }

        public HttpResponse()
        {
        }

        public HttpResponse(T result)
        {
            Result = result;
        }

        public HttpResponse(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
        }
    }
}