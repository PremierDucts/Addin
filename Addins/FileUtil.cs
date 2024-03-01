using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Addins.Helpers;
using Addins.Models;
using Addins.Services;
using AddinsPremierducts;
using Autodesk.Fabrication;
using Newtonsoft.Json;
using Serilog;

namespace Addins
{
    public class FileUtil
    {
        // static readonly Serilog.ILogger log = SerilogClass._log;
        private static readonly Serilog.ILogger log = SerilogClass.Log;
        readonly string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Job.Info.FileName);
        readonly string pathDirectoryContainsFile = Path.GetDirectoryName(Job.Info.FileName);
        readonly string fileName = Path.GetFileName(Job.Info.FileName);

        public async Task<RenameModel> HanldeAndExportData()
        {
            try
            {
                Job.Save();
                RenameModel message = new RenameModel()
                {
                    Message = "",
                    hasRename = false,
                    newFileName = fileNameWithoutExtension
                };
                ResUserModel resUserModel = await Common.GetUserData();
                if (resUserModel.access_token == null)
                {
                    message.Message = "User is not logged in";
                }

                // var file_name = fileNameWithoutExtension;
                // if (file_name.Contains("rand_"))
                // {
                //     var arrStr = file_name.Split('_');
                //     file_name = String.Join("_", arrStr.Skip(2).ToArray());
                // }
                var fileNameTmp = fileNameWithoutExtension;
                if (!fileNameWithoutExtension.Contains("rand"))
                {
                    fileNameTmp = "rand_" + DateTime.Now.ToString("yMdHmsfff") + "_" + fileName;
                    message.newFileName = fileNameTmp;
                }

                var dataTakeOff = await AddinService.GetDataTakeOff(resUserModel.id, fileNameTmp);
                var jsonDataTakeOff = JsonConvert.SerializeObject(dataTakeOff.listJob);
                //Todo: check these following code because  call api 2 times
                var res = await AddinService.PostDataTakeOff(resUserModel.access_token, jsonDataTakeOff);
                message.Message = "Post success: "+Environment.NewLine+ res.Message;
                if (dataTakeOff.listJobError.Count != 0)
                {
                    await AddinService.PostDataTakeOff(resUserModel.access_token,JsonConvert.SerializeObject(dataTakeOff.listJobError));
                    message.Message += Environment.NewLine +"Post fails " + dataTakeOff.listJobError.Count + " items";
                }

                if (!fileNameWithoutExtension.Contains("rand_"))
                {
                    message.hasRename = true;
                }
                return message;
            }
            catch (Exception e)
            {
                log.Error("Handle data before post error: "+e.Message);
                return new RenameModel()
                {
                    Message = "Error: " + e,
                    hasRename = false
                }; 
            }
        }

        
        
        public void UpdateRandomFileName(string newFileName)
        {
            try
            {
                string newFilename = Path.Combine(pathDirectoryContainsFile, fileNameWithoutExtension);
                File.Delete(newFilename + ".MLK");
                if (!fileNameWithoutExtension.Contains("rand"))
                {
                    // var tempNewName = "rand_" + DateTime.Now.ToString("yMdHmsfff") + "_" + fileName;
                    var newPathRandomFileName = pathDirectoryContainsFile + "\\" + newFileName;

                    File.Copy(Job.Info.FileName, newPathRandomFileName);

                    Process.Start(newPathRandomFileName);
                    Process theprocess = Process.GetCurrentProcess();
                    string processdetails;

                    processdetails = theprocess.ProcessName.ToString() + " -" + theprocess.Id.ToString();
                    //sw.WriteLine(processdetails);

                    if (processdetails.Contains("CAMduct"))
                    {
                        //builder.AppendLine(processdetails);
                        File.Delete(Job.Info.FileName);
                        theprocess.Kill();
                    }
                    processdetails = "";
                    log.Debug("Change new filename successfully");

                }
                else
                {
                    log.Debug("Filename was kept as original");
                }
                Job.Save();
            }
            catch (Exception exception) {
                log.Debug(exception.Message);
                throw exception;
            }

        }
    }
}