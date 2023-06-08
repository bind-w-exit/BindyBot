using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace BindyBot.TwitchApi;

public class TwitchBotClient
{
    private const string TwitchChatUrl = "wss://irc-ws.chat.twitch.tv";
    private const string TwitchChatCommandPrefix = "PRIVMSG";
    private const int ReceiveBufferSize = 512;

    private ClientWebSocket webSocket;
    private CancellationTokenSource cancellationTokenSource;

    public event Action<string, string, string> OnMessageReceived;

    public TwitchBotClient()
    {
        webSocket = new ClientWebSocket();
        cancellationTokenSource = new CancellationTokenSource();
    }

    public async Task ConnectAsync(string oAuthToken, string nick, params string[] channels)
    {
        try
        {
            // Connect to Twitch chat server
            await webSocket.ConnectAsync(new Uri(TwitchChatUrl), cancellationTokenSource.Token);
            //Console.WriteLine($"Connect: {webSocket.State}");

            // Authenticate with Twitch
            await AuthenticateAsync(oAuthToken, nick);
            //var buffer = new byte[ReceiveBufferSize];
            //var receivedDataBuffer = new ArraySegment<byte>(buffer);
            //WebSocketReceiveResult result = await webSocket.ReceiveAsync(receivedDataBuffer, cancellationTokenSource.Token);
            //string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            //Console.WriteLine(message);

            // Join the specified channels
            foreach (var channel in channels)
            {
                await JoinChannelAsync(channel);
            }

            // Start receiving messages
            await ReceiveMessagesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
        }
    }

    private async Task AuthenticateAsync(string oAuthToken, string nick)
    {
        // Construct the AUTH message
        string passMessage = $"PASS oauth:{oAuthToken}";

        // Convert the message to a byte array
        byte[] passMessageBytes = Encoding.UTF8.GetBytes(passMessage);

        // Send the AUTH message to the server
        await webSocket.SendAsync(new ArraySegment<byte>(passMessageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
        //Console.WriteLine($"Authenticate: {webSocket.State}");

        string nickessage = $"NICK {nick}";

        // Convert the message to a byte array
        byte[] nickessageBytes = Encoding.UTF8.GetBytes(nickessage);

        // Send the AUTH message to the server
        await webSocket.SendAsync(new ArraySegment<byte>(nickessageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
        //Console.WriteLine($"Authenticate: {webSocket.State}");
    }

    private async Task JoinChannelAsync(string channel)
    {
        // Construct the JOIN message
        string joinMessage = $"JOIN #{channel}";

        // Convert the message to a byte array
        byte[] joinMessageBytes = Encoding.UTF8.GetBytes(joinMessage);

        // Send the JOIN message to the server
        await webSocket.SendAsync(new ArraySegment<byte>(joinMessageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
        //Console.WriteLine($"JoinChannel: {webSocket.State}");
    }

    private async Task ReceiveMessagesAsync()
    {
        var buffer = new byte[ReceiveBufferSize];
        var receivedDataBuffer = new ArraySegment<byte>(buffer);

        while (!cancellationTokenSource.Token.IsCancellationRequested)
        {
            try
            {
                // Receive a message from the WebSocket
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(receivedDataBuffer, cancellationTokenSource.Token);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    // Process the received message
                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    ProcessMessage(message);
                    //Console.WriteLine(message);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    // Connection closed
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error occurred: {ex.Message}");
                return;
            }
        }
    }

    private void ProcessMessage(string message)
    {
        string[] lines = message.Split('\r', '\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            Console.WriteLine("RawLine:");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(line);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();

            Console.WriteLine("TwitchIrcMessageParser:");
            Console.WriteLine("******************************************");
            string jsonString2 = JsonConvert.SerializeObject(TwitchIrcMessageParser.Parse(line), Formatting.Indented);
            Console.WriteLine(jsonString2);
            Console.WriteLine("******************************************");
            Console.WriteLine();
        }
    }

    public void Disconnect()
    {
        cancellationTokenSource.Cancel();
    }
}