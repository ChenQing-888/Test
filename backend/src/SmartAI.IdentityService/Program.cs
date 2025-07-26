using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.Modularity;
using SmartAI.IdentityService;

namespace SmartAI.IdentityService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddApplication<IdentityServiceModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
        }
    }
}