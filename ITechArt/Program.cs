using ITechArt.Data;
using Microsoft.EntityFrameworkCore;
using ITechArt.Functions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("PeopleConnnection"));
});

builder.Services.AddTransient<IFileXML, FileXML>();

builder.Services.AddTransient<IFileXLSX, FileXLSX>();

builder.Services.AddTransient<IFileCSV, FileCSV>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
