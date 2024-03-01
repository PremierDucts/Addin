using AddinsPremierducts.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Addins;
using Addins.Helpers;
using Addins.Services;
using Newtonsoft.Json.Linq;
using Serilog;
using System.Configuration;
using System.Diagnostics.SymbolStore;
using Newtonsoft.Json;

namespace AddinsPremierducts
{
    public partial class Form1 : Form
    {
        private static readonly Serilog.ILogger log = SerilogClass.Log;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            var url = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AddinsPremierducts"); 
            username.Text = "";
            password.Text = "";
            macAddress.Text = InformationDevice.GetMacAddress();
            radio_prod.Checked = true;
            uid.Text = InformationDevice.GetUID();
            errorInput.Text = url;
            string jsonFilePath = url+"/Data/userdata.json";
            if (File.Exists(jsonFilePath))
            {
                string jsonString = File.ReadAllText(jsonFilePath);

                // Deserialize the JSON string into UserData object
                dynamic userData = JsonConvert.DeserializeObject(jsonString);

                // Access the email value
                username.Text = userData.email.ToString();

            }
             

        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(username.Text);
                Console.WriteLine(password.Text);
                UserModel userModel = new UserModel()
                {
                    Email = username.Text,
                    Password = password.Text,
                    MacAddress = macAddress.Text,
                    UID = uid.Text
                };
                MessageModel result = await LoginService.Login(this.url_label.Text,userModel);
                if (result.Status == HttpStatusCode.OK)
                {
                    btn_submit.Enabled = false;
                    btn_close.Enabled = false;
                    btn_exit.Enabled = true;
                    log.Information("Login Success");
                    // srcPath use when run develop
                    // var srcPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                    
                    // srcPath use when build
                    var srcPath = Directory.GetCurrentDirectory();
                    if (!File.Exists(srcPath+"/Addins.addin"))
                    {
                        CreateFileAddin.CreateAddins(srcPath);
                    }
                    Common.copyFileAddinToCamduct(srcPath);
                    log.Information("Copy file to CAMDuct Success !");
                    // Common.copyFileAddinToCamduct(Application.StartupPath);
                    MessageBox.Show(result.Message);
                }
                else
                {
                    btn_submit.Enabled = true;
                    btn_close.Enabled = true;
                    btn_exit.Enabled = false;
                    MessageBox.Show(result.Message);
                    log.Information("Login Fail !");

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                log.Information("Login Error: " + exception);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            deleteAllFileAddins();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            // if (Directory.Exists(addinLocation))
            //     if(File.Exists(addinLocation + "/Addins.addin"))
            //         File.Delete(addinLocation + "/Addins.addin");
            deleteAllFileAddins();
        }
        public void deleteAllFileAddins()
        {
            var srcPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            if (File.Exists(srcPath + "/Addins.addin"))
            {
                File.Delete(srcPath + "/Addins.addin");
            }
            Common.DeleteFileAddinToCamduct();
            Log.Information("Delelte file addin from CAMDUts success! ");
            Log.CloseAndFlush();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void radio_prod_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_prod.Checked)
            {
                radio_dev.Checked = false;
                UpdateConfigFile("https://prod.premierducts.com.au/api");
            }

        }

        private void radio_dev_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_dev.Checked)
            {
                radio_prod.Checked = false;
                UpdateConfigFile("https://erp.premierducts.com.au/api");
            }
        }
        private void UpdateConfigFile(string url)
        {
            this.url_label.Text = url;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var fileName = Path.Combine(path, "AddinsPremierducts/url_api.txt");
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine(url);
            }
        }
    }
}