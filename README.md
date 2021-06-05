# CustomerManagementAPI
.NET 5 based customer management web API that responds to Post/Get/Put/Delete requests over REST protocol

This back end app works with a React app in the front end. It uses Microsoft SQL Server to store customer information. 

## Live Demo at Azure Cloud
https://customermanagementapi2.azurewebsites.net/

- GET Request&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;.../api/customers &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;Get all customers
- GET Request&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;.../api/customers/3 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;Get a customer with Id = 3
- GET Request&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;.../api/customers/ama &nbsp;&nbsp;=> &nbsp;&nbsp;&nbsp;Get a customer whose name includes 'ama' (Search function)
- POST Request&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;.../api/customers &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;Creates a new customer
- PUT Request&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;.../api/customers/1 &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;Updates a customers with Id = 3
- DELETE Request&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;.../api/customers/1 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=>&nbsp;&nbsp;&nbsp;Deletes a customer with Id = 3
