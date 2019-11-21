# BasicService
Basic service which demonstrates domain agnostic capabilities such as authentication, db connection, and the like. 

These services are designed to run in
* docker-compose for local development/testing
* microk8s (kubernetes) for local integration testing
* Azure/AWS Kubernetes for production

# Overview

### docker compose
Change into the "Compose" directory to use docker compose.

* Use `docker-compose -f ./docker-compose-dbinit.yml up` to configure necessary files for the database.
* Use `docker-compose up` to run the application, which is now available on **port 2003**

You can read and execute the ./scripts/run.ps1 to get familiar with the capabilities of this basic service.


## Work arounds

**Hot Reload** is broken (at least in Ubuntu 18.04) in the create-react-app setup. [Here](https://stackoverflow.com/questions/42189575/create-react-app-reload-not-working) is a fix.

    sudo -i
    echo 1048576 > /proc/sys/fs/inotify/max_user_watches
    exit


## Creating the react/redux app

See SPAFROMSCRATCH.md


# Blockers

**Authentication/Authorization**
Check this out
* https://stackoverflow.com/questions/31464359/how-do-you-create-a-custom-authorizeattribute-in-asp-net-core
* https://docs.microsoft.com/en-us/aspnet/core/security/authorization/policies?view=aspnetcore-3.0