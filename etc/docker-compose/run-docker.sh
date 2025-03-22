#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p 644e85e3-9dcc-4555-8557-7da0869d92f0 -t
    fi
    cd ../
fi

docker-compose up -d
