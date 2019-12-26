I tried to run the docker compose version. 

    Start-Microservice -Compose -ServiceName BasicService.API

I can log into the dotnet container and connect to the service

    docker exec -it basicservice_basicservice-api_1 /bin/bash
    curl localhost:8003/api/ping

I cannot access it on the host machine. The following times out. 

    curl localhost:2003/api/ping

I suspect that I've not properly tested this on Ubuntu 19.10 and there may be new iptable rules. 