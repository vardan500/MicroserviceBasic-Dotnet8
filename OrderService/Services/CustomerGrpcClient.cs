using CustomerGrpc;
using Grpc.Net.Client;

public class CustomerGrpcClient
{
    private readonly CustomerService.CustomerServiceClient _client;

    public CustomerGrpcClient(IConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration["Grpc:CustomerServiceUrl"]);
        _client = new CustomerService.CustomerServiceClient(channel);
    }

    public async Task<CustomerResponse> GetCustomerInfoAsync(string customerId)
    {
        var request = new CustomerRequest { CustomerId = customerId };
        return await _client.GetCustomerInfoAsync(request);
    }
}