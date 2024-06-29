# Student Registration Demo
Asp.Net MVC 5 
.NET Framework 4.8


## Preview
1. **Home page**
   
![image](https://github.com/longtn/student-registration/assets/56600830/ff38c230-d7f2-4231-9118-09dac72f9fe1)


2. **Students list**
   
![image](https://github.com/longtn/student-registration/assets/56600830/d9f9d1d2-d7a1-4d4a-979a-6f8dab7fd163)


3. **Create & Edit**
   
![image](https://github.com/longtn/student-registration/assets/56600830/0363424f-acdb-4541-b743-5c485231229c)


4. **Delete**
   
![image](https://github.com/longtn/student-registration/assets/56600830/096e7030-f7c0-4611-b6c4-b1ccd35c0f22)


## Download
```bash
https://github.com/longtn/student-registration.git
```


## Nuget Packages
- EntityFramework 6.4.4
- AutoMapper 10.1.1
- Unity.Mvc5 1.4.0
- Serilog 4.0.0
- Serilog.Sinks.File 6.0.0


## Project
![image](https://github.com/longtn/student-registration/assets/56600830/0c9f22d3-d29c-4d70-94c2-790b8e48501b)


## Scalability
For scalability, it's best practice to follow the [Clean Architecture](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures) approach:
- Separate repositories and EF into the Infrastructure layer.
- Optionally, separate the implementation of the core into an application layer.

![image](https://github.com/longtn/student-registration/assets/56600830/dd26bd54-b0ca-4c87-a5e4-134ce6299c18)


## Database: EF local DB code first
> 1. Open the .sln file with Visual Studio
> 2. Rebuild the solution
> 3. Open Package Manager Console with project StudentRegistration.Core
> 4. Run the command
```bash
Update-Database -verbose
```
_If you want to use MSSQLS, please update **connectionStrings** in Web.config before run the command_

![image](https://github.com/longtn/student-registration/assets/56600830/86093027-d00b-4897-940a-76f30ff46d1f)


## Log Files
~\StudentRegistration.App\bin\Logs
![image](https://github.com/longtn/student-registration/assets/56600830/548d6c94-7332-43ed-b0d4-6e8884ba1f0a)


---
Thanks.
