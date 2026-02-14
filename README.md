## Task Description:

You need to create an ASP.NET Core MVC application for uploading and displaying weather archives for the city of Moscow. It should consist of three pages:

1.  **Home Page** with a menu containing two items:
    a. View weather archives for Moscow
    b. Upload weather archives for Moscow
2.  **Weather Archives View Page** for Moscow. This page must include pagination and the ability to view weather conditions by:
    a. Month
    b. Year
3.  **Weather Archives Upload Page** for Moscow. On this page, you can upload weather archives for Moscow. A weather archive is an Excel file. After uploading, it must be parsed and loaded into a database for subsequent display on page 2. You can upload either a single Excel file or multiple files at once. If an Excel file cannot be parsed, the application should not crash.
4.  Deploy the test project to one of the following platforms: Github, GitFlic, or Gitlab.

## Comments:

1.  It is recommended to use **NPOI** as the library for working with Excel files.
2.  **Entity Framework Core** can be used as the ORM for database operations.
3.  The database must be **MSSQL Server 2008** or higher, or **PostgreSQL 9** or higher.
4.  Weather archives for the last 4 years are attached to this assignment (File name: `Weather.Moscow.2010-2014`).
