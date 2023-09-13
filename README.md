# VehiChoice
VehiChoice is a multi-branch E-commerce car selling web application built using MVC in C#
# How it works
## Admin
Admin(seeded) logs in to create a branch and assign a branch head to the branch created instantly <br />
Admin has a wallet where all purchase made from any branch drops <br />
Admin has access to view all customers of every branch, view all cars sold and unsold
## Branch Head
Branch head logs in with the Admin given information to add a products in his branch(store) to the site for the customers to be able to view and purchase <br />
Branch Heads have access to see the number of cars sold and unsold in their various branchs, number of total cars so far both sold and unsold, number of customers in thier branch <br />
## Customer
Customers register and log in after to deposit money in his/her wallet to be able to purchase a product <br />
View all available cars <br />
Filter  the products available either by the Name e.g Camry, Brand e.g Toyota or Model e.g 2022, <br />
Make payment for purchase, <br />
Any sold car will still be visibility but with out of stock tag so will not be clickable for purchase

### Many more flexibilty will be seen when explored

# How to install
## Dotnet version => 7.0
## To install all the packages 
#dotnet restore
## OR install the following manually using nugget package
#Microsoft.EntityFrameworkCore Version=7.0.9 <br />
#Microsoft.EntityFrameworkCore.Tools Version=7.0.9 <br />
#Microsoft.VisualStudio.Web.CodeGeneration.Design Version=7.0.9 <br />
#MySql.Data Version=8.1.0 <br />
#MySql.EntityFrameworkCore Version=7.0.5
## To run
#dotnet run for visual Studio Code users <br />
#Start without debugging for Visual Studio Users
