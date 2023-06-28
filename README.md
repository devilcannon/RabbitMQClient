# RabbitMQ .NET Example


## What is RabbitMQ?
![RabbitMQ logo](https://www.rabbitmq.com/img/logo-rabbitmq.svg)
RabbitMQ is an open-source message broker software that implements the Advanced Message Queuing Protocol (AMQP). It is used to handle the distribution of messages between applications, services, or systems. RabbitMQ can be thought of as an intermediary between message publishers and subscribers12.

RabbitMQ is widely deployed and used by small startups to large enterprises worldwide. It is lightweight, easy to deploy on-premises or in the cloud, and supports multiple messaging protocols. RabbitMQ can be deployed in distributed and federated configurations to meet high-scale, high-availability requirements1. More details [here](https://www.rabbitmq.com/)

## What is the purpose of this repository? 
Show how is the correct way to publish a message and how you can consume with .NET and C#

## Repo explanation
1. Producer: Create messages to the broker (Print in console)
1. Consumer: Read the messages (Routing key as parameter) and then print in console

## Tecnology stack
1. C# 9 and .NET 6
1. NewtonSoft (For JSON encode and decode)
1. RabbitMQ official NuGet package

## License
Feel free of take this code :)

