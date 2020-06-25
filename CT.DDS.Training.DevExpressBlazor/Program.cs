using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using CT.DDS.Training.DevExpressBlazor.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using CT.DDS.Training.DevExpressBlazor.AuthorizationHandler;

namespace CT.DDS.Training.DevExpressBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddTransient<EmployeeApiAuthorizationMessageHandler>();
            builder.Services.AddHttpClient("employeeApi", client => client.BaseAddress = new Uri("https://localhost:44329/"))
                .AddHttpMessageHandler<EmployeeApiAuthorizationMessageHandler>();
            builder.Services.AddScoped<IEmployeeDataService, EmployeeDataService>();
            builder.Services.AddDevExpressBlazor();
            builder.Services.AddOidcAuthentication(options =>
            {               
                // see https://aka.ms/blazor-standalone-auth 
                builder.Configuration.Bind("Oidc:ProviderOptions", options.ProviderOptions);
                builder.Configuration.Bind("Oidc:UserOptions", options.UserOptions);





            });

            await builder.Build().RunAsync();
        }
    }
}
