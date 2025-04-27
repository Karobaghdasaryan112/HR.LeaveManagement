namespace HR.LeaveManagement.MVC.Services.Base
{
    public class Response<TData>
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = false;
        public TData Data { get; set; } = default!;
        public string ValidationErrors { get; set; } = string.Empty;    
    }
}
