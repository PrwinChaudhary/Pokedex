#!/bin/bash

docker stop pokedex-app
docker rm pokedex-app
docker run -d --name pokedex-app -p 8089:80 -p 44367:443 \
        -e ASPNETCORE_ENVIRONMENT=Development \
        -e ASPNETCORE_URLS="https://+;http://+" \
        -e "ASPNETCORE_HTTPS_PORT=44367" \
        -e "ApplicationSettings:McsAppBuild=local" \
        pokedex-app
		
