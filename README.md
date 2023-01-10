# Project Title:  Tech Event Management System
Create a new database named “CES”, While designing Database use below structure

1)	Technology
a.	Id (PK)
b.	Name
c.	IsActive
2)	Event
•	Id (P.K.)
•	CityId
•	Venue
•	Start date 
•	End date
•	Description
•	IsCompleted
3)	Speaker
•	Id (P.K.)
•	Name 
•	Bio (Profile)
•	twitterHandle
•	LinkedInUrl
4)	Talk Details
•	Id
•	EventId
•	Room
•	StartTime
•	EndTime
•	Title
•	Description
•	SpearkerId
•	IsCompleted


5)	Cities
•	Id
•	StateId
•	Name
6)	State
a.	Id
b.	Name
 
Constraints 
•	Talk
o	 start and end time can’t be greater than 24 hours.
•	Event 
o	start date and end date can be same.
o	Start date can not be greater than end date.
•	Back-end (core web API) send total mins (talk duration) to client (angular), then client will decide.
o	Convert mins to hours
o	Use ViewModel (convert entity model to viewModel)
•	Back-end (core web API) send start/end date (event days) to client (angular), then
o	Client calculate no of days.
o	Use viewModel
•	Add More
o	If you find

API Endpoints

a.	EventController
i.	Event By Id:
1.	/api/v1/Events/{id}
ii.	Events By Current Month
1.	/api/v1/Events/{mothId}/{yearNumber}
iii.	Get all completed events
1.	/api/v1/Events/completed

 
b.	AuthorController
i.	All speakers of specific event
i.	/api/v1/events/{id}/authors
ii.	Get talk(s) conducted by a speaker for the specific event
ii.	/api/v1/events/{id}/authors/{id}/talks
iii.	Completed talk(s) by specific speaker
1.	/api/v1/events/{id}/authors/{id}/talks/completed

 
c.	VenuController
i.	All venue of specific event
1.	/api/v1/events/{id}/venues
ii.	Get specific venue details
1.	/api/v1/Events/{id}/venue/{id}


General Guidelines

1.	Code should have Error Handling mechanism whenever interact with database.
2.	Solution must be  Testable via any Http Client (Swagger, Fiddler or Postman) apart from Angular.
3.	Only use below two Naming standard whenever applicable while creating class, controller, method to name but a few
1.	camelCase
2.	Pascal cases
4.	RESTful API Guidelines
a.	Response of each method should return appropriate HTTP Status Code. (200,201,204,400,404,406,500)
b.	All the method only access via proper HTTP methods (verb- Get, Post, Put, Delete)
