using graphql_account_service.Api.GraphQL;
using graphql_account_service.Application.Interfaces;
using graphql_account_service.Application.Services;
using graphql_account_service.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();

builder.Services
.AddGraphQLServer()
.AddQueryType<Query>()
.AddMutationType<Mutation>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapGraphQL(); // Map GraphQL endpoint
});

app.Run();

