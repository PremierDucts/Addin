using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Addins.Helpers;
using Addins.Models;
using AddinsPremierducts;
using Autodesk.Fabrication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace Addins.Services
{
    public class AddinService
    {
        // static readonly Serilog.ILogger log = SerilogClass._log;
        static readonly ILogger log = SerilogClass.Log;
        
        public static async Task<ListJobModel> GetDataTakeOff(int operator_id, string fileName)
        {
            try
            {
                var listJob = new List<JobModel>();
                var listJobError = new List<JobModel>();
                foreach (Item itm in Job.Items)
                {
                    JobModel dataObject = new JobModel();

                    dataObject.operator_id = operator_id;
                    
                    //Job No. - CustomData field
                    if (itm.CustomData[1] != null)
                    {
                        CustomItemData data = itm.CustomData[1];
                        CustomDataStringValue myCustomData = data as CustomDataStringValue;
                        dataObject.job_no = Common.RemoveSillyMarks(myCustomData.Value);
                    }
                    else
                    {
                        dataObject.job_no = "";
                    }


                    //Drawing No. - CustomData field
                    if (itm.CustomData[2] != null)
                    {
                        CustomItemData dataDrw = itm.CustomData[2];
                        CustomDataStringValue myCustomDataDrw = dataDrw as CustomDataStringValue;
                        dataObject.drawing_no = Common.RemoveSillyMarks(myCustomDataDrw?.Value);
                    }
                    else
                    {
                        dataObject.drawing_no = "";
                    }
                    
                    //Handle
                    dataObject.handle = itm.Handle.ToString("X");

                    //Item No.
                    dataObject.item_no = Common.RemoveSillyMarks(itm.Number);

                    //Insulation
                    if (itm.Insulation != null)
                    {
                        dataObject.insulation = itm.Insulation.Status.ToString();
                    }
                    else
                    {
                        dataObject.insulation = "off";
                    }

                    //Material - Galvenized
                    if (itm.Gauge != null)
                    {
                        dataObject.galvanized = itm.Gauge.Thickness;
                    }
                    else
                    {
                        dataObject.galvanized = 0;
                    }

                    //Notes
                    dataObject.notes = Common.RemoveSillyMarks(itm.Notes);

                    //Weight
                    dataObject.weight = Math.Round(itm.Weight, 2);

                    //Status
                    dataObject.status = itm.Status?.Name.ToUpper();

                    //Qty
                    dataObject.qty = itm.Quantity;

                    //Cut Type
                    dataObject.cut_type = itm.CutType.ToString();

                    //CID
                    dataObject.cid = itm.CID;

                    //Description
                    dataObject.description = Common.RemoveSillyMarks(itm.Description);

                    //Double Wall
                    dataObject.double_wall = itm.IsDoubleWall;


                    //Insulation Area
                    dataObject.insulation_area = Math.Round(itm.Insulation.Area/1000000,2);

                    //Metal Area
                    dataObject.metal_area = Math.Round(itm.Area,2);

                    
                    //Insulation Spec - Thickness only
                    dataObject.insulation_spec = itm.Insulation.Gauge.Thickness;

                    // widthDim - depthDim - lengthangle -
                    List<string> CIDexclusions = new List<string>();
                    CIDexclusions.Add("0");
                    if (!CIDexclusions.Contains(dataObject.cid.ToString()))
                    {
                        if (itm.Dimensions.Count > 0)
                        {
                            dataObject.width_dim = Math.Round(itm.Dimensions[0].Value, 0);
                        }
                        else
                        {
                            dataObject.width_dim = 0;
                        }

                        if (itm.Dimensions.Count > 1)
                        {
                            dataObject.depth_dim = Math.Round(itm.Dimensions[1].Value, 0);
                        }
                        else
                        {
                            dataObject.depth_dim = 0;
                        }

                        if (Enumerable.FirstOrDefault(itm.Dimensions) != null)
                        {
                            if (itm.Dimensions.FirstOrDefault(x => x.Name == "Length") != null)
                            {
                                dataObject.length_angle = Math.Round(itm.Dimensions.FirstOrDefault(x => x.Name == "Length").Value, 0);
                            }
                            else if (itm.Dimensions.FirstOrDefault(x => x.Name == "Angle") != null)
                            {
                                dataObject.length_angle = Math.Round(itm.Dimensions.FirstOrDefault(x => x.Name == "Angle").Value, 0);
                            }
                            else if (itm.Dimensions.FirstOrDefault(x => x.Name == "Height") != null)
                            {
                                dataObject.length_angle = Math.Round(itm.Dimensions.FirstOrDefault(x => x.Name == "Height").Value, 0);
                            }
                            else if ((itm.Dimensions.FirstOrDefault(x => x.Name == "Right Angle") != null) && (itm.Dimensions.FirstOrDefault(x => x.Name == "Left Angle") != null))
                            {
                                dataObject.length_angle = Math.Round(itm.Dimensions.FirstOrDefault(x => x.Name == "Right Angle").Value, 0) / Math.Round(itm.Dimensions.FirstOrDefault(x => x.Name == "Left Angle").Value, 0);
                            }
                        }
                        else
                        {
                            dataObject.length_angle = 0;
                        }
                        
                    }

                    //Connector
                    if (itm.Connectors.Count > 0)
                    {
                        dataObject.connector = Common.RemoveSillyMarks(itm.Connectors[0].Info.Name);
                    }
                    else
                    {
                        dataObject.connector = "";
                    }
                    
                    //Material
                    dataObject.material = itm.Material.Name;
                    
                    //File name
                    dataObject.file_name = fileName;
                    
                    //update_id ?
                    dataObject.update_id = 0;
                    
                    //bought_out
                    dataObject.bought_out = itm.BoughtOut;
                    
                    //UniqueId
                    dataObject.unique_id = itm.UniqueId;
                    
                    //prefix_string
                    if (itm.CustomData[0] != null)
                    {
                        CustomItemData prefix = itm.CustomData[0];
                        CustomDataStringValue myCustomDataPrefix = prefix as CustomDataStringValue;
                        dataObject.prefix_string = Common.RemoveSillyMarks(myCustomDataPrefix.Value.ToString());
                    }
                    else
                    {
                        dataObject.prefix_string = "";
                    }

                    //number_metal_parts
                    // if (itm.CutType == ItemCutType.MachineCut)
                    // {
                        dataObject.number_metal_parts = itm.Parts.Count(s => !s.Name.Contains("Insulation"));
                    // }
                    
                    //item_parts
                    dataObject.item_parts = itm.Parts.Select(s => new ItemPart()
                    {
                        name = !String.IsNullOrEmpty(s.Name) ? s.Name : "No Name",
                        bending_info = s.BendingInfo,
                        number = s.Number,
                        height = s.Height,
                        width = s.Width,
                        gauge_thickness = s.Gauge.Thickness
                    }).ToList();

                    if (String.IsNullOrEmpty(dataObject.job_no))
                    {
                        listJobError.Add(dataObject);
                    }
                    else
                    {
                        listJob.Add(dataObject);
                    }
                    
                }
                return new ListJobModel()
                {
                    listJob = listJob,
                    listJobError = listJobError,
                };
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw exception;
            }
            
        }
        public static async Task<MessageModel> PostDataTakeOff(string access_token,string jobModels)
        {
            var message = new MessageModel();
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Specify the path to your text file
                    var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var filePath = Path.Combine(path, "AddinsPremierducts/url_api.txt");
                   
                    // Check if the file exists
                    if (File.Exists(filePath))
                    {
                        // Read the content of the file
                        string url = File.ReadAllText(filePath);
                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + access_token);
                        url = url.Replace("\r", "").Replace("\n", "");

                        var dataTakeOff = new StringContent(jobModels, Encoding.UTF8, "application/json");
                        //HttpResponseMessage response = await httpClient.PostAsync("https://erp.premierducts.com.au/api/jobs", dataTakeOff);
                        HttpResponseMessage response = await httpClient.PostAsync(url+"/jobs", dataTakeOff);

                        var resString = await response.Content.ReadAsStringAsync();
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            JObject json = JObject.Parse(resString);
                            message = new MessageModel()
                            {
                                Status = HttpStatusCode.OK,
                                Message = json.ToString()
                            };
                            log.Information(json.ToString());
                        }
                        else
                        {
                            Common.CreateErrorJson(resString);
                        }

                    }
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return new MessageModel()
                    {
                        Status = HttpStatusCode.ExpectationFailed,
                        Message = ex.Message
                    };
                }
                return message;

            }
        }
    }
}