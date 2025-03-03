// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RS.Common.Data.API.AspNet6.Microsoft.Extensions.DependencyInjection;
using RS.Firstrac.DataObjects.ApiIHelper;
using RS.Firstrac.DataObjects.Stores.Admin;
using RS.Firstrac.DataObjects.Stores.Admin.Interfaces;
using RS.Firstrac.DataObjects.Tests;

IHost host = Host.CreateDefaultBuilder().ConfigureServices(
    services =>
    {
        services.AddAPIHelper<IFirstracApiHelper, FirstracApiHelper>(options =>
        {
            options.BaseUri = new Uri("https://localhost:7054/");

        });
        services.AddTransient<ILegalEntityStore,LegalEntityStore>();
        services.AddSingleton<ITests, Tests>();
    }).Build();

var tests = host.Services.GetRequiredService<ITests>();
await tests.RunTests();

 

