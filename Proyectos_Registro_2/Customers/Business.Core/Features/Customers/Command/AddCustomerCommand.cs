using AutoMapper;
using Business.Core.Dtos;
using Business.Core.Interfaces.Repositories;
using Business.Core.Interfaces.Services;
using Business.Domain.Models;
using Common.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Core.Features.Customers.Command
{

    public class AddCustomerCommand : CustomerDto, IRequest<HttpResponse<CustomerDto>>
    {

    }

    public class AddCustomerCommandHanlder: IRequestHandler<AddCustomerCommand, HttpResponse<CustomerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly IAddressService _addressService;
        public AddCustomerCommandHanlder(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor accessor,
            IAddressService addressService
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accessor = accessor;
            _addressService = addressService;
        }

        public async Task<HttpResponse<CustomerDto>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Customer>(request);
            var addressDto = _mapper.Map<AddressDto>(request);
            entity = await _unitOfWork.CustomerRepository.AddAsync(entity);
            addressDto.CustomerId = entity.Id;
            var result = await _addressService.AddAsync(addressDto);
            if (!result.Succeeded) {
                _accessor.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await _unitOfWork.CustomerRepository.RemoveAsync(entity);
                return new HttpResponse<CustomerDto>(null) {
                    Succeeded = false,
                    ValidationErrors = result.ValidationErrors,
                    ErrorMessage = result.ErrorMessage,
                    ErrorCode = result.ErrorCode
                };
            }
            else
            {
                request.Id = entity.Id;
                request.AddressDto.Id = result.Result.Id;
                request.IsActive = true;
                return new HttpResponse<CustomerDto>(request);
            }
           
        }
    }

    

}
