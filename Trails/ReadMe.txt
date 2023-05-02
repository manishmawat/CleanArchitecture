Clean architecture

1) Domain - (Domain layer does not reference any other layer)
	Core bussiness 
	Factory Interface
	Enumeration
	Value Object
	Custom Exception

2) Application - (Application layer references Domain layer) - (This is where we implement use cases, we can use services or MediatR)

3) Infrastructure - (Here we will register any external concerns for our application)
	Databases
	Email sender
	Notifications

4) Presentation

5) WebApi - (This layer reference all other layers like Application, Infra, Presentation || We don't need to reference Domain as it will come through Application)



	
	