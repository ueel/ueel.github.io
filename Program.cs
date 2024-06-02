using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using System.Net.Http.Headers;
using Yamine;
using Yamine.Services;
using static System.Net.WebRequestMethods;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddAuthorizationCore();
builder.Services.AddRadzenComponents();

builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Yamine"));

// SecurityService의 생성자에서 IHttpClientFactory를 매개변수로 DI 하기 때문에 아래와 같이 처리가 필요하다.
// https://learn.microsoft.com/ko-kr/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0
// https://dev.to/callmewhy/exercises-on-dependency-injection-in-asp-net-basics-3d4b
// https://www.code4it.dev/blog/solve-constructor-exception-with-httpclientfactory/
// https://stackoverflow.com/questions/56087274/a-suitable-constructor-for-type-restdataservice-could-not-be-located
// https://stackoverflow.com/questions/52186856/unable-to-resolve-service-for-type-system-net-http-httpclient
builder.Services.AddHttpClient<SecurityService>(client => { client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); });
builder.Services.AddScoped<SecurityService>();

var movieUrl = builder.Configuration.GetSection("ApiUrls").GetValue<string>("TheMovie") ?? "https://api.themoviedb.org/3/";

builder.Services.AddHttpClient<IMovieService, MovieService>(client =>
{
    client.BaseAddress = new Uri(movieUrl);
    client.DefaultRequestHeaders.Add("accept","application/json");
    client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("THE_MOVIE_ACCESS_TOKEN") 
                         ?? builder.Configuration.GetSection("Tokens").GetValue<string>("TheMovie"));
});


var app = builder.Build();

await app.RunAsync();
