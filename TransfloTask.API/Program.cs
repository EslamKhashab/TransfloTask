using TransfloTask.Business;
using TransfloTask.Data;
using TransfloTask.Data.Seeds;
using TransfloTask.Shared.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBusiness();
builder.Services.AddData();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    DefaultUsers.Initialize(builder.Configuration.GetConnectionString("DefaultConnection"));
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<GlobalExceptionHandler>();

app.MapControllers();

app.Run();
