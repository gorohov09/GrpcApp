using Grpc.Server.Data.PostgreSql;
using Grpc.Server.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var grpcPort = builder.Configuration.GetValue<int>("GrpcServerPort");

services.AddGrpc();
services.AddPostgreSql(x => x.ConnectionString = builder.Configuration.GetConnectionString("DbConnectionString"));

var app = builder.Build();
{
    using (var scope = app.Services.CreateScope())
    {
        var migrator = scope.ServiceProvider.GetRequiredService<DbMigrator>();
        await migrator.MigrateAsync();
    }

    app.MapGrpcService<GreeterService>();
    app.MapGrpcService<PacketService>();
    app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

    app.Run($"http://+:{grpcPort}");
}
