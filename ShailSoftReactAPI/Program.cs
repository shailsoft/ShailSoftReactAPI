using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShailSoftReactAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ShailSoftReactAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShailSoftReactAPIContext") ?? throw new InvalidOperationException("Connection string 'ShailSoftReactAPIContext' not found.")));
//  // Default Policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:7130", "http://localhost:7130")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

// Named Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7130/", "https://localhost:7130/")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Shows UseCors with CorsPolicyBuilder.
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
