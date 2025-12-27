# Assignment 1: Library Management System

**Author:** Avishek Chowdhury  
**Course Module:** 4

## Overview
This console application simulates a basic library system. It creates a small inventory of books and magazines, displays their details, and demonstrates how borrowing an item changes its availability status. The project focuses on demonstrating key Object-Oriented Programming (OOP) principles in C#.

## Concepts Used
* **Inheritance:** Created a base class `LibraryItem` with common properties (`Title`, `ItemId`, `IsAvailable`) and two derived classes: `Book` (adds Author) and `Magazine` (adds IssueNumber).
* **Polymorphism:** Used `virtual` and `override` methods for `DisplayInfo()` to allow each class to print its specific details (e.g., Book prints Author, Magazine prints Issue Number).
* **Encapsulation:** Used C# Properties (`get; set;`) to protect and manage data within the classes.
* **Object Instantiation:** created specific instances of books ("The Great Gatsby", "Gitanjali") and a magazine to simulate a library inventory.

## How to Run
1.  Open the solution file in Visual Studio 2026.
2.  Press `F5` or click the **Run** button (Green Play icon).
3.  The console will appear, showing the initial catalog, the borrowing action, and the updated status of the items.

---
*Submitted as part of the ASP.NET course on Ostad.*