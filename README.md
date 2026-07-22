**Contact Manager (Console Application)**



**Overview**



Contact Manager is a console-based application developed using C# that allows users to manage their contacts efficiently. The application follows a 3-Layer Architecture consisting of View, Service, and Repository layers to ensure separation of concerns and maintainable code.



---



**Features**



- Add a new contact

- Edit an existing contact

- Delete a contact

- Search a contact using its unique ID

- Display all contacts

- Support multiple phone numbers for a contact

- Support multiple email IDs for a contact

- Automatically generate a unique GUID for every contact



---






**Project Structure**



ContactsManager

│

├── Models

│   └── Contact.cs

│

├── Repository

│   └── ContactRepository.cs

│

├── Service

│   └── ContactService.cs

│

├── View

│   └── ContactView.cs

│

├── Program.cs

│

└── README.md



---









**Contact Model**



**Each contact contains:**



- GUID (Unique Identifier)

- Name

- Multiple Phone Numbers

- Multiple Email IDs



---



**Functionalities**



**Add Contact**



Creates a new contact with:



- Auto-generated GUID

- Name

- One or more phone numbers

- One or more email IDs







**Edit Contact**



Updates an existing contact using its GUID.







**Delete Contact**



Removes a contact using its GUID.







**Search Contact**



Searches for a contact using its GUID and displays all details.







**Display All Contacts**



Displays every contact stored in the application.



---







**Design Principles**



- Three-layer architecture

- Separation of concerns

- Modular and maintainable code

- Simple and user-friendly console interface

- Automatic GUID generation for unique contact identification



---






---


