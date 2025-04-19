
using AutoMapper;
using HR.LeaveManagment.Application.DTOs.Common;
using HR.LeaveManagment.Application.Features.BaseLeaveCommand;
using HR.LeaveManagment.Application.Persistance.Contracts;
using HR.LeaveManagment.Domain.Common;
using MediatR;

namespace HR.LeaveManagment.Application.Features.BaseHandlers
{
    public class BaseUpdateHandler<TDto,TEntity> : IRequestHandler<BaseUpdateCommand<TDto>, Unit>
        where TEntity : BaseDomainEntity
        where TDto : BaseDto
    {
        private readonly IGenericRepository<TEntity> _repository;
        private IMapper _mapper;
        public BaseUpdateHandler(
            IGenericRepository<TEntity> genericRepository,
            IMapper mapper)
        {
            _repository = genericRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(BaseUpdateCommand<TDto> request, CancellationToken cancellationToken)
        {
            var Updatedentity = _mapper.Map<TEntity>(request.Dto);

            await _repository.UpdateAsync(Updatedentity);

            return Unit.Value;
        }
    }
}
