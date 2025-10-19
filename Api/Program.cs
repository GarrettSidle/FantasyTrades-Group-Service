using MediatR;
using Microsoft.EntityFrameworkCore;
using FantasyTradesGroupService.Application.Command.CreateGroup;
using FantasyTradesGroupService.Application.Interfaces;
using FantasyTradesGroupService.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// MediatR (older overload)
builder.Services.AddMediatR(typeof(CreateGroupCommand).Assembly);

// FluentValidation registration removed: this project/package version doesn't expose the AddValidatorsFromAssembly overload used earlier.
// If you want to enable FluentValidation integration, re-add the correct registration for your FluentValidation package (e.g. AddValidatorsFromAssemblyContaining) and the appropriate using.

// EF Core
builder.Services.AddDbContext<GroupDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// Repositories
builder.Services.AddScoped<IGroupRepository, GroupRepository>();

var app = builder.Build();

// Error handling middleware (catches DomainException and general exceptions)
app.UseMiddleware<FantasyTradesGroupService.Api.Middleware.ErrorHandler>();

app.MapControllers();
app.Run();