using DinersHeaven.Api.Errors;
using DinersHeaven.Application;
using DinersHeaven.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddSingleton<ProblemDetailsFactory, DinersHeavenProblemDetailsFactory>();
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}