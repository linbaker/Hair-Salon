# _Hair Salon_

https://github.com/linbaker/Hair-Salon

#### _C# Database Exercise for Epicodus, 05.10.2019_

#### By _**Lindsey Baker**_

## Description

_This application will allow a user to input stylist information, client information and see which clients belong to which stylist. User will be able to add, delete and edit both client and stylist information._


|Behavior|Input|Output|
|-|-|-|
|Input single word to compare to single word not matching, count remains zero |"hello", "goodbye"| 0 |
|Input single word to compare to single word identical matching, counts increases to 1 |"hello", "hello"| 1 |
|Input single word to compare to single word identical matching regardless of case, counts increases to 1 |"hello", "HeLlO"| 1 |
|Input single word to compare to multiple words, count increases for every match |"hello", "HeLlO world I said hello"| 2 |
|Input single word to compare to multiple words with period at the end of sentence, count increases for every match |"hello", "HeLlO world I said hello hello."| 3 |
|Input single word to compare to multiple words with punctuation, count increases for every match |"cat", "Cat, the cat, thought 'I am the best cat!'""| 3 |
|Input single word to compare to multiple words with punctuation, count increases for every match |"good-bye", "I said 'Good-bye' waving good-bye"| 2 |


## Setup/Installation Requirements

* _Clone Repository_
* _To create your own Database, launch MAMP application and select 'Start Sever'_
* _Using MySql in terminal, create database using the following commands:
> CREATE DATABASE lindsey_baker;
> USE lindsey_baker;
> CREATE TABLE stylists (id serial PRIMARY KEY, first_name VARCHAR(255), last_name VARCHAR(255));
> CREATE TABLE clients (id serial PRIMARY KEY, first_name VARCHAR(255), last_name VARCHAR(255), client_since DATETIME, stylist_id INT);_
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
