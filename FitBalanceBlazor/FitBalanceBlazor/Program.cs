using System.Net;
using System.Text;
using Blazored.LocalStorage;
using MudBlazor.Services;
using FitBalanceBlazor.Client.Pages;
using FitBalanceBlazor.Components;
using FitBalanceBlazor.Context;
using FitBalanceBlazor.Services;
using FitBalanceBlazor.Services.AuthService;
using FitBalanceBlazor.Services.CategoryService;
using FitBalanceBlazor.Services.DietService;
using FitBalanceBlazor.Services.EmployeeService;
using FitBalanceBlazor.Services.MealService;
using FitBalanceBlazor.Services.ProductService;
using FitBalanceBlazor.Services.ProgramService;
using FitBalanceBlazor.Services.QuestionAnswerService;
using FitBalanceBlazor.Services.ReportService;
using FitBalanceBlazor.Services.ReviewService;
using FitBalanceBlazor.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<IDietService,DietService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IProgramService, ProgramService>();
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IQuestionAnswerService, QuestionAnswerService>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value))
        };
    });
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
builder.Services.AddAuthorization();

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5131/") });
builder.Services.AddCascadingAuthenticationState();

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

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(FitBalanceBlazor.Client._Imports).Assembly);

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();