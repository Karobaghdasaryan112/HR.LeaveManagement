namespace HR.LeaveManagment.Application.Responses
{
    public interface ICommandResponse
    {
        BaseCommandResponse CreateCommandResponse(string message,bool isSuccess,int id,List<string> errors);


    }
}
