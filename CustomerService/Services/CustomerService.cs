using CustomerGrpc;
using Grpc.Core;

public partial class CustomerService : CustomerGrpc.CustomerService.CustomerServiceBase
{
    public override Task<CustomerResponse> GetCustomerInfo(CustomerRequest request, ServerCallContext context)
    {
        return Task.FromResult(new CustomerResponse
        {
            CustomerId = request.CustomerId,
            Name = "John Doe",
            Email = "john.doe@example.com"
        });
    }
}