# Habitos

**Habitos** — это веб-приложение для отслеживания прогресса в формировании полезных привычек.  
Пользователь может создавать привычки (например, «чистить зубы два раза в день»), отмечать выполнение и анализировать статистику.

---

## Features
- User registration and authentication (email + password)  
- Habit management (create, archive, update, delete)  
- Track daily habit completions  
- View statistics (weekly / monthly progress)  
- Passwords stored securely (BCrypt hashing)  
- Data persistence via **PostgreSQL**  

---

## Tech Stack
- **Backend:** ASP.NET Core Web API  
- **Frontend:** React  
- **Database:** PostgreSQL  
- **ORM:** Entity Framework Core  
- **Security:** BCrypt.Net for password hashing  

---

## User Interface
Users interact with the system via a modern web browser.  

Main screens:
1. **Registration / Login page**  
2. **Main habits list** (active and archived habits)  
3. **Habit statistics page** (marked days, progress over period)  

**Example flow:**  
User clicks *“Mark habit as done”* → system saves a `HabitEntry` and updates the completion counter for the day.

---

## Target Users
- Young people (16–35) interested in self-development  
- Education level: average and above  
- Technical skills: basic (able to use browsers / apps)  
- **Administrator role:** extended rights (user management, moderation)  

---

## Assumptions & Dependencies
- Requires stable internet connection  
- Works on modern browsers (Chrome, Firefox, Edge)  
- EF Core / PostgreSQL updates may require config adjustments  
- Future iterations may add notifications & integrations  

---

## Functional Requirements
1. User can register with email + password  
2. User can log in  
3. User can create habits (name, description, times per day)  
4. User can mark completions for specific days  
5. User can view list of habits (active / archived)  
6. User can archive a habit  
7. User can view statistics (weekly / monthly)  
8. Habit names must be unique per user  
9. Admin can manage users  

---

## Non-Functional Requirements

### Quality Attributes
- **Reliability** → data preserved even after server failures (>99.9% successful transactions)  
- **Security** → passwords stored as hashes, API only via HTTPS  
- **Scalability** → up to 10k concurrent users (validated by load testing)  
- **Usability** → intuitive interface, verified via UX testing  
- **Performance** → API response ≤ 500 ms for 95% of requests under normal load  

---

## Installation & Run
_(to be completed later with step-by-step instructions for backend, frontend, and database setup)_
