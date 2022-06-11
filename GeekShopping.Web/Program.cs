using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IProductService, ProductService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ServicesUrl:ProductApi"]);
});

builder.Services.AddHttpClient<ICartService, CartService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ServicesUrl:CartApi"]);
});

builder.Services.AddHttpClient<ICouponService, CouponService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ServicesUrl:CouponApi"]);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
}).AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
  .AddOpenIdConnect("oidc", options =>
  {
      options.Authority = builder.Configuration["ServicesUrl:IdentityServer"];
      options.GetClaimsFromUserInfoEndpoint = true;
      options.ClientId = "geek_shopping";
      options.ClientSecret = "my_super_secret";
      options.ResponseType = "code";
      options.ClaimActions.MapJsonKey("role","role","role");
      options.ClaimActions.MapJsonKey("sub","sub","sub");
      options.TokenValidationParameters.NameClaimType = "name";
      options.TokenValidationParameters.NameClaimType = "role";
      options.Scope.Add("geek_shopping");
      options.SaveTokens = true;
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
