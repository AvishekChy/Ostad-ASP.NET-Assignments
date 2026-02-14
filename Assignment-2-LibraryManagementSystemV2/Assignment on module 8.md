#### **Assignment on module 8 (Exam week - 2)**


✅ Design and implement a small library management system using object-oriented principles in C#.


**Requirements:**


✅ 1. The system **should distinguish** between **at least three types of items** that can be borrowed:


&nbsp;  ✅ "**Books**" (regular books)


&nbsp;  ✅ "**Magazines**" (have issue number and publication month)


&nbsp;  ✅ "**Audiobooks**" (have narrator name and duration in minutes)


✅ 2. Every borrowable item must have:


&nbsp;  ✅ Unique identifier (string or int – your choice)


&nbsp;  ✅ Title


&nbsp;  ✅ Publication year


&nbsp;  ✅ Current status (Available / Borrowed / Reserved / Damaged)


&nbsp;  ✅ Maximum borrowing days (different defaults per type)


✅ 3. The system should support Library Members with two main categories:


&nbsp;  ✅ "**RegularMember**" (can borrow up to 5 items at once, standard loan period)


&nbsp;  ✅ "**PremiumMember**" (can borrow up to 12 items, longer loan period, can make reservations)


✅ 4. Implement a "**Loan**" concept that connects a member with an item, including:


&nbsp;  ✅ Borrow date


&nbsp;  ✅ Due date


&nbsp;  ✅ Return date (null if not returned)


&nbsp;  ✅ Possibility to calculate fine (if returned late)


✅ 5. Create a central "**Library**" class that can:


&nbsp;  ✅ Add new items


&nbsp;  ✅ Register new members


&nbsp;  ✅ Borrow an item (with all necessary checks)


&nbsp;  ✅ Return an item


&nbsp;  ✅ Renew a loan (only once per loan, extends due date)


&nbsp;  ✅ List all overdue loans


&nbsp;  ✅ Find items by title (partial match)


**Requirements & Constraints (must follow):**


&nbsp;  ✅ Use interfaces appropriately (at minimum one for borrowable items)


&nbsp;  ✅ Use proper encapsulation — most fields must be private/protected


&nbsp;  ✅ Prefer composition over deep inheritance where it makes sense


&nbsp;  ✅ Implement polymorphism meaningfully (at least 3 places)


&nbsp;  ✅ Use properties correctly (get/set with validation where appropriate)


&nbsp;  ✅ Include proper input validation (no negative durations, no future publication years, etc.)


&nbsp;  ✅ Throw meaningful custom exceptions when business rules are violated (at least two custom exception types)


&nbsp;  ✅ All dates should use 'DateOnly' or 'DateTime' consistently (your choice)


&nbsp;  ✅ Fine calculation: $1.5 per day overdue (same for all item types)


**Minimum Classes / Interfaces You Should Have:**


&nbsp;  ✅ 'ILoanable' (or 'IBorrowable') interface


&nbsp;  ✅ 'LibraryItem' (abstract base class)


&nbsp;  ✅ 'Book', 'Magazine', 'Audiobook' classes


&nbsp;  ✅ 'LibraryMember' (abstract base class)


&nbsp;  ✅ 'RegularMember', 'PremiumMember' classes


&nbsp;  ✅ 'Loan' class


&nbsp;  ✅ 'Library' class (main coordinator)


&nbsp;  ✅ 'OverdueLoanInfo' (simple DTO / record for reporting)


&nbsp;  ✅ At least two custom exceptions (e.g. 'CannotBorrowException', 'MaximumItemsReachedException')


**In the "Main" method (Demonstration):**


&nbsp;  ✅ Create library


&nbsp;  ✅ Add 6 different items (at least one of each type)


&nbsp;  ✅ Register 3 members (at least one Premium)


&nbsp;  ✅ Perform 7–8 borrow/return/renew operations (some should fail)


&nbsp;  ✅ Show all overdue items at the end


&nbsp;  ✅ Print nice summary using ToString() overrides


**Bonus Points (Optional):**


&nbsp;  ✅ Implement simple reservation queue (first-come-first-served)


&nbsp;  ✅ Add late return blocking — member cannot borrow if they have overdue items


&nbsp;  ✅ Implement search by author/narrator (for books and audiobooks)


&nbsp;  ✅ Add item condition enum (New, Good, Worn, Damaged) + damage reporting


**Guidelines: Submit the github link to the entire project.**
