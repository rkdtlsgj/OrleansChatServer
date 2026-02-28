using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
        client.UseLocalhostClustering();
    })
    .Build();

await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();

Console.Write("닉네임: ");
var nickname = Console.ReadLine()?.Trim();

Console.Write("채널명: ");
var channel = Console.ReadLine()?.Trim();

var room = client.GetGrain<IChatRoomGrain>(channel);

// Observer 등록 (수신용)
var observer = new ConsoleChatObserver();
var observerRef = client.CreateObjectReference<IChatRoomObserver>(observer);

await room.Join(nickname, observerRef);

Console.WriteLine("입장 완료! (/exit 종료)");
while (true)
{
    var line = Console.ReadLine();
    if (line is null)
        continue;

    if (line.Equals("/exit", StringComparison.OrdinalIgnoreCase))
        break;

    if (string.IsNullOrWhiteSpace(line))
        continue;

    await room.SendMessage(nickname, line);
}

await room.Leave(nickname);

client.DeleteObjectReference<IChatRoomObserver>(observerRef);

await host.StopAsync();
