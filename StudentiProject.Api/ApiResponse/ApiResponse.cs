using System.Net;

namespace StudentiProject.ApiResponse
{
    public class ApiResponse
    {
        public bool Success { get; set; } = true;
        
        public HttpStatusCode Code { get; set; }
        
        public object Response { get; set; }

        public static ApiResponse Ok(object data)
        {
            return Ok(data);
        }
        
        public static ApiResponse Ok(HttpStatusCode statusCode, object data)
        {
            ApiResponse response = new ApiResponse();
            response.Code = statusCode;
            response.Response = data;
            return response;
        }
    }
}