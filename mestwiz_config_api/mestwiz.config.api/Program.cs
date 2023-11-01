
using mestwiz.config.data.access.Services;
using mestwiz.config.data.entities.Functions;
using Microsoft.EntityFrameworkCore;
using Namotion.Reflection;
using System.Text.Json.Serialization;
using mestwiz.config.api.Helpers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddJsonOptions(x => 
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
 }).ConfigureApiBehaviorOptions(options =>
{
    //options.SuppressConsumesConstraintForFormFileParameters = true;
    //options.SuppressInferBindingSourcesForParameters = true;
    options.SuppressModelStateInvalidFilter = true;
    //options.SuppressMapClientErrors = true;
});

builder.Services.AddControllers().AddXmlOptions(x =>
{
    x.ValidateNullability();
}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "";
    options.Description = "";
});


builder.Services.AddDbContext<DataContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("mestwiz_config").SimpleDecrypt().Result));

var DependencyServiceConfig = new DependencyServiceConfig(builder.Services);
DependencyServiceConfig.Configure();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();

    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseOpenApi();
//    app.UseSwaggerUi3();
//}
app.UseOpenApi();
app.UseSwaggerUi3();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
