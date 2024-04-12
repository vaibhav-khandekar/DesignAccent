##Steps to create API in C# application

- Visual Studio 2015 -> New Project -> ASP.Net Web Application -> Project_Name -> MVC -> WebAPI checkbox -> Ok

- Solution Explorer -> Add -> New Project -> search for class library Visual C#

Right Click on Solution in Solution Explorer 'Project_Name'
Add -> New Project -> Search for class library Visual C#
create 3 files with same process with following details
file 1 - Project_Name.BAL
file 2 - Project_Name.DAL
file 3 - Project_Name.DTO

Rename their .cs file with Project_Name

- Project_Name -> Controllers -> Right Click -> Add -> Controller -> MVC5 Controller Empty -> Add -> Rename with Project_NameController

Project_Name.DAL -> Add -> New Item -> Class -> Visual C# Items -> Rename BASE.cs -> Add public to the class
Project_Name.DAL -> Add -> New Item -> Class -> Visual C# Items -> Rename ErrorCode.cs -> Add public to the class
Project_Name.DAL -> Add -> New Item -> Class -> Visual C# Items -> Rename RequestResponseLog.cs -> Add public to the class

-> Project_Name is dependent on Project_Name.BAL, Project_Name.DAL and Project_Name.DTO
-> Project_Name.BAL is dependent on Project_Name.DAL and Project_Name.DTO
-> Project_Name.DAL is dependent on Project_Name>DTO
-> Project_Name.DTO is independent file

Project_Name
	-> Controller
		-> Project_NameController
	
	Solution
		Project_Name.BAL
		Project_Name.DAL -> BASE.cs
						 -> ErrorCode.cs
						 -> RequestResponseLog.cs
		Project_Name.DTO
		
