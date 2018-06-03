## Terminology

The pattern used by Blazor-State and MediatR has been around for many years and goes by different names.
Given we are using MediatR will use the names associated with it but list other terminology here for clarification.

### Signals/Actions/**Requests**/Commands/

In Redux they call them "Action".  
In UML they are "Signal".  
In Command Pattern they are "Command"
In MediatR they are `Request`

### Reducer/**Handler**/Executor

This the code that processes the `Request` and returns the `Response`.

In Redux they call them "Reducer". 
(State in State out doesn't reduce anything but they still call them that)
In Command Pattern we call them "Executor".
In MediatR they are `Handler`.

### Feature

A Feature is the collection of the code needed to implement a 
particular [Vertical Slice](https://jimmybogard.com/vertical-slice-architecture/)
of the application.  

On the server side we use the same architecture, 
(see sample in Hosted Server), where the Features contain 
`Controller`, `Handler`, `Request`, `Response`, etc...
Each endpoint has its own controller 
which maps the HTTP Request to the `Request` Object and then sends 
it to the mediator. 
The `Handler` acts on the `Request` and returns a `Response`. 

Server side follows the `Request` in `Response` out pattern.

A Feature Folder on the client side will contain a `Request` and the `Handler` 
and any corresponding files needed for this feature.
The "Response" of client side feature is its `State`.

Client side follows the `State` in new `State` out pattern.