using System;
using System.Collections.Generic;
using System.Text;

/*
 *  Standard IP Lookup - look up the data behind an IP address
 *  
    http://api.ipstack.com/ 134.201.250.155 (|,158.234.22.02) | check 
    ? access_key = YOUR_ACCESS_KEY

    // optional parameters: 

    & fields = ip, location, security
    & hostname = 1
    & security = 1
    & language = en
    & callback = MY_CALLBACK
    & output = json
*/

namespace Infra.LocationService
{
    /// <summary>
    /// 
    /// </summary>
    public class IpStackLocationService : ILocationService
    {
    }
}
