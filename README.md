# _Hair Salon_

https://github.com/linbaker/Hair-Salon

#### _C# Database Exercise for Epicodus, 05.17.2019_

#### By _**Lindsey Baker**_

## Description

_This application will allow a user to input stylist information, client information and see which clients belong to which stylist. User will be able to add, delete and edit both client and stylist information. User will be able to add specialties to stylists, many stylists may have the same specialty_


|Behavior|Input|Output|
|-|-|-|
|User is able to add and save stylist first and last name in database, and will be assigned a unique id |"Edward Scissorhands"| in table stylists: id = 0, first_name = "Edward", last_name = "Scissorhands"|
|User can view all stylists saved to database|"Edward Scissorhands", "Sweeney Todd"| "Edward Scissorhands", "Sweeney Todd" |
|User is able to navigate to specific stylist and add clients to specific to that stylist, including first and last name and date they first visited|navigate to "Sweeney Todd", add client "Mrs.", "Lovett", 2019/05/09| "Mrs. Lovett", Client Since: 2019/05/09, Stylist "Sweeney"|
|User is able to click on a stylist's name to see all clients for that stylist |navigate to "Sweeney Todd"|"Sweeney's Clients: Adolfo Pirelli, Mrs. Lovett"|
|User is able to navigate to specific client to see further information|"Mrs."| "Mrs. Lovett", Client Since: 2019/05/09, Stylist "Sweeney" |
|User is able to edit client information|"Adolfo Pirelli", Client Since: 2019/05/10, Stylist "Sweeney"|"RIP deceased", Client Since: 2019/05/09, Stylist "Sweeney"|
|User is able to delete clients|"RIP deceased", Client Since: 2019/05/09, Stylist "Sweeney"| - |
|User is able to delete stylists, which will delete all clients assigned to that stylist|"Sweeney Todd", Client "Mrs. Lovett"| - |


## Setup/Installation Requirements

* _Clone Repository_
* _To create your own Database, launch MAMP application and select 'Start Sever'_
* _Using MySql in terminal, create database using the following commands:_
> CREATE DATABASE lindsey_baker;
> USE lindsey_baker;
> CREATE TABLE stylists (id serial PRIMARY KEY, first_name VARCHAR(255), last_name VARCHAR(255));
> CREATE TABLE clients (id serial PRIMARY KEY, first_name VARCHAR(255), last_name VARCHAR(255), client_since DATETIME, stylist_id INT);
Alternately, if you wish to download the existing database for this project, in phpMyAdmin, select the import tab and import the database lindsey_baker from the cloned repository file
* _Compile in C# .Net Core 2.2_
* _Run program and view on localhost:5000_


## Known Bugs


## Support and contact details

_Please contact me with any questions, ideas or concerns at lindseybaker0@gmail.com_

## Technologies Used

_C# .NET Core 2.2_
_MAMP_
_MySql_
_phpMyAdmin_


### License

*This software is licensed under the MIT license.*
Copyright (c) 2019 **Lindsey Baker**
