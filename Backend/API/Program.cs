using API.GraphQL;
using Core.Interfaces;
using GraphQL.Server.Ui.Voyager;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var AllowSpecificOrigins = "_allowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//ovo sam dodao zbog InMemory database
builder.Services.AddDbContextFactory<OMContext>(options => {
    options.UseInMemoryDatabase("InMemoryDB");
});


builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();

//integrate graphql
builder.Services
.AddGraphQLServer()
.AddQueryType<Query>()
.AddFiltering();

//cors
builder.Services.AddCors(options => options.AddPolicy(name: AllowSpecificOrigins, policy =>
{
    policy.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod();
}));

var app = builder.Build();

app.UseCors(AllowSpecificOrigins);

app.MapGraphQL();

app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions{GraphQLEndPoint = "/graphql"});

app.Run();
