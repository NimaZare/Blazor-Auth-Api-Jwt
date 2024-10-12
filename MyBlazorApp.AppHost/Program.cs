var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MyBlazorApp_ApiService>("apiservice");

builder.AddProject<Projects.MyBlazorApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
