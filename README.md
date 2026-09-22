# 🍽️ Restaurant Order System

Restaurant Order System is a console-based application developed in C# for managing a restaurant's menu and customer orders.

The application allows restaurant employees to manage menu items, create and cancel orders, search and filter menu items, and retrieve orders using different criteria such as date and price.

The project is built using a layered architecture with separate Entity, Data Access, Business and Presentation layers.

---

# 📌 Table of Contents

- [About the Project](#about-the-project)
- [Features](#features)
- [Technologies](#technologies)
- [Project Architecture](#project-architecture)
- [Project Structure](#project-structure)
- [Entities](#entities)
- [Enums](#enums)
- [Menu Operations](#menu-operations)
- [Order Operations](#order-operations)
- [Business Logic](#business-logic)
- [Database](#database)
- [Entity Framework Core](#entity-framework-core)
- [Migrations](#migrations)
- [Validation and Exceptions](#validation-and-exceptions)
- [How to Run](#how-to-run)
- [Console Application](#console-application)
- [Example](#example)
- [Git and GitHub](#git-and-github)
- [Future Improvements](#future-improvements)
- [Author](#author)

---

# 📖 About the Project

Restaurant Order System is designed to simplify the management of a restaurant's menu and orders.

The application provides two main sections:

1. **Menu Operations**
2. **Order Operations**

Through the console interface, the user can add, edit, delete, search and filter menu items.

The user can also create orders containing multiple menu items, calculate the total order amount, cancel orders and search for orders by different parameters.

The project uses **Entity Framework Core** to work with a SQL Server database.

---

# ✨ Features

## Menu Management

The application supports:

- Adding a new menu item
- Editing an existing menu item
- Removing a menu item
- Displaying all menu items
- Filtering menu items by category
- Filtering menu items by price range
- Searching menu items by name
- Checking for duplicate menu item names

## Order Management

The application supports:

- Creating a new order
- Adding multiple menu items to an order
- Setting quantity for each menu item
- Automatically calculating the total amount
- Cancelling an order
- Displaying all orders
- Searching orders by order number
- Filtering orders by date range
- Searching orders by exact date
- Filtering orders by total price range

---

# 🛠️ Technologies

The project uses the following technologies:

- **C#**
- **.NET**
- **Entity Framework Core**
- **SQL Server**
- **LINQ**
- **Git**
- **GitHub**
- **Visual Studio**

---

# 🏗️ Project Architecture

The application follows a layered architecture.

The project is divided into four main layers:

Presentation
     ↓
Business
     ↓
DataAccess
     ↓
Entity
