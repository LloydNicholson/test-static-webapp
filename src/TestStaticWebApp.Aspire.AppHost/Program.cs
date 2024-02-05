var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.TestStaticWebApp_Blazor>("frontend");

builder
    .AddSqlServerContainer("sql-server", "StrongPassword1.", port: 1435)
    .WithVolumeMount("sql-db", "/var/opt/mssql", VolumeMountType.Named)
    .AddDatabase("db");

builder.Build().Run();