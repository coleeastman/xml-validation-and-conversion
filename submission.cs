using System;
using System.Xml;
using System.Xml.Schema;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;

/**
 * This template file is created for ASU CSE445 Distributed SW Dev Assignment 4.
 * Please do not modify or delete any existing class/variable/method names. However, you can add more variables and functions.
 * Uploading this file directly will not pass the autograder's compilation check, resulting in a grade of 0.
 * **/

namespace ConsoleApp1
{
    public class Program
    {
        public static string xmlURL = "https://www.public.asu.edu/~ceastma4/Hotels.xml";
        public static string xmlErrorURL = "https://www.public.asu.edu/~ceastma4/HotelsErrors.xml";
        public static string xsdURL = "https://www.public.asu.edu/~ceastma4/Hotels.xsd";

        public static void Main(string[] args)
        {
            string result = Verification(xmlURL, xsdURL);
            Console.WriteLine(result);

            result = Verification(xmlErrorURL, xsdURL);
            Console.WriteLine(result);

            result = Xml2Json(xmlURL);
            Console.WriteLine(result);
        }
        
        // Q2.1

        public static string Verification(string xmlUrl, string xsdUrl)
        {
            string errorMessage = "No Error";

            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema; // configures xml reader settings to validate xml file against xsd file

                using (var client = new HttpClient()) // to make http request to web server
                using (Stream xsdStream = client.GetStreamAsync(xsdUrl).Result) // xsd from url converted to a stream
                {
                    XmlSchema schema = XmlSchema.Read(xsdStream, (sender, e) => // load into schema object from stream
                    {
                        errorMessage = e.Message; // capture validation error message from schema read
                    });

                    if (schema != null)
                    {
                        settings.Schemas.Add(schema); // add loaded schema to settings for validation
                    }
                }

                settings.ValidationEventHandler += (sender, e) => // event handler for validation errors when reading xml file
                {
                    if (e.Severity == XmlSeverityType.Error)
                    {
                        errorMessage = e.Message;
                    }
                };

                using (var client = new HttpClient()) // new http client to fetch the xml file
                using (Stream xmlStream = client.GetStreamAsync(xmlUrl).Result) // fetch xml from url as stream
                using (XmlReader reader = XmlReader.Create(xmlStream, settings)) // create xml reader with validation settings
                {
                    while (reader.Read()) ; // read through xml document to trigger validation
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return errorMessage;
        }




        // Q2.2
        public static string Xml2Json(string xmlUrl)
        {
            string jsonText = "";

            try
            {
                using (var client = new HttpClient()) // http client to make request to fetch xml file
                using (Stream xmlStream = client.GetStreamAsync(xmlUrl).Result) // fetch xml data from url as stream
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlStream); // load xml data into xml document

                    jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented); // convert xml to formatted json string

                    var testDeserialize = JsonConvert.DeserializeObject(jsonText); // test if json is deserializable
                }
            }
            catch (Exception ex)
            {
                jsonText = $"Error: {ex.Message}"; 
            }

            return jsonText;
        }




    }
}
