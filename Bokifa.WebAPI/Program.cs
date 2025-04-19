using Bokifa.Application.Validators.Book;
using Bookifa.Persistance;
using Bookifa.WebAPI.Configurations;
using Bookifa.WebAPI.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.InstallServices(
    builder.Configuration,
    typeof(Program).Assembly,
    typeof(Bokifa.Application.AssemblyReference).Assembly,
    typeof(Bokifa.Persistance.AssemblyReference).Assembly,
    typeof(Bokifa.Presentation.AssemblyReference).Assembly
);
builder.Services.AddFluentValidationAutoValidation()
       .AddFluentValidationClientsideAdapters()
       .AddValidatorsFromAssemblyContaining<CreateBookValidator>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseCors("AllowAll");
using (var scope = app.Services.CreateScope())
{
    await PersistanceServiceInstaller.SeedDatabaseAsync(scope.ServiceProvider);
    await PersistanceServiceInstaller.CurrencyDatabaseAsync(scope.ServiceProvider);
}
app.UseMiddleware<GlobalHandleException>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.Run();
