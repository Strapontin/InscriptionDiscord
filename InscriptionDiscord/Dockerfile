FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim-arm64v8 AS build-env

RUN mkdir -p /App
WORKDIR /App


# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:6.0-bullseye-slim-arm64v8
WORKDIR /App
RUN mkdir data

COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "InscriptionDiscord.dll"]


### Pousser un nouveau repository par ligne de commande :
#docker tag local-image:tagname new-repo:tagname
#docker push new-repo:tagname

# Sur windows : 
#docker build -t strapontin/inscription-discord .
#docker push strapontin/inscription-discord

# raspberry :
#sudo docker pull strapontin/inscription-discord:latest
#sudo docker run -d --restart=always -v /home/inscription-discord/:/app/files/ strapontin/inscription-discord




#_____OLD_____#
### Sur la raspberry : 
###sudo docker load -i ./PingPongDiscordBot.tar
###sudo docker run ping-pong-discord-bot

# Sur Windows :
#docker buildx build --platform linux/amd64,linux/arm64,linux/arm/v7 -t ping-pong-discord-bot:latest .
#docker save -o ./PingPongDiscordBot.tar ping-pong-discord-bot
#_____OLD-END_____#



#Commandes que j'ai eu besoin d'utiliser pour activer le restart sur raspberry : 
#$ sudo systemctl start docker
#$ sudo systemctl enable docker
#$ sudo systemctl is-enabled docker # the output should be enabled

