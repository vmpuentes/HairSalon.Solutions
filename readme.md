# HairSalon:C# Week 3 Project October 2017_

#### _ 10.27.17_

#### By _**Victor M. Puentes Jr.,**_

## Description

_An app for a hair salon that allows the owner to store information onto a database allowing them to add a list of the stylists, and for each stylist, add clients who see that stylist.

| Behavior  | Input  | Output  |
|---|---|---|
|1.Employee user lands on Homepage and is able to add a stylist to the database | Stylist Name | Stylist Name is appended on list |
|2. Employee user is able to click on Stylist Name and see stylist's details | click on name of Stylist | a list of that stylist's clients is appended |
|3. Employee user is able to add new stylists as needed to database | new stylist name is entered | new stylist name is appended. |
|4. Employee user is able to add new clients to a specific stylist. | Add Client button is entered | Client list is appended on stylist page. |
|5. Employee user is able to update a client's name to database. | Client name is clicked | text box appears for editing. |
|6. Employee user is able to delete a client if needed. | delete client button is enter under client details. | client is deleted from database. |

## Getting Started

May be deployed using git hub pages at  https://vmpuentes.github.io/Address_Book_oct_17/.

### Installation/Setup Requirements
1.This app may be cloned at  https://vmpuentes.github.com/HairSalon.Solutions/.
2. Set up .NET dependencies
3. Set up database with MAMP and create a database with these instructions...

> CREATE DATABASE hair_salon;
> USE hair_salon;
> CREATE TABLE stylist (id serial PRIMARY KEY, name VARCHAR(255), );
> CREATE TABLE clients (id serial PRIMARY KEY, description VARCHAR(255), stylist_id INT);


## Built With

* [C#](https://learnhowtoprogram.com/couses/c#)
* [HTML5](https://developer.mozilla.org/en-US/docs/Web/Guide/HTML/HTML5) - Used to contruct this webpage
* [CSS3](http://html.com/css/) - Used to style
* [Javascript] (https://www.javascript.com/) - Used for user interactives
* [Bootstrap](http://getbootstrap.com/) - CSS library used

## Authors

* **Victor M. Puentes Jr.** - *Initial work* - [github user name: vmpuentes](https://github.com/vmpuentes)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Epicodus (https://epicodus.com/)
* free Code Camp (https://freecodecamp.com/)
* Software Engineering Daily (https://softwareengineeringdaily.com/)
