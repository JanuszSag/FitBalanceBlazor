using MudBlazor.Services;
using FitBalanceBlazor.Client.Pages;
using FitBalanceBlazor.Components;
using FitBalanceBlazor.Context;
using FitBalanceBlazor.Services;
using FitBalanceBlazor.Services.DietService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>();

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddScoped<IDietService,DietService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(FitBalanceBlazor.Client._Imports).Assembly);

app.Run();