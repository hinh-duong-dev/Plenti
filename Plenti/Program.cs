using Microsoft.EntityFrameworkCore;
using Plenti.Data;
using Plenti.Entities;
using Plenti.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<IUserMatcher, UserMatcher>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PlentiDbContext>(opt => opt.UseInMemoryDatabase("Plenti"));
var app = builder.Build();
SeedingData(app);

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


static void SeedingData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetService<PlentiDbContext>();

    if (!context.Users.Any())
    {
        var user = new User()
        {
            Id = 1,
            ReferralCode = "ABC123",
            Name = "Mr A",
        };

        context.Users.Add(user);
    }

    if (!context.Addresses.Any())
    {
        context.Addresses.Add(new Address()
        {
            Id = 1,
            StreetAddress = "51_Pitt Street",
            Suburb = "Level 3",
            State = "Sydney NSW-2000",
            Latitude = -31.083332m,
            Longitude = 150.916672m,
            UserId = 1
        });
    }

    context.SaveChanges();
}
