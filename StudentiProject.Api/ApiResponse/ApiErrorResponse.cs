using System.Collections.Generic;
using System.Net;

namespace StudentiProject.ApiResponse
{
    public class ApiErrorResponse : ApiResponse
    {
        public new bool Success { get; set; } = false;
        public ICollection<ApiErrorInformation> Errors { get; set; }

        public static ApiResponse Error(HttpStatusCode statusCode, ICollection<ApiErrorInformation> errors)
        {
            ApiErrorResponse response = new ApiErrorResponse();
            response.Code = statusCode;
            response.Errors = errors;
            return response;
        }

        public static ApiResponse Error(HttpStatusCode statusCode, ApiErrorInformation error)
        {
            ICollection<ApiErrorInformation> errors = new List<ApiErrorInformation>();
            errors.Add(error);
            return Error(statusCode, errors);
        }
    }
}