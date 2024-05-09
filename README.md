# InsuranceManagerCLI

The application showcases the Insurance System CLI, which communicates with a database using Entity Framework Core with SQLite as the provider. Users can perform various operations such as CRUD, filtering, or exporting entities to a JSON file. The relationships between models are depicted in the ERD diagram below. Detailed instructions are included within the application.

To successfully run the app, you must have the following NuGet packages installed:
  * Microsoft.EntityFrameworkCore
  
  * Microsoft.EntityFrameworkCore.Proxies
  
  * Microsoft.EntityFrameworkCore.Sqlite
  
  * Microsoft.EntityFrameworkCore.Tools
    
After installing the necessary packages, you must open the Package Manager Console and type "add-migration [arbitrary_name]" to set up the database. Afterward, you can run the application.

![image](https://github.com/skabicek/InsuranceManagerCLI/assets/167412527/7565302d-e322-41fc-8319-cfd7479b8603)
