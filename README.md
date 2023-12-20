# RabbitMQ Tutorial

## Description

This is a repository for the RabbitMQ tutorial. It contains the code examples for the [RabbitMQ tutorial](https://www.rabbitmq.com/getstarted.html).

> Additionally added a docker-compose file to run RabbitMQ in a container.

## Requirements

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)
- [dotnet](https://dotnet.microsoft.com/download)

## Running the examples

### Running RabbitMQ

To run RabbitMQ, you can use the docker-compose file in this repository. To do so, run the following command:

```bash
docker-compose up -d
```

### Running the receiver

To run the receiver, you can use the following command:

```bash
dotnet run --project ./Receive
# OR using make
make run-receive
```

### Running the sender

To run the sender, you can use the following command:

```bash
dotnet run --project ./Send
# OR using make
make run-send
```
### RabbitMQ Management

To access the RabbitMQ management, you can use the following URL: http://localhost:15672

The default username and password are both `guest`.
