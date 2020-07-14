# rabbitmq-cluster

## Required tools
- Docker Compose (min Docker Engine version tested: 17.06.0)

## How it works

In `Dockerfile` the `RABBITMQ_ERLANG_COOKIE` environment variable is set to configure a same key to cookie for all RabbitMQ cluster. It is needed to cluster formation.

Still in `Dockerfile`, the `rabbitmq-cluster.conf` file is copied to container to be used when necessary.

This `Dockerfile` is used to create all RabbitMQ containers of cluster.

## Instructions
### Create and start cluster

On repo root directory run:
```
docker-compose up -d
```

# References

RabbitMQ Clustering Guide:
https://www.rabbitmq.com/clustering.html

RabbitMQ Cluster Formation and Peer Discovery:
https://www.rabbitmq.com/cluster-formation.html#peer-discovery-classic-config
