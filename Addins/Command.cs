using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Addins.Services;
using Autodesk.Fabrication;
using Autodesk.Fabrication.UI;

namespace Addins
{
    public class Command : IExternalApplication
    {
        //Use Execute method to as the entry point to the Addin

        public async void Execute()
        {
            try
            {
                
                FileUtil fileUltil = new FileUtil();
                var message = await fileUltil.HanldeAndExportData();

                Form form = new Form();
                form.TopMost = true;
                DialogResult dialogResult = MessageBox.Show(form,message.Message, "Message Information", MessageBoxButtons.OK);
               if (dialogResult == DialogResult.OK)
                {
                    if (message.hasRename == true)
                    {
                        fileUltil.UpdateRandomFileName(message.newFileName);
                    }
                }
              


            }
            catch(Exception ex)
            {
            }
           
        }

        //Use Terminate method to clean any resources used by the Addin
        public async void Terminate()
        {
            // FileUtil fileUltil = new FileUtil();
            // fileUltil.UpdateRandomFileName();
            // var message = await fileUltil.HanldeAndExportData();
            //
            // NativeWindow win = new NativeWindow();
            // win.AssignHandle(Process.GetCurrentProcess().MainWindowHandle);
            //
            // MessageBox.Show(win, message, "Message Information", MessageBoxButtons.OK);
            //
            // // cleanup parent safely
            // win.ReleaseHandle();
        }
    }
}

