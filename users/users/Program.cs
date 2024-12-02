using Microsoft.AspNetCore.Builder;
using users.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using users.Models;
using users.Repositoreis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UsersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

builder.Services.AddScoped<IUserRepositoreis, UserRepositoreis>();
builder.Services.AddScoped<IUsersServices, UsersServices>();
builder.Services.AddScoped<ITasksServices, TasksServices>();
builder.Services.AddScoped<ITasksRepositoreis, TasksRepositoreis>();
builder.Services.AddScoped<IProjectServices, ProjectServices>();
builder.Services.AddScoped<IProjectRepositoreis, ProjectRepositoreis>();
builder.Services.AddScoped<IAttachmentsServices, AttachmentsServices>();
builder.Services.AddScoped<IAttachmentsRepositoreis, AttachmentsRepositoreis>();

builder.Services.AddScoped<ICangesServices, CangesServices>();
builder.Services.AddScoped<IChangesRepositoreis, ChangesRepositoreis>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Attachments API",
        Description = "An API to manage attachments",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com",
            Url = new Uri("https://yourwebsite.com"),
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Attachments API V1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
