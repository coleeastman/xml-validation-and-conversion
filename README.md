# XML Validation and Conversion

This project provides functionality for validating XML files against an XSD schema and converting XML data to JSON format. The application fetches XML and XSD files from specified URLs and performs the following operations:

## Features

- **XML Validation**: Validates XML files against a provided XSD schema to ensure they conform to the defined structure and rules. If validation errors occur, descriptive error messages are returned.
- **XML to JSON Conversion**: Converts valid XML data into a JSON format, making it easier to work with in applications that prefer JSON over XML.

## Technologies Used

- C#
- .NET Framework
- XML
- JSON (via Newtonsoft.Json)
- HttpClient for HTTP requests

## How to Use

1. **Clone the Repository**  
   Clone the repository to your local machine:
   ```bash
   git clone https://github.com/coleeastman/xml-validation-and-conversion.git
2. **Navigate to the Project Directory**
   Change into the project directory:
    ```bash
    cd xml-validation-and-conversion

3. **Build the Application**
   ```bash
    dotnet build
   
4. **Run the Application
   Run the application:
   ```bash
   dotnet run
