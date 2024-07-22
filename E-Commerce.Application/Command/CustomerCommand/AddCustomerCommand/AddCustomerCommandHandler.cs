using Ardalis.Result;
using E_Commerce.Domain.Model.CustomerAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.CustomerCommand.AddCustomerCommand
{
    public class AddCustomerCommandHandler : ICommandHandler<AddCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public AddCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = Customer.Create(request.name, request.email);

                await _customerRepository.Add(customer);

                int saving = await _customerRepository.save();
                if (saving == 0) return Result.Error("no change");
                return Result.Success();
            } catch (Exception ex) {
                return Result.Error(ex.ToString());
            }
        }
    }
}
