# Tele



AUTHENTICATION AND AUTHORIZATION PROCESS MANAGEMENT
Have to design a portal for below roles
1. Admin
2. Supervisor
3. Agent
ARCHITECTURE 
1. API to get data
a. SQL Server as backend application
2. ASP.NET MVC to display data
MODULES
1. Display list of user
a. Admin can view all type of register users
b. Supervisor can view only registered Supervisor & Agents
c. Agents can only view his/her profile
i. Display full information as below user profile module
ii. Status:
1. Active 
2. Inactive
a. Admin & Supervisor both can mark user Active or Update 
Inactive
2. User Profile
a. Full Name
b. Email
i. Admin only can update 
c. Phone 
i. Admin only can update
d. Communication Address
i. Admin only can update
e. Status
i. Active (default)
ii. Inactive
3. Bulk user upload 
a. Must have an option to upload data from csv file 
4. Registration
a. User profile module itself works as registration module

Automatically username and password need to set as per their mail
1. Restriction on duplicate username / password
DEVELOPMENT GUIDELINES
1. Bootstrap enables (v 4.0)
2. Follow oops concepts
a. Including major pillar of the oops
3. Store procedure as backend application 
4. Must have to implement Authentication and Authorization process to validate module 
5. Will be an value added if work on generic process development
6. Push code on GitHub
a. Must have to compile & run whenever download from repository
