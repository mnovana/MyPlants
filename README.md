# My Plants

### Technologies

**Backend:** ASP.NET Core Web API  
**Database:** SQL Server with a code-first approach and seeded using Entity Framework Core  
**Auth:** JWT is retrieved from the Firebase through a login endpoint  
**Frontend:** React application with React Router DOM for routing, Redux for state management and Tailwind CSS for styling

### Configure Firebase

1. Create a new Firebase project
2. Add authentication with Email/Password as a sign-in method
3. Download the JSON file from: **Project Settings** > **Service Accounts** > **Generate New Private Key**
4. Rename this file to _"firebase.json"_ and move it to **MyPlants** > **backend** > **MyPlants**
5. Create a new .env file:  
   AUTHENTICATION_SIGNINURI=`https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=[API KEY]`  
   AUTHENTICATION_AUDIENCE=[PROJECT ID]  
   AUTHENTICATION_ISSUER=`https://securetoken.google.com/[PROJECT ID]`
6. Replace the placeholders with values from **Project Settings**:  
   [PROJECT ID] = Project ID  
   [API KEY] = Web API Key

### Use case diagram

![Use-Case-Diagram](usecase.png)

### Database

![Database](database.png)
