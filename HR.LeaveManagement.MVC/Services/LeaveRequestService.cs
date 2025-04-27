using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveRequestService : BaseHttpService,ILeaveRequestService
    {
        private readonly IClient _httpclient;
        private readonly ILocalStorageServices _localStorageService;
        private readonly IMapper _mapper;
        public LeaveRequestService(IClient client, ILocalStorageServices services,IMapper mapper) : base(client, services)
        {
            _httpclient = client;
            _localStorageService = services;
            _mapper = mapper;
        }

        public async Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVM leaveRequestVM)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveRequestDto createLeaveRequestDto = _mapper.Map<CreateLeaveRequestDto>(leaveRequestVM);
                AddBearerToken();
                var apiResponse = await _client.LeaveRequestsPOSTAsync(createLeaveRequestDto);
                if (apiResponse.Success)
                {
                    response.Success = true;
                    response.Data = apiResponse.Id;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task DeleteLeaveRequest(int id)
        {
                var response = new Response<int>();
                 await _client.LeaveRequestsDELETEAsync(id);
        }

        public async Task<EmpoleeLeaveRequestViewVM> GetLeaveRequests()
        {
            var LeaveRequestVM = await _client.LeaveRequestsAllAsync(isLoggedInUser:true);
            var allocations = await _client.LeaveAllocationsAllAsync(isLoggedInUser: true);
            var model = new EmpoleeLeaveRequestViewVM()
            {
                leaveAllocationVMs = _mapper.Map<List<LeaveAllocationVM>>(allocations),
                leaveRequestVMs = _mapper.Map<List<LeaveRequestVM>>(LeaveRequestVM)
            };
            return model;
        }

        public Task<LeaveRequestVM> GetLeaveRequestWitrhDetails(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> UpdateLeaveRequest(int Id, LeaveRequestVM leaveRequestVM)
        {
            throw new NotImplementedException();
        }
    }
}
