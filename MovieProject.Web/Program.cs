using MovieProject.Application.Contracts.IServices;
using MovieProject.Application.Services;
using MovieProject.Domain.IRepositories;
using MovieProject.Providers.Omdb.Providers;
using MovieProject.Providers.Omdb.Repositories;
using MovieProject.Web.Components;
using MovieProject.Domain.IProviders;
using Blazored.LocalStorage;
using MovieProject.Infrastructure.Repositories.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton<IOmdbApiProvider>(s => new OmdbApiProvider(builder.Configuration["Api:ApiKey"]!, builder.Configuration["Api:BaseUrl"]!));
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IQueryHistoryRepository, QueryHistoryRepository>();
builder.Services.AddScoped<IQueryHistoryService, QueryHistoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
