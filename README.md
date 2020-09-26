# NoSQL Project Inholland 2.1

This repository contains the code for the NoSQL project for Inholland, second year, first quarter.

The solution consists of five projects, of which two are executables and three are class libraries.

* **UI** is the project that is responsible for serving the web application to users. It handles requests sent by web browsers and returns HTML.  
* **API** is the project responsible for handling API requests. It takes a requests, calls for a service and returns the result of that service to the caller. UI also calls the API for any back end logic.  
* **Services** is responsible for converting all database data to an acceptable format for the UI and API, as well as performing logic checks on the data going in and coming out.  
* **DataAccess** handles the connection to and from the database. In this project, it is a Mongo database.  
* **Models** contains all the classes represented as entities throughout the application.

To test the application, both the API and the UI need to run. By default, the UI binds itself to port 5000 (HTTPS 5001) and the API binds itself to port 3000 (HTTPS 3001).

In Rider, create a Compound run configuration. The API is configured to not start the browser on execution, so just add both the API and UI and you're good to go.

In Visual Studio, go to the Solution's properties > Common Properties > Startup Project. By default, a Single startup project is selected. Change it to Multiple startup projects, and check both UI and API to start running.