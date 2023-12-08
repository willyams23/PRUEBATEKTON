using Microsoft.CodeAnalysis;

namespace TEKTON.Service.Web.API.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
