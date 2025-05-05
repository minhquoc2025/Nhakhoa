using API._Services.Interfaces;
using API._Services.Services;
using API.Configurations;
using API.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddCors();

// builder.Services.AddSignalR();

builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Add Authentication
// builder.Services.AddAuthenticationConfigufation(builder.Configuration);

builder.Services.AddControllers();

// RepositoryAccessor and Service
builder.Services.AddDependencyInjectionConfiguration(typeof(Program));

// Swagger Config
builder.Services.AddSwaggerGenConfiguration();

// Aspose Config
AsposeUtility.Install();
builder.Services.AddScoped<SDCores.ExceptionHandlingMiddleware>();
builder.Services.AddScoped<I_Service, S_Service_Dental>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// 1.Exception handle
app.UseMiddleware<ExceptionHandlingMiddleware>();

// 2. HTST
// 3. Https Redirection
app.UseWebSockets();
app.UseSDHttpsRedirection();

// 4/ Static File
app.UseStaticFiles();
// 5.Routing 
app.UseRouting();

// 6.CORS
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// 7. Authentication
app.UseAuthentication();

// 8. Authorization
app.UseAuthorization();

// 9. Custom Middleware

app.MapControllers();

// app.MapHub<SignalRHub>("/signalrHub");

app.Run();
