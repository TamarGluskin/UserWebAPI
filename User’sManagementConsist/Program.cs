using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using User_sManagementConsist.Model;
using User_sManagementConsist.Repositories;
using UsersManagementConsist.Model;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
                          policy =>
                          {
                              
                              policy.WithOrigins()
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials();
                          });
});
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseInMemoryDatabase("UserDB"));

builder.Services.AddScoped<UserDbContext>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
