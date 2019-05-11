# Hair Salon

#### An application which allows salon employees to manage sylists and clients.

#### By **Tessa Sullivan**

## Description
This application will allow salon employees to manage the salon's stylists and clients.


### Specs

User Stories
* As a salon employee, I need to be able to see a list of all our stylists.
* As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
* As an employee, I need to add new stylists to our system when they are hired.
* As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.



## Setup/Installation Requirements


1. Clone this repository.
2. Install .Net 2.2 
    * Go to https://dotnet.microsoft.com/download/dotnet-core/2.2 and download the appropriate installer for your OS.
3. cd to HairSalon and run dotnet restore.
4. cd to HairSalon.Tests and run dotnet restore (optional).
5. Install and configure MySQL - MAMP is recommended.
6. Run MySQL.
7. Import the tessa_sullilvan.sql and tessa_sullivan_test.sql files located in the repository's main directory into MySQL.
8. Run dotnet run --project HairSalon.
9. Load localhost:5000 in your web browser.


## Known Issues
* The page which gives details about a stylist's client list does not always list details.

## Technologies Used

* C#
* HTML / CSS

## Support and contact details

_Contact Tessa Sullivan @ tessa.sullivan@gmail.com_

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2019 **_Tessa Sullivan_**