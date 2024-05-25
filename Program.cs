using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using Yamine;
using Yamine.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddAuthorizationCore();
builder.Services.AddRadzenComponents();

builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Yamine"));

// SecurityService�� �����ڿ��� IHttpClientFactory�� �Ű������� DI �ϱ� ������ �Ʒ��� ���� ó���� �ʿ��ϴ�.
// https://learn.microsoft.com/ko-kr/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0
// https://dev.to/callmewhy/exercises-on-dependency-injection-in-asp-net-basics-3d4b
// https://www.code4it.dev/blog/solve-constructor-exception-with-httpclientfactory/
// https://stackoverflow.com/questions/56087274/a-suitable-constructor-for-type-restdataservice-could-not-be-located
// https://stackoverflow.com/questions/52186856/unable-to-resolve-service-for-type-system-net-http-httpclient
builder.Services.AddHttpClient<SecurityService>(client => { client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); });
builder.Services.AddScoped<SecurityService>();



var app = builder.Build();

await app.RunAsync();
