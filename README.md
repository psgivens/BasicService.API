# BasicService
Basic service which demonstrates domain agnostic capabilities such as authentication, db connection, and the like. 



# Overview

## Work arounds

**Hot Reload** is broken (at least in Ubuntu 18.04) in the create-react-app setup. [Here](https://stackoverflow.com/questions/42189575/create-react-app-reload-not-working) is a fix.

    sudo -i
    echo 1048576 > /proc/sys/fs/inotify/max_user_watches
    exit


## Creating the react/redux app

See SPAFROMSCRATCH.md
