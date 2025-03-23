#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p 579c6938-9a6a-4a3f-9872-d678913dc471 -t
    fi
    cd ../
fi

docker-compose up -d
