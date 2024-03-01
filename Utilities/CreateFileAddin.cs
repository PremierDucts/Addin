using System;
using System.IO;
using Serilog;

namespace AddinsPremierducts.Utilities
{
    public class CreateFileAddin
    {
        // static readonly Serilog.ILogger log = SerilogClass._log;
        private static readonly ILogger log = Addins.SerilogClass.Log;
        public static void CreateAddins(string srcPath)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var folderDataAddins = Path.Combine(path, "AddinsPremierducts");
            if(!Directory.Exists(folderDataAddins))
                Directory.CreateDirectory(folderDataAddins);
            string fileName = folderDataAddins + "/Addins.addin";
            try
            {
                // Check if file already exists. If yes, delete it.
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"no\"?>");
                    sw.WriteLine("<FabricationAddIns>");
                    sw.WriteLine("<AddIn Type=\"Application\">");
                    sw.WriteLine("<Name>Post Data Take Off</Name>");
                    sw.WriteLine("<FullClassName>Addins.Command</FullClassName>");
                    sw.WriteLine("<Assembly>{0}/Addins/bin/Debug/Addins.dll</Assembly>",srcPath);
                    //sw.WriteLine("<Assembly>\\\\Mac\\Home\\Documents\\NEW 2024\\addinpremierducts\\Addins\\bin\\Debug/Addins.dll</Assembly>");
                    sw.WriteLine("<AddInId>B2E6C4DB-9CED-422F-BF5C-D9FADC677B67</AddInId>");
                    sw.WriteLine("</AddIn>");
                    sw.WriteLine("</FabricationAddIns>");
                }
                
                log.Information("Create Addins Success!");

                // Write file contents on console.
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                log.Error("Cannot create file Addins: " + exception.Message);
                throw exception;

            }
        }
    }
}