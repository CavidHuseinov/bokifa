using Oxu.WebAPI.Configurations;
using Oxu.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .InstallServices(
    builder.Configuration, typeof(IServiceInstaller).Assembly);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseCors("AllowAll");
using (var scope = app.Services.CreateScope())
{
    await ApplicationServiceInstaller.SeedDatabaseAsync(scope.ServiceProvider);
}
app.UseMiddleware<GlobalHandleException>();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseStaticFiles();
app.Run();
