# Employee Task Management System

A Windows Forms-based desktop application designed to manage employees, tasks, departments, notifications, attendance, and login history efficiently. The system supports both administrative and employee-level interactions, improving task assignment and monitoring within an organization.

---

## ✨ Features

* **Employee Management**: Add, edit, delete employee details.
* **Project Management**: Create and manage multiple projects.
* **Task Management**: Assign and track tasks linked to projects and employees.
* **Department Module**: Categorize employees under departments.
* **Attendance Tracking**: Mark and view employee attendance records.
* **Login History**: Track login times for security auditing.
* **Notifications**: Send and manage internal notifications.
* **Task Comments**: Enable employees to comment on their tasks.
* **Secure Login System**: Authentication for admin and employees.

---

## ⚖️ Technologies Used

* **Programming Language**: C#
* **Framework**: .NET 7.0 (Windows Forms)
* **Database**: PostgreSQL
* **ORM**: Npgsql
* **IDE**: Visual Studio

---

## 📂 Project Structure

* `EmployeeTaskManagmentSystem/`

  * `.cs` and `.Designer.cs` files for each Form
  * `EmployeeDB.sql`: Database schema
  * `Program.cs`: Entry point
  * `*.resx`: UI resource files
* `User_doc.docx`: User documentation
* `SRS.docx`: Software Requirements Specification
* `ER diagram.png`: Entity-Relationship Diagram

---

## 📆 Database Overview

* **Tables:** Employees, Departments, Projects, Tasks, TaskComments, Attendance, Notifications, LoginHistory
* **ER Diagram:** Available in `ER diagram.png`
* **SQL File:** `EmployeeDB.sql` for creating the required schema

---

## ⚙️ Setup Instructions

1. **Clone or Download the Repository**
2. **Open in Visual Studio**: Open `EmployeeTaskManagmentSystem.sln`
3. **Restore NuGet Packages**: If prompted
4. **Setup Database**:

   * Open PostgreSQL using pgAdmin or another tool
   * Execute `EmployeeDB.sql` to create tables
   * Update connection string in code if necessary
5. **Build and Run the Project**

---

## 👤 Author

* **Sohibjon**
  Software Engineering Student
  For project documentation and SRS, refer to `Sohibjon-SRS.docx` and `User_doc.docx`
  You can look `User_doc.docx` for visual review

---

## ✅ Status

✅ Fully Functional Desktop Application with Database Integration
⏳ Further enhancements: reporting features, role-based permissions, dashboard analytics

---

## 🔗 License

*This project is academic and free to use for learning and development purposes.*
