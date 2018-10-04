using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWifi;
using NativeWifi;
using System.Net;

namespace WiFiBF.Service.Interface
{
    /// <summary>
    /// IWifiService interface
    /// </summary>
    public interface IWifiService
    {
        /// <summary>
        /// Get list of access points in range
        /// </summary>
        List<AccessPoint> GetAvailableAccessPoints();

        /// <summary>
        /// Check if internet can be accessed
        /// </summary>
        bool IsConnectionToInternetAvailable();
    }
}
