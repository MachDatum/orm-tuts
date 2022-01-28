using Tuts;
using Tuts.Models;

var session = Helper.OpenSession("User Id=postgres;Password=MachDatum.1;Host=localhost;Database=orm-tuts");

//session.Save(new User
//{
//    Name = "Hemanand"
//});
//session.Flush();
var users = session.Query<User>().ToList();



var builder = WebApplication.CreateBuilder(args);

var user = session.Get<User>(1);
user.Name = "Hemanand R";
session.Update(user);
session.Flush();

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
