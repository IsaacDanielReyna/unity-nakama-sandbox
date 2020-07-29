using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nakama;
using Nakama.TinyJson;
using JetBrains.Annotations;

public class NakamaClient : MonoBehaviour
{
    private const string RoomName = "heroes";
    private readonly IClient client = new Client("http", "127.0.0.1", 7350, "defaultkey");

    private ISocket socket;

    // Start is called before the first frame update
    async void Start()
    {
        const string email = "dev@example.com";
        const string password = "verysecure";
        var session = await client.AuthenticateEmailAsync(email, password, "developered", false);
        Debug.Log(session);

        // Event Handlers
        socket = client.NewSocket();
        socket.Connected += () => Debug.Log("Socket Connected");
        socket.Closed += () => Debug.Log("Socket Closed");
        socket.ReceivedChannelMessage += (message) =>
        {
            Debug.LogFormat("Received: {0}", message);
        };

        socket.ReceivedMatchmakerMatched += async (matched) =>
        {
            Debug.LogFormat("Match: {0}", matched);
            var match = await socket.JoinMatchAsync(matched);

            var self = match.Self;
            Debug.LogFormat("Self: {0}", self);
            Debug.Log(match.Presences);
        };

        await socket.ConnectAsync(session);
        await socket.AddMatchmakerAsync("*", 2, 16);

        var channel = await socket.JoinChatAsync(RoomName, ChannelType.Room);
        Debug.LogFormat("John chat channel: {0}", channel);

        var content = new Dictionary<string, string> { { "hello", "world" } }.ToJson();
        _ = socket.WriteChatMessageAsync(channel, content);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnApplicationQuit()
    {
        socket?.CloseAsync();
    }
}
