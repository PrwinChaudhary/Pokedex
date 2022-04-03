#!/bin/bash

docker stop pokedex-app
docker rm pokedex-app
docker run -d --name pokedex-app -p 5000:80 \
        -e ASPNETCORE_ENVIRONMENT=Development \
        -e ASPNETCORE_URLS="http://+" \
        -e "ApplicationSettings:McsAppBuild=local" \
        pokedex-app
		
