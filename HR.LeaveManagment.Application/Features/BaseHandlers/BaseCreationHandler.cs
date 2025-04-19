using AutoMapper;
using HR.LeaveManagment.Application.DTOs.Common;
using HR.LeaveManagment.Application.Features.BaseLeaveCommand;
using HR.LeaveManagment.Application.Persistance.Contracts;
using HR.LeaveManagment.Domain.Common;
using MediatR;

namespace HR.LeaveManagment.Application.Features.BaseHandlers
{
    public class BaseCreationHandler<TDto, TEntity> : IRequestHandler<BaseCreationCommand<TDto>, int>
        where TEntity : BaseDomainEntity
        where TDto : BaseDto
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public BaseCreationHandler(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(BaseCreationCommand<TDto> request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request.Dto);
            entity = await _repository.AddAsync(entity);
            return entity.Id;
        }
    }
}
