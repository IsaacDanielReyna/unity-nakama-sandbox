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

# Unity Client Setup

1. Install [Visual Studio Community 2019](https://visualstudio.microsoft.com/downloads/)
2. Install [Unity 2019.4.5f1](https://unity.com/)
3. Open unity-nakama-sandbox project in Unity.
4. Click the play button to run the game.
5. If all is successful, the console should output the session info (AuthToken, Created, CreateTime, ExpireTime, Variables, Username, and UserId).
