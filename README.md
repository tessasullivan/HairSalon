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
| An employee can see the details of a specific client | Clicks on stylist's name and then a client's name | Details of that specific client appear |
| An employee can add a stylist | | A form appears to allow them to enter stylist information | 
| An employee adds a stylist | Fills out information and selects 'Add Stylist' | Home page loads with new stylist added to the stylist list |
| An employee can add a client | Clicks on a stylist's name and selects 'Add a client' | A form appears to allow them to enter client information | 
| An employee adds a client | Fills out information and selects 'Add client'| The stylist's page appears with new client added to their client list |
| An employee can edit a stylist | From the stylists' page, click the stylist name and then Edit | A form appears to allow them to edit the stylist's information|
| An employee edits a stylist | After filling out the edit form, click Update | The list of stylists appears with the specific stylist's edited information |
| An employee can delete a stylist | From the stylists' page, click the stylist name and then Delete | A page displays asking if the employee wants to delete stylist and all associated clients|
| An employee deletes stylist and their clients | Employee hits Delete on the confirmation page | The stylist and associated clients are deleted and the page listing all stylists is displayed |
| An employee can add specialties | Fills out form and selects 'Add' | The list of specialties is displayed with the added specialty|
| An employee can see the details of a specialty | Clicks the Specialties link in the nav bar | The specialty is displayed with all associated stylists|
| An employee can add stylists to a specialty | Clicks the Specialties link and then specifc specialty, selects a stylist and then 'Add'| The specialty is displayed with the added stylist listed |
| An employee can edit a specialty | Clicks the Specialties link, then the specifc specialty and Edit, makes changes and then Update | The list of specialties is displayed with the changed speciality|
| An employee can delete a specialty | Clicks the Specialties link, then the specifc specialty and Delete, and confirms deletion | The list of specialties is displayed with the deleted one no longer included | 
| An employee cannot add a client if no stylists are in the system|


## Setup/Installation Requirements


1. Clone this repository.
2. Install .Net 2.2 
    * Go to https://dotnet.microsoft.com/download/dotnet-core/2.2 and download the appropriate installer for your OS.
3. cd to HairSalon and run dotnet restore.
4. cd to HairSalon.Tests and run dotnet restore (optional).
5. Install and configure MySQL - MAMP is recommended.
6. Run MySQL in the terminal with user root.  If no special password has been added to root, the command is 'mysql -uroot -proot'
7. Create the database and their tables.  You can either 
  a. Import the tessa_sullilvan.sql and tessa_sullivan_test.sql files located in the repository's main directory by running 'source <file>' (this method includes sample data) or importing the file through phpMyAdmin.
  or 
  b. Run the following commands:
    ```CREATE DATABASE IF NOT EXISTS `tessa_sullivan`;  
    USE `tessa_sullivan`;   
    CREATE TABLE `clients` (  
      `id` int(11) NOT NULL AUTO_INCREMENT,
      `first_name` varchar(255) NOT NULL,
      `last_name` varchar(255) NOT NULL,
      `phone_number` varchar(255) NOT NULL,
      `notes` varchar(500) NOT NULL,
      `stylist_id` int(11) NOT NULL,  
      PRIMARY KEY (id))
      ENGINE=InnoDB DEFAULT CHARSET=utf8;
    CREATE TABLE `specialties` (
      `id` int(11) NOT NULL AUTO_INCREMENT,
      `specialty` varchar(255) NOT NULL,
      PRIMARY KEY (id));
    CREATE TABLE `specialties_stylists` (
      `id` int(11) NOT NULL AUTO_INCREMENT,
      `specialty_id` int(11) NOT NULL,
      `stylist_id` int(11) NOT NULL,
      PRIMARY KEY (id))
      ENGINE=InnoDB DEFAULT CHARSET=utf8;
    CREATE TABLE `stylists` (
      `id` int(11) NOT NULL AUTO_INCREMENT,
      `first_name` varchar(255) NOT NULL,
      `last_name` varchar(255) NOT NULL,
      `phone_number` varchar(255) NOT NULL, 
      PRIMARY KEY (id))
      ENGINE=InnoDB DEFAULT CHARSET=utf8;```

    ```CREATE DATABASE IF NOT EXISTS `tessa_sullivan_test`;
    USE `tessa_sullivan_test`;
    CREATE TABLE `clients` (
      `id` int(11) NOT NULL AUTO_INCREMENT,
      `first_name` varchar(255) NOT NULL,
      `last_name` varchar(255) NOT NULL,
      `phone_number` varchar(255) NOT NULL,
      `notes` varchar(500) NOT NULL,
      `stylist_id` int(11) NOT NULL,  
      PRIMARY KEY (id))
      ENGINE=InnoDB DEFAULT CHARSET=utf8;
    CREATE TABLE `specialties` (
      `id` int(11) NOT NULL AUTO_INCREMENT,
      `specialty` varchar(255) NOT NULL,
      PRIMARY KEY (id))
      ENGINE=InnoDB DEFAULT CHARSET=utf8;
    CREATE TABLE `specialties_stylists` (
      `id` int(11) NOT NULL AUTO_INCREMENT,
      `specialty_id` int(11) NOT NULL,
      `stylist_id` int(11) NOT NULL,
      PRIMARY KEY (id))
      ENGINE=InnoDB DEFAULT CHARSET=utf8;
    CREATE TABLE `stylists` (
      `id` int(11) NOT NULL AUTO_INCREMENT,
      `first_name` varchar(255) NOT NULL,
      `last_name` varchar(255) NOT NULL,
      `phone_number` varchar(255) NOT NULL, 
      PRIMARY KEY (id))
      ENGINE=InnoDB DEFAULT CHARSET=utf8;```

8. In the terminal,run: dotnet run --project HairSalon.
9. Load localhost:5000 in your web browser.


## Known Issues
* A stylist can be added multiple times to a specialty.
* A specialty can be added multiple times to a stylist.
* Currently, there is no way to switch a client to another stylist.

## Technologies Used

* C#
* HTML / CSS

## Support and contact details

_Contact Tessa Sullivan @ tessa.sullivan@gmail.com_

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2019 **_Tessa Sullivan_**
