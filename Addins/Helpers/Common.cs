using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddinsPremierducts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace Addins.Helpers
{
    public class Common
    {
        // static readonly Serilog.ILogger log = SerilogClass._log;
        
        private static readonly ILogger log = SerilogClass.Log;
        public static void SaveUserData(string data)
        {
            // var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var folderDataAddins = Path.Combine(path, "AddinsPremierducts");
            if(!Directory.Exists(folderDataAddins))
                Directory.CreateDirectory(folderDataAddins);
            var appFolder = Path.Combine(folderDataAddins, "Data");
            if(!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);
            var filePath = Path.Combine(appFolder, "userdata.json");
            File.WriteAllText(filePath, data);
            log.Debug("Save user data success!");
        }
        
        public static void CreateErrorJson(string data)
        {
            // Assembly assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            // //var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            // var appFolder = Path.Combine(assembly.GetName().Name.ToLower().Contains("addinspremierducts") ?
            //         Directory.GetParent(Environment.CurrentDirectory).Parent.FullName : Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Errors");
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var folderDataAddins = Path.Combine(path, "AddinsPremierducts");
            if(!Directory.Exists(folderDataAddins))
                Directory.CreateDirectory(folderDataAddins);
            var appFolder = Path.Combine(folderDataAddins, "Errors");
            
            if(!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);
            
            var filePath = Path.Combine(appFolder, DateTime.Now.ToString("yyyyMMdd")+ "_error.json"); 
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            JObject tmp = JsonConvert.DeserializeObject<JObject>(data);
            List<JToken> detailErrors = tmp["detail"].ToList();
            detailErrors.ForEach(delegate(JToken error)
            {
                var str = "["+DateTime.Now.ToLocalTime()+"] - " + "["+ error["loc"][2] +"] - " + "["+error["loc"][3] +" - Is Empty]";
                File.AppendAllText(filePath, str + Environment.NewLine);
            });
            // foreach (var error in detailErrors)
            // {
            //     var a = error[1];
            //     File.AppendAllText(filePath, error[1] + Environment.NewLine);
            // }
            log.Error("Post data fails! Errors in: {0}",filePath);

        }


        public static async Task<ResUserModel> GetUserData()
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var folderDataAddins = Path.Combine(path, "AddinsPremierducts");
                if(!Directory.Exists(folderDataAddins))
                    Directory.CreateDirectory(folderDataAddins);
                var appFolder = Path.Combine(folderDataAddins, "Data");
                // string appFolder = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Data");
                ResUserModel resUserModel = new ResUserModel();
                string pathContainUserDataFile = Path.Combine(appFolder, "userdata.json");
                if (File.Exists(pathContainUserDataFile))
                {
                    string json = File.ReadAllText(pathContainUserDataFile);
                    resUserModel = JsonConvert.DeserializeObject<ResUserModel>(json);
                }

                return resUserModel;
            }
            catch (Exception e)
            {
                MessageBox.Show("User is not logged in", "Error Message", MessageBoxButtons.OK);
                throw e;
            }
        }
        
        public static string RemoveSillyMarks(string inputString)
        {
            string outputString = inputString;

            outputString = outputString.Replace(",", "-");
            outputString = outputString.Replace("'", "");
            outputString = outputString.Replace("\\", "");
            outputString = outputString.Replace(System.Environment.NewLine, " ");

            return outputString;
        }
        
        public static void CopyFileToFolder(string sourceLocation, string destinationLocation, string fileNameToCopy)
        {
            if (File.Exists(Path.Combine(destinationLocation, fileNameToCopy)))
                File.Delete(Path.Combine(destinationLocation, fileNameToCopy));
            File.Copy(Path.Combine(sourceLocation, fileNameToCopy), Path.Combine(destinationLocation, fileNameToCopy));
        }
        
        public static void copyFileAddinToCamduct(string sourceLocation)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var folderDataAddins = Path.Combine(path, "AddinsPremierducts");
            if(!Directory.Exists(folderDataAddins))
                Directory.CreateDirectory(folderDataAddins);
            List<string> yearList = new List<string>();
            for (var i = 2022; i <= DateTime.Now.Year; i++)
            {
                yearList.Add(i.ToString());
                if (i == DateTime.Now.Year)
                {
                    var tmp = DateTime.Now.Year + 1;
                    yearList.Add(tmp.ToString());
                }
            }
            foreach (var item in yearList)
            {
                var addinLocation = "C:/ProgramData/Autodesk/Fabrication/Addins/" + item;
                if (!Directory.Exists(addinLocation))
                    Directory.CreateDirectory(addinLocation);

                CopyFileToFolder(folderDataAddins, addinLocation, "Addins.addin");
            }
            log.Information("Copy file addin into CANDuct success!");
        }
      
        public static void DeleteFileAddinToCamduct()
        {

            List<string> yearList = new List<string>();
            for (var i = 2022; i <= DateTime.Now.Year; i++)
            {
                yearList.Add(i.ToString());
                if (i == DateTime.Now.Year)
                {
                    var tmp = DateTime.Now.Year + 1;
                    yearList.Add(tmp.ToString());
                }
            }
            foreach (var item in yearList)
            {
                var addinLocation = "C:/ProgramData/Autodesk/Fabrication/Addins/" + item;
                if (Directory.Exists(addinLocation))
                    if(File.Exists(addinLocation + "/Addins.addin"))
                        File.Delete(addinLocation + "/Addins.addin");
            }
            log.Information("Delete file addin in CAMDuct success!");
        }
    }
}