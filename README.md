# Unity Nakama Sandbox

Experimenting with Unity and Nakama

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
