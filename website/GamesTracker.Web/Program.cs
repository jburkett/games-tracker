using GamesTracker.Core;
using GamesTracker.Core.DataAccess;
using GamesTracker.DataAccess.Postgres;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGameManager, GameManager>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IContextConfigurator, PostgresContextConfigurator>();
builder.Services.AddDbContext<GamesTrackerContext>(
    options => options.UseNpgsql(""));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

await app.RunAsync().ConfigureAwait(false);
