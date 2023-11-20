# C# Task for working in group

## Description of Task:

We have 2 static lists for Products and Users and our data should be stored in these lists.
Users should be of 2 types.
Admin and user
The user who is an Admin can create an admin as well as give an admin role to the user who is not an admin.
Login menu when the program starts:

1. Login
2. Registration

Register if the person running the program does not have an account.
User enters his first name, last name, login and password. The Login should be 3-16 in length.
The password must be 6-16 long, contain at least 1 uppercase, 1 lowercase letter and at least 1 digit.
After successful registration, the login menu is displayed again.
When we select login, we register username and password. If everything is marked correctly, the screen says “Welcome, Name Surname”.

User Menu if the incoming user is not admin:

1. See pizzas
2. Order now
it turns out options.
When selecting View pizzas,  Pizzas in the products list are showed in the following form:

- Id of pizza. Name of pizza

Then we enter the id of the pizza that we want to add to the basket:
When you press the S button, it adds the pizza to the basket.
It requires the number of pizzas added to the basket.
When you press the G key, the Products menu is called up.
The user menu is displayed when  0 button is pressed in the menu.
And when the order method works, the order price is displayed on the screen and a phone number with the delivery address are required.
If the person who is logged in is an admin, then in addition to the User Menu two more options are added:

3. Pizzas
4. Users
   
This options are for entering in a CRUD menu:

1. See all
2. Add
3. Edit (by Id) (users will simply change their role)
4. Delete (by Id)

CRUD menus for pizzas and users are displayed.

## How task was devided by this repo contributors:
 ### - Repository creation and management -> RockeyWereWolfCodeAcademy https://github.com/RockeyWereWolfCodeAcademy
 ### - Group lead -> RockeyWereWolfCodeAcademy https://github.com/RockeyWereWolfCodeAcademy
 - User Login/Registration -> RufatAzizov https://github.com/RufatAzizov
 - User menu -> ibadovadil https://github.com/ibadovadil
 - Admin and CRUD menus -> RockeyWereWolfCodeAcademy https://github.com/RockeyWereWolfCodeAcademy
 
