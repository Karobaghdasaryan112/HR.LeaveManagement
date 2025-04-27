using HR.LeaveManagement.MVC.Contracts;
using System.Net;
using System.Net.Http.Headers;

namespace HR.LeaveManagement.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;
        protected readonly ILocalStorageServices _localStorage;
        public BaseHttpService(IClient client, ILocalStorageServices services)
        {
            _client = client;
            _localStorage = services;
        }
        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {
            switch (apiException.StatusCode)
            {
                case (int)HttpStatusCode.Unauthorized:
                    _localStorage.ClearStorage(new List<string> { "token" });
                    return new Response<Guid>
                    {
                        Message = "Unauthorized",
                        Success = false,
                        ValidationErrors = "Unauthorized"
                    };
                case (int)HttpStatusCode.Forbidden:
                    return new Response<Guid>
                    {
                        Message = "Forbidden",
                        Success = false,
                        ValidationErrors = "Forbidden"
                    };
                case (int)HttpStatusCode.NotFound:
                    return new Response<Guid>
                    {
                        Message = "the request Item coult not found",
                        Success = false,
                        ValidationErrors = "Not Found"
                    };
                case (int)HttpStatusCode.InternalServerError:
                    return new Response<Guid>
                    {
                        Message = "Internal Server Error",
                        Success = false,
                        ValidationErrors = "Internal Server Error"
                    };
                case (int)HttpStatusCode.BadRequest:
                    return new Response<Guid>
                    {
                        Message = apiException.Message,
                        Success = false,
                        ValidationErrors = apiException.Response
                    };
                default:
                    return new Response<Guid>
                    {
                        Message = apiException.Message,
                        Success = false,
                        ValidationErrors = apiException.Message
                    };
            }
        }
        protected void AddBearerToken()
        {
            if(_localStorage.Exist("token"))
            {
                var token = _localStorage.GetStorageValue<string>("token");
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
