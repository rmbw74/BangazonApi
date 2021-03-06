# BangazonApi
Bangazon API Sprint for the Stormy Hares

## External Tools used with this API
This api uses the SWAGGER api development tool
please see https://swagger.io/swagger-ui/ for information

## Installing the Bangazon Api
1. start by cloning the repo to the machine that will be running the webapi
1. use the green clone/download button on the github repo
1. copy the link provided.
1. on the local machine, create the folder that you wish the api to reside
1. navigate into that folder and then use the command "Git Clone" followed by the
    url that you copied in step 3.
1. once the repo has been copied down you are ready to start.
1. navigate to the root folder of the project, and type dotnet restore into the terminal

## Setting up your environment variables
1. add the following environemnt variable to your shell script
export BANGAZON="[ABSOLUTE PATH TO DB FILE]"
1. you must replace everything within the quotes with the absolute path to where your database file will reside. By default, the program will create the db file in the root of the project.

## Setting host file to access the Bangazon API.
By default the Bangazon Api only allows external requests from the bangazon.com domain.
follow these steps to modify your host file in order to comply with CORS policy
1. use a text editor to open your hosts file
    for macs you can use "sudo nano /etc/hosts" in the terminal to open the file.
    for pc's the file is typically found @ /windows/system32/drivers/etc/hosts
2. add bangazon.com to the file.
3. save the file



## creating the database
The banagazon api by default will create a seeded database with test information. If you wish to start with a completely empty database you must follow these steps. If you want to start with the default seeded database, skip to step 4
1. open the program.cs file
1. comment out all code between the "SEED" and "END SEED" comments
1. save your changes to program.cs
1. from the terminal type "dotnet ef database update"
1. the BangazonApi.db file should now reside in the project folder.
1. verify that the path you specified above in the environment variable section matches the file location

## running for the first time.
1. type "dotnet run" to start up the bangazon api
1. wait for the program to start.

## using swagger to access the api.
1. one the api is running in the terminal open up a browser window.
1. navigate to the following url
http://localhost:5000/swagger/
1. you will be presented with all options for the api.

# Accessing the Customer Resource

The customer resource is accessed by the following url /api/customer and supports the following VERBS

### GET
#### All Customers
The default URL /api/customer will return a list of ALL customers in the database.
#### Single Customer
The URL /api/customer/{id}  where {id} = the id number of the customer, will return the details for a single customer
#### inactive customers
The URL /api/customer/?active=false  will return a list of customers who have not placed an order.


### POST
Sending a POST request with the following object will create a NEW entry in the database
```
{
"firstName": <string>,
"lastName": <string>,
"lastActive": <string>
}
```
firstName = Customer First Name

lastName = Customer last name

lastActive = the date that the customer was last active in the system
### PUT
using the URL  API/Customer/{id}  Where ID = the id number of the customer you are updating
Sending a PUT request with the following object will update an EXISTING entry in the database.
```
 {
    "id": <int>,
    "firstName": <string>,
    "lastName": <string>,
    "lastActive": <string>
}
```
id = the customer id of the customer you wish to update, this must match the id in the URL

firstName = Customer First Name

lastName = Customer last name

lastActive = the date that the customer was last active in the system

# Accessing the Product Resource

The Product resource is accessed by the following url /api/product and supports the following VERBS

### GET
#### All Products
The default URL /api/product will return a list of ALL products in the database.
#### Single Product
The URL /api/product/{id}  where {id} = the id number of the product, will return the details for a single product

### POST
Sending a POST request with the following object will create a NEW entry in the database
```
{
"name": <string>,
"description": <string>,
"price": <int>,
"quantity": <int>,
"customerId": <int>
}
```
name = Product  Name

description = Product description

price = price of the product - NOTE - the price property is a integer with no decimal values.  10.99 would be represented by 1099

quantity = the quantity of the product available,

customerId - the int id of the customer that is selling the product

### PUT
Sending a PUT request with the following object will update an EXISTING entry in the database.
```
{
"id": <int>,
"name": <string>,
"description": <string>,
"price": <int>,
"quantity": <int>,
"customerId": <int>
}
```
id = the int id of the product

name = Product  Name

description = Product description

price = price of the product - NOTE - the price property is a integer with no decimal values.  10.99 would be represented by 1099

quantity = the quantity of the product available,

customerId - the int id of the customer that is selling the product

### DELETE
The URL /api/product/{id}  where {id} = the id number of the product, will revmove the product from the database

# Accessing the ProductType Resource

