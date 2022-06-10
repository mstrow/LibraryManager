using Amazon;
using Amazon.Extensions.NETCore.Setup;
using DataAccessLayer;
using BusinessLayer;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
/*builder.Configuration.AddSystemsManager("/dbconfig", new AWSOptions
{
    Region = RegionEndpoint.USEast1
});*/
builder.Services.RegisterDbContext(@"Server=localhost;Database=LibraryDB;Uid=admin;Pwd=pofAizW6KbVWy3pW6Snd9kZchtwGYz;");
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
