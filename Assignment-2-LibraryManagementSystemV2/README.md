# Assignment 2: Library Management System V2

**Author:** Avishek Chowdhury  
**Course Module:** 8

## Overview
This enhanced console application significantly expands the library system with more complex features and robust object-oriented design. It introduces multiple item types (Books, Magazines, Audiobooks), distinct member categories (Regular, Premium), and a comprehensive loan management system. The project focuses on advanced OOP concepts, including interfaces, abstract classes, and custom exception handling in C#.

## Concepts Used
* **Interfaces:** Implemented `ILoanable` (or similar) to define standardized behavior for borrowable items.
* **Abstract Classes:** utilized `LibraryItem` and `LibraryMember` as base classes to share common logic while enforcing specific implementations in derived classes.
* **Polymorphism:** Leveraged method overriding to provide type-specific behavior for `DisplayInfo()`, loan calculations, and validation rules.
* **Encapsulation:** Applied strict access control with private fields and public properties, ensuring data integrity through validation logic.
* **Custom Exceptions:** Created specific exception types (e.g., `CannotBorrowException`, `MaximumItemsReachedException`) to handle business rule violations gracefully.
* **Composition:** Designed a `Library` class that manages collections of items and members, demonstrating composition over deep inheritance.
* **Date Handling:** Used `DateTime` or `DateOnly` for precise tracking of borrow dates, due dates, and overdue calculations.

## How to Run
1.  Open the solution file in Visual Studio.
2.  Set the **Assignment-2-LibraryManagementSystemV2** project as the startup project.
3.  Press `F5` or click the **Run** button (Green Play icon).
4.  The console will run a demonstration sequence:
    *   Initializing the library with items and members.
    *   Performing borrow, return, and renewal operations.
    *   Displaying overdue reports and final system state.

---
*Submitted as part of the ASP.NET course on Ostad.*