The ProductType resource is accessed by the following url /api/producttype and supports the following VERBS

### GET
#### All ProductTypes
The default URL /api/producttype will return a list of ALL product types in the database.
#### Single ProductTypes
The URL /api/producttype/{id}  where {id} = the id number of the producttype, will return the details for a single producttype

### POST
Sending a POST request with the following object will create a NEW entry in the database
```
{
"description": <string>,
}
```
description = ProductType description
### PUT
using the URL  API/Producttype/{id}  Where ID = the id number of the Product Type you are updating
Sending a PUT request with the following object will update an EXISTING entry in the database.
```
{
"id": <int>,
"description": <string>,
}
```
id = the int id of the producttype this must match the id in the URL

description = Product description

### DELETE
The URL /api/producttype/{id}  where {id} = the id number of the producttype, will revmove the producttype from the database (edited)

# Accessing the Department Resource

The Department resource is accessed by the following url /api/department and supports the following VERBS

### GET
#### All Department
The default URL /api/Department will return a list of ALL departments in the database.
#### Single Department
The URL /api/Department/{id}  where {id} = the id number of the Department, will return the details for a single Department

### POST
Sending a POST request with the following object will create a NEW entry in the databse
```
{
  "name": <string>,
  "budget": <int>
}
```
name = department name
### PUT
using the URL  API/Department/{id}  Where ID = the id number of the Department you are updating
Sending a PUT request with the following object will update an EXISTING entry in the database.
```
{
    "id": <int>,
  "name": <string>,
  "budget": <int>
}
```
id = the int id of the department, this must match the id in the URL

name = department name

budget = department budget expressed without commas or decimals i.e a budget of 85,000.00 would be 85000

# Accessing the Training Resource
The customer resource is accessed by the following url /training/customer and supports the following VERBS
### GET
#### All Customers
The default URL /api/training will return a list of ALL training programs in the database.
#### Single Customer
The URL /api/training/{id} where {id} = the id number of the customer, will return the details for a single training program
### POST
Sending a POST request with the following object will create a NEW entry in the database
```
{
"name": <string>,
"capacity": <int>,
"start": <string>,
"end": <string>
}
```

name = Training program's name

capacity= Employee attendee limit

start = Date when the training program begins

end = Date when the training program ends

### PUT
using the URL  API/Training/{id}  Where ID = the id number of the training program you are updating
Sending a PUT request with the following object will update an EXISTING entry in the database.
```
{
"id": <int>,
"name": <string>,
"capacity": int,
"start": <string>,
"end" : <string>
}
```
id = the id of the training program you wish to update, this must match the id in the URL

name = Training program's name

capacity= Employee attendee limit

start = Date when the training program begins


### DELETE

Sending a DELETE request from the URL /api/training/{id} where {id} = the id number of the training program. Send a DELETE request to the url above where the id = 6
A 400 response code will be returned, it is not possible to delete a program that has already occurred.
Send another request where the id corresponds to the training program POST request sent above, and see that it will return 200 indicating that it has been removed.

# Accessing the Computer Resource
The Computer resource is accessed by the following url /api/Computer and supports the following VERBS

### GET
#### All Computer
The default URL /api/Computer will return a list of ALL computers in the database.

#### Single Computer
The URL /api/Computer/{id} where {id} = the id number of the computer, will return the details for a single computer

### POST
Sending a POST request with the following object will create a NEW entry in the database

```
{
"decommissioned": <string>,
"purchased": <string>,
"serial": <string>
}
```
decommissioned = Date computer was decommissioned. May not be applicable. String format "mm/dd/yyyy"

purchased = Date computer was acquired.

serial = Serial Number/String

### PUT
using the URL  API/Computer/{id}  Where ID = the id number of the computer you are updating
Sending a PUT request with the following object will update an EXISTING entry in the database.
```
{
"id": int,
"decommissioned": <string>,
"purchased": <string>,
"serial": <string>
}
```
id = the int id of the computer, this must match with the id in the computer object

decommissioned = Date computer was decommissioned. May not be applicable. String format "mm/dd/yyyy"

purchased = Date computer was acquired.

serial = Serial Number/String

computerEmployee = id of Employee Assigned to Computer. This is a Join table


### DELETE
The URL /api/Computer/{id} where {id} = the id number of the computer, will remove the computer from the database

# Accessing the Employee Resource

The employee resource is accessed by the following url /api/employee and supports the following VERBS

### GET
#### All Employees
The default URL /api/employee will return a list of ALL employees in the database.
#### Single employee
The URL /api/employee/{id}  where {id} = the id number of the employee, will return the details for a single employee


### POST
Sending a POST request with the following object will create a NEW entry in the database
```
{
    "firstName": <string>,
    "lastName": <string>,
    "isSupervisor": <int>,
    "departmentId": <int>,
}
```
firstName = Employee First Name

lastName = Employee last name

isSupervisor = an integer value of either 0 or 1, where 0 = not a supervisor or 1 = is a supervisor

departmentId = an integer representing the id number of the department from the department resource
### PUT
using the URL  API/Employee/{id}  Where ID = the id number of the employee you are updating
Sending a PUT request with the following object will update an EXISTING entry in the database.
```
 {
    "id": <int>,
    "firstName": <string>,
    "lastName": <string>,
    "isSupervisor": <int>,
    "departmentId": <int>,
}
```
id = the id of the employee you wish to update, this must match with the id in the URL

firstName = employee First Name

isSupervisor = an integer value of either 0 or 1, where 0 = not a supervisor or 1 = is a supervisor

departmentId = an integer representing the id number of the department from the department resource

# Accessing the Orders Resource
The Order  resource is accessed by the following url /api/Orders and supports the following VERBS

### GET
#### All Orders
The default URL /api/Orders will return a list of ALL orders in the database.

#### Single Order
The URL /api/Orders/{id} where {id} = the id number of the order, will return the details for a single order

### POST
Sending a POST request with the following object will create a NEW entry in the database
```
{
"time": <string>,
"customerId": <int>,
"customer": <null>,
"paymentId": <int>,
"payment": <null>,
"productOrders": <null>
}
```
time = Date purchased. Can be null. String format "mm/dd/yyyy"

custmoerId = Id of Customer purchasing order.

customer = Foreign Key

paymentId = Id of payment used

payment = Foreign Key

productOrders = Join Table

#### PUT
using the URL  API/Orders/{id}  Where ID = the id number of the Order you are updating
Sending a PUT request with the following object will update an EXISTING entry in the database.
```
{
        "id": <int>,
        "time": <String>,
        "customerId": <int>,
        "customer": <null>,
        "paymentId": <int>
}
```
id = the int id of the order, this must match the id in the URL

time = Date purchased. Can be null. String format "mm/dd/yyyy"

custmoerId = Id of Customer purchasing order.

customer = Foreign Key

paymentId = Id of payment used



### DELETE
The URL /api/Orders/{id} where {id} = the id number of the order, will remove the order from the database

# Accessing the Payments Resource
The Order  resource is accessed by the following url /api/Orders and supports the following VERBS

### GET
#### All Payments
The default URL /api/Payment will return a list of ALL orders in the database.

#### Single Payment
The URL /api/Payment/{id} where {id} = the id number of the order, will return the details for a single order

### POST
Sending a POST request with the following object will create a NEW entry in the database
```
{
"accountNumber": <int>,
"customerId": <int>,
"paymentType": <int>,
}
```
accountNumber = the Account number

customerId = Id of Customer purchasing order.

paymentTypeId = Id of payment type used


#### PUT
using the URL  API/Payment/{id}  Where ID = the id number of the Order you are updating
Sending a PUT request with the following object will update an EXISTING entry in the database.
```
{
    "id": {id}
    "accountNumber": <int>,
    "customerId": <int>,
    "paymentType": <int>,
}
```
id = the int id of the order, this must match the id in the URL

accountNumber = the Account number

customerId = Id of Customer purchasing order.

paymentTypeId = Id of payment type used

### DELETE
The URL /api/Payment/{id} where {id} = the id number of the order, will remove the order from the database

# Accessing the PaymentType Resource
The Order  resource is accessed by the following url /api/Orders and supports the following VERBS

### GET
#### All PaymentType Types
The default URL /api/PaymentType will return a list of ALL orders in the database.

#### Single PaymentType Type
The URL /api/PaymentType/{id} where {id} = the id number of the order, will return the details for a single order

### POST
Sending a POST request with the following object will create a NEW entry in the database
```
{
"description": <string>
}
```
description = name of the payment type.


#### PUT
using the URL  API/PaymentType/{id}  Where ID = the id number of the Order you are updating
Sending a PUT request with the following object will update an EXISTING entry in the database.
```
{
    "id": {id},
    "description": <string>
}
```
id = the int id of the order, this must match the id in the URL

description = name of the payment type.



### DELETE
The URL /api/PaymentType/{id} where {id} = the id number of the order, will remove the order from the database

