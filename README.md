# Request Time Tracking Middleware
## Short Description
Add middleware for the request time tracking.
## Topics
* ASP.NET Core
* WebApi
* App configuration
* Middleware
* Hosting
* Logging
## Requirements
* If not specified, feel free to choose between .NET Core and .NET Framework technology, but the first one is prefered.
* Remember about code style and naming conventions.
* Hosting application with IIS is welcome but not required.
* Using of the 3rd party libraries that ease the task implementation directly is prohibited.
* Implement ProfileController with several actions:
	Action that will return one profile by user Id
	Action that will return a collection of profiles
	Action that will add user profile to the collection
	Action that will update user profile in the collection
	Action that will delete user profile from collection
* Implement middleware that will track time when the request started and finished.
* Write the request timing information to logs using NLog or using Serilog.