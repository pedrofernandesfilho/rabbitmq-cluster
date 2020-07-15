# rabbitmq-cluster

## Required tools

- Docker Compose (min Docker Engine version tested: 17.06.0)

## Instructions

### Create and start cluster

On repo root directory run:
```
docker-compose up -d
```

## How it works

In the `Dockerfile` the `RABBITMQ_ERLANG_COOKIE` environment variable is set to configure a same key to cookie for all RabbitMQ containers. It is needed to cluster formation.

Still in `Dockerfile`, the `rabbitmq-cluster.conf` file is copied to container to be used when necessary.

This `Dockerfile` is used to create all RabbitMQ containers of cluster.

In the `rabbitmq-cluster.conf` file are the defaults settings (loopback_users.guest, listeners.tcp.default and management.tcp.port) and peer discovery settings (cluster_formation.peer_discovery_backend and cluster_formation.classic_config.nodes).

In the `docker-compose.yml` file, three RabbitMQ services are configured. In the second and third the value of `RABBITMQ_CONFIG_FILE` environment variable is set to `rabbitmq-cluster.conf` file path.

# References

RabbitMQ Clustering Guide:\
https://www.rabbitmq.com/clustering.html

RabbitMQ Cluster Formation and Peer Discovery:\
https://www.rabbitmq.com/cluster-formation.html#peer-discovery-classic-config
