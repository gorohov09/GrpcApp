using Google.Protobuf.WellKnownTypes;
using Grpc.Client;
using Grpc.Net.Client;
using GrpcClient;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var gRPCServerAddr = configuration["GRPCServerAddr"];
var gRPCServerPort = configuration["GRPCServerPort"];
var totalPackets = int.Parse(configuration["TotalPackets"]);
var recordsInPacket = int.Parse(configuration["RecordsInPacket"]);
var timeInterval = int.Parse(configuration["TimeInterval"]);


using var channel = GrpcChannel.ForAddress($"{gRPCServerAddr}{gRPCServerPort}");

var client = new Packeter.PacketerClient(channel);

for (int i = 0; i < totalPackets; i++)
{
    var packet = PacketGenerator.GeneratePacket(i + 1, recordsInPacket);
    var datas = packet.PacketData.Select(x => new Grpc.Client.PacketRecord
    {
        Decimal1 = (double)x.Decimal1,
        Decimal2 = (double)x.Decimal2,
        Decimal3 = (double)x.Decimal3,
        Decimal4 = (double)x.Decimal4,
        Timestamp = Timestamp.FromDateTime(x.Timestamp.ToUniversalTime()),
    }).ToList();

    var request = new ReceivePacketRequest()
    {
        PacketSeqNum = packet.PacketSeqNum,
        NRecords = packet.NRecords,
        PacketTimestamp = Timestamp.FromDateTime(packet.PacketTimestamp.ToUniversalTime()),
    };

    request.PacketData.AddRange(datas);

    var response = await client.ReceivePacketAsync(request);
    await Task.Delay(timeInterval * 1000);
}
