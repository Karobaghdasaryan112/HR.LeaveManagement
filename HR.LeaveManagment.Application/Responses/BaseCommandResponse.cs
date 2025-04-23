namespace HR.LeaveManagment.Application.Responses
{
    public class BaseCommandResponse : ICommandResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public int Id { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public BaseCommandResponse CreateCommandResponse(string message, bool isSuccess, int id, List<string> errors)
        {
            Success = isSuccess;
            Message = message;
            Id = id;

            if (errors != null && errors.Count > 0)
                Errors = errors;
            else
                Errors = new List<string>();

            return this;
        }
    }
}
