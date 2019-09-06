[![Build Status](https://travis-ci.com/amolines/cqrs.svg?branch=develop)](https://travis-ci.com/amolines/cqrs)

# Xendor 
Xendor is a .NET Core framework that can be used to create a simple and clean design by enforcing single responsibility and separation of concerns.
Its advanced features are ideal for Domain Driven Design (DDD), Command Query Responsibilty Segragation (CQRS) and Event Sourcing.
Xendor also has RabbitMQ integrations.

# What is CQRS?
Command-Query Responsibility Segregation is a pattern that tells us to separate operations that mutate data from the ones that query it. It is derived from Command Query Separation (CQS) 
CQS states that there can be only two kind of methods on a class: the ones that mutate state and return void and the ones that return state but do not change it. 
>CQRS is a pattern you apply on “the insides” of your service/application and you may apply it only to portion of your service.
 
## That is not CQRS 
### It is not eventual consistency
### It is not eventing
### It is not messaging
### It is not having separated models for reading and writing
### Nor is it using event sourcing.

## CQRS pros & cons
### Pros:
-	better performance and scalability of your system.
-	better concurrent access handling.
-	better team scalability.
-	less complex domain model and simple query model.
### Cons:
-	read and write models must be kept in sync.
-	maintenance and administration costs if you choose two different engines for read and for write side.
-	eventual consistency is not always allowed. 



# What is Event Sourcing?
Instead of storing just the current state of the data in a domain, use an append-only store to record the full series of actions taken on that data. The store acts as the system of record and can be used to materialize the domain objects. This can simplify tasks in complex domains, by avoiding the need to synchronize the data model and the business domain, while improving performance, scalability, and responsiveness. It can also provide consistency for transactional data, and maintain full audit trails and history that can enable compensating actions.

## In which systems is it worth using Event Sourcing?
-	Your system has many behaviors that are not an ordinary CRUD.
-	Recreating historical states of objects is very important
-	Business users see advantages of having full history for statistics, machine learning or other purposes.
-	Your domain is best described by events (for example, an application to track an assistance vehicle activities).

## Event Sourcing pros & cons
### Pros:
-	append only model is great for performance, scalability
-	no deadlocks
-	events (facts) are well understood by the business expert, some domains are inherently event sourced: accounting, healthcare, trading
-	audit trail for free
-	we can get object state at any point in time
-	easy to test and debug
-	data model decoupled from domain model
-	no impedance mismatch (object model vs data model)
-	flexibility – many different domain models can be constructed from the same stream of events
-	we can use this model with reversing events, retroactive events
-	no more ORMs – thanks to the fact that our object is built from events, we do not have to reflect it in a relational database
### Cons:
-	not natural way for developers to manage state and construct aggregates, takes time to get used to
-	querying beyond one aggregate is a bit harder (you have to construct projections for each type of query you want to add to the system),
-	event schema changes is much harder than in case of relational model (lack of standard schema migration tools)
-	you must consider versioning handling from the beginning.

## Event Sourcing - Projections
Projection is an important concept while building event-centric systems. At the same time, it is extremely simple.

>Projection is about deriving current state from the stream of events.

For instance, consider a situation, where a stream of events is published out by a server to all subscribers.
These events are related to user registrations and look like:

UserAddedToAccount 
```json
{
 "userId" : 55,
 "username" : "alemol",
 "name":"Alejandro",
 "lastName":"Moline"
}
```
UserVerifiedEmail
```json
{
 "userId" : 55,
 "email" : "alemol32@gmail.com"
}
```
UserUpdated
```json
{
 "userId" : 55,
 "lastName" : "Molines"
}
```
We can attach a subscriber to stream of these events to project this stream into a persistent read model, used to serve user details in a Web UI.
Final read model could look like:
```json
{
 "userId": 55,
 "username": "alemol",
 "email": "alemol32@gmail.com",
 "name": "Alejandro",
 "lastName":"Molines"
}
```
 # CQRS with Event Sourcing (CQRS-ES)
![alt text](https://raw.githubusercontent.com/amolines/cqrs/develop/CQRS-ES.png)



## Give a Star! :star:
If you like or are using this project please give it a star. Thanks!

<a href="https://www.buymeacoffee.com/OUEB8XwD2" target="_blank">
<img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" >
</a>


I found an issue or I have a change request
--------------------------------
Feel free to create an issue on GitHub. Contributions, pull requests are more than welcome!

**Xendor** is Copyright &copy; 2019 [Alejandro Molines](https://www.linkedin.com/in/amolines/) and other contributors under the [MIT license](LICENSE.txt).