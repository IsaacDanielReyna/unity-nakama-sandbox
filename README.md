# Unity Nakama Sandbox

Experimenting with Unity and Nakama.

# Nakama Server Setup

1. Install [Docker](https://www.docker.com/)
2. Navigate to the project's root and run:  
   `docker-compose -f docker-compose.yml up`  
   This should create:
   - `data\.cookie` file
   - `data\modules` folder
3. Nakama Developer Console should now be accessible at: http://127.0.0.1:7351/
   Use the following credentials to login:
   - username: `admin`
   - password: `password`

See [Nakama QuickStart](https://heroiclabs.com/docs/install-docker-quickstart/) for additional information.

# Client Setup

1. Install [Visual Studio Community 2019](https://visualstudio.microsoft.com/downloads/)
2. Install [Unity 2019.4.5f1](https://unity.com/)
3. Open unity-nakama-sandbox project in Unity.
4. Open the Asset Store and search for Nakama.
5. Select and import the Nakama by Heroic Labs asset.
6. Create a C# script and name it NakamaClient.
7. Double click the file to bring it up into the editor, and add the following:

   ```c#
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
   ```

8. Drag the NakamaClient script onto the Main Camera in the game object hierarchy.
9. Click the play button to run the game.
10. If all is successful, the console should output the session info, such as an auth token.
