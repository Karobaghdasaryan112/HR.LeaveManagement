using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpService,ILeaveTypeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;
        private readonly ILocalStorageServices _localStorageService;
        public LeaveTypeService(IMapper mapper,IClient client, ILocalStorageServices services) : base(client, services)
        {
            _mapper = mapper;
            _httpClient = client;
            _localStorageService = services;
        }


        public async Task<Response<int>> CreateLeaveTypeAsync(CreateLeaveTypeVM model)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveTypeDto createLeaveTypeDto = _mapper.Map<CreateLeaveTypeDto>(model);
                AddBearerToken();
                var apiResponse = await _client.LeaveTypesPOSTAsync(createLeaveTypeDto);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
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

        public async Task<Response<int>> DeleteLeaveTypeAsync(int id)
        {
            try
            {
                var response = new Response<int>();
                AddBearerToken();
                await _client.LeaveTypesDELETEAsync(id);
                response.Success = true;
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetailsAsync(int Id)
        {
                AddBearerToken();
                var response = new Response<int>();
                var apiResponse = await _client.LeaveTypesGETAsync(Id);
                var LeaveTypeVM = _mapper.Map<LeaveTypeVM>(apiResponse);
                return LeaveTypeVM;
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypesAsync()
        {
            AddBearerToken();

            var apiResponse = await _client.LeaveTypesAllAsync();

            return _mapper.Map<List<LeaveTypeVM>>(apiResponse);
        }

        public async Task<Response<int>> UpdateLeaveTypeAsync(int Id,LeaveTypeVM leaveTypeVM)
        {
            try
            {
                AddBearerToken();
                var response = new Response<int>();
                LeaveTypeDto leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveTypeVM);
                var apiResponse = await _client.LeaveTypesPUTAsync(Id.ToString(), leaveTypeDto);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
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
    }
}
