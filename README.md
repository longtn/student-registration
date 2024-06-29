# Student Registration Demo
Asp.Net MVC 5
.NET Framework 4.8

## Preview
1. Home page
   
![image](https://github.com/longtn/student-registration/assets/56600830/54c28c52-de72-4184-9e90-6b749d5a65b5)


3. Students list
   
![image](https://github.com/longtn/student-registration/assets/56600830/8a2c4157-8148-4159-a9bf-b8c46b4a5f57)

5. Create & Edit
   
![image](https://github.com/longtn/student-registration/assets/56600830/28f65200-bd4f-4412-9254-9348d05ec9c9)

7. Delete
   
![image](https://github.com/longtn/student-registration/assets/56600830/abe8d605-8daf-4891-97b6-7cbb8254150a)


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


## Database: EF local DB code first
1. Open the .sln file with Visual Studio
2. Rebuild the solution
3. Open Package Manager Console with project StudentRegistration.Core
4. Run the command
```bash
Update-Database -verbose
```
_If you want to use MSSQLS, please update connectionStrings in Web.config before run the command_

![image](https://github.com/longtn/student-registration/assets/56600830/86093027-d00b-4897-940a-76f30ff46d1f)


## Log Files
~\StudentRegistration.App\bin\Logs
![image](https://github.com/longtn/student-registration/assets/56600830/548d6c94-7332-43ed-b0d4-6e8884ba1f0a)


Thanks.
