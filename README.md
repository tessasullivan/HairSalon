# Hair Salon

#### An application which allows salon employees to manage sylists and clients.

#### By **Tessa Sullivan**

## Description
This application will allow salon employees to manage the salon's stylists and clients.


### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| Home page allows employee to go to page with all stylists and to a page to add stylist | Opens localhost:5000 in browser | Information about the salon appears along with navbar to functionality|
| An employee can see the details of a specific stylist | Clicks on stylist's name | A list of their clients appears |
| An employee can see the details of a specific client | Clicks on stylist's name and then a client's name | Details of that specific client appears |
| An employee can add a stylist | | A form appears to allow them to enter stylist information | 
| An employee adds a stylist | Fills out information and selects 'Add Stylist' | Home page loads with new stylist added to the stylist list |
| An employee can add a client | Clicks on a stylist's name and selects 'Add a client' | A form appears to allow them to enter client information | 
| An employee adds a client | Fills out information and selects 'Add client'| The stylist's page appears with new client added to their client list |
| An employee cannot add a client if no stylists are in the system


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
* 

## Technologies Used

* C#
* HTML / CSS

## Support and contact details

_Contact Tessa Sullivan @ tessa.sullivan@gmail.com_

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2019 **_Tessa Sullivan_**