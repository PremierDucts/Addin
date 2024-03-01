using System;
using System.Management;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace AddinsPremierducts.Utilities
{
    public class InformationDevice
    {
        public InformationDevice()
        {
        }

        public static string GetUID()
        {
            var processorId = string.Empty;
            var processorManagement = new ManagementClass("Win32_Processor");

            foreach (var processor in processorManagement.GetInstances())
            {
                try
                {
                    processorId = processor["ProcessorId"].ToString();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message,"An error occured in getting processor Id",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

            return processorId;
        }
        
        public static string GetMacAddress() {
            
            var networks = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                // if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                //     nic.OperationalStatus == OperationalStatus.Up)
                // {
                //     return nic.GetPhysicalAddress().ToString();
                // }
                // else
                // {
                //     return nic.GetPhysicalAddress().ToString();
                // }

                if (nic.OperationalStatus != OperationalStatus.Up) continue;
                return nic.GetPhysicalAddress().ToString();
            }

            return "Invalid!";
        }
        
        public static void DisplayTypeAndAddress()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Console.WriteLine("Interface information for {0}.{1}     ",
                computerProperties.HostName, computerProperties.DomainName);
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length,'='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.WriteLine("  Physical Address ........................ : {0}",
                    adapter.GetPhysicalAddress().ToString());
                Console.WriteLine("  Is receive only.......................... : {0}", adapter.IsReceiveOnly);
                Console.WriteLine("  Multicast................................ : {0}", adapter.SupportsMulticast);
                Console.WriteLine();
            }
        }
    }
}