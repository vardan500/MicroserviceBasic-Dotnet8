var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/customer", () =>
{
    return new[] { "Alice", "Bob", "Charlie" };
})
.WithName("GetCustomer")
.WithOpenApi();

app.MapGrpcService<CustomerService>();
app.MapGet("/", () => "Customer Service is running...");

app.Run();

