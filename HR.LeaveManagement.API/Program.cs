using HR.LeaveManagment.Application;
using HR.LeaveManagment.Infrastructure;
using HR.LeaveManagment.Persistance;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistanceServices(builder.Configuration);

builder.Services.AddCors(o =>
            o.AddPolicy("CorePolicy",
            builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader())
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","HR.LeaveManagement.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorePolicy");

app.MapControllers();

app.Run();
