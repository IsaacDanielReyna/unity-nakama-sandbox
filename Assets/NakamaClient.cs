using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nakama;

public class NakamaClient : MonoBehaviour
{
    private readonly IClient client = new Client("http", "127.0.0.1", 7350, "defaultkey");

    // Start is called before the first frame update
    async void Start()
    {
        const string email = "hello@example.com";
        const string password = "verysecure";
        var session = await client.AuthenticateEmailAsync(email, password);
        Debug.Log(session);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
