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

Clone Application
1. git clone https://github.com/coleeastman/xml-validation-and-conversion.git

Change Directory
2. cd xml-validation-and-conversion

Build and run the application:

3. dotnet build
4. dotnet run
