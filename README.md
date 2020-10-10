# SmsMicroService
A WebApi microservice to simulate the sending of a sms message written using .net core 

The architecture of the microservice is CQRS pattern using mediatr, with a repository and unit or work pattern for the database

<p align="center">
  <img src="sms2.png">
</p>

## Machine Requirements
- Sql Server
- RabbitMq

## Installation Instructions

The microservice uses a SqlSever database, to install this, right click on the Messages.Database project and choose Publish

<p align="center">
  <img src="dbconnect.png">
</p>
