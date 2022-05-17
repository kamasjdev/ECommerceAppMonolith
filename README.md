# ECommerceAppMonolith
# Project
This project is based on existing solution ECommerceApp. For a better scalability and adding new features, it was decided to divide ECommerceApp into 5 modules: Contacts, Currencies, Items, Sales, Users. 
Every module has its own scheme in database. 
- Contacts module has information about customer. 
- Currencies cyclically downloads data from API NBP using custom background job. Every new rate publish new event.
- Items module stores data about items in ECommerceApp
- Sales based on the data of module Item shows which products is ordered or is in ItemCart. Additionally after add item to ItemCart the copy of Item is created as a snapshot in db. Module also responds to Currencies events especially on new currency rates events.
- Users stores information about permissions, role of users

Below shown db schemas of modules:

- Contacts 

![](https://raw.githubusercontent.com/kamasjdev/ECommerceAppMonolith/main/contacts_diagram.png)

- Currencies

![](https://raw.githubusercontent.com/kamasjdev/ECommerceAppMonolith/main/currencies_diagram.png)

- Items

![](https://raw.githubusercontent.com/kamasjdev/ECommerceAppMonolith/main/items_diagram.png)

- Sales

![](https://raw.githubusercontent.com/kamasjdev/ECommerceAppMonolith/main/sales_diagram.png)

- Users

![](https://raw.githubusercontent.com/kamasjdev/ECommerceAppMonolith/main/users_diagram.png)