# SmsMicroService
A WebApi microservice to simulate the sending of a sms message written using .net core and visual studio 2017

The architecture of the microservice is CQRS pattern using mediatr, with a repository and unit or work pattern for the database

<p align="center">
  <img src="sms2.png">
</p>

## Minimum Requirements
- .net Core 2.2 
- Visual Studio 2017
- Sql Server
- RabbitMq

## Installation Instructions

If you do not have RabbitMq installed the easiest way is to run it is in a Docker container. 

[Docker](https://hub.docker.com/_/rabbitmq) already provides a RabbitMq container, this can be setup by running the following two lines in Powershell.

`docker run -d --hostname my-rabbit --name some-rabbit -e RABBITMQ_DEFAULT_USER=user -e RABBITMQ_DEFAULT_PASS=password rabbitmq:3-management`

`docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management`

The microservice uses a SqlSever database, to install this, open the SmsMessagesMicroService.sln solution file in Visual Studio.
From the Solution Explorer right click on the Messages.Database project and choose Publish. 

You will be asked to connect a connection to your database instance where you want the database to be installed.

<p align="center">
  <img src="dbconnect.png">
</p>

To run the application, once the database has been installed and rabbitMq is running, from Visual Studio set SmsMessagesMicroService.Api as the start up and click start.

The web api is configured to use Swagger, once running you should be presented with the below screen. From here you can run the api methods



