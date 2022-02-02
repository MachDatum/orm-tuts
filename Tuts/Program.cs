using Tuts;
using Tuts.Models;
using Tuts.Repositories;

var session = Helper.OpenSession("User Id=postgres;Password=MachDatum.1;Host=localhost;Database=orm-tuts");

var userRepository = new UserRepository(session);
var addressRepository = new Repository<Address>(session);
var groupRepository = new Repository<Group>(session);

var deletingUser = userRepository.Get(1);
userRepository.Delete(deletingUser);

var builder = WebApplication.CreateBuilder(args);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
