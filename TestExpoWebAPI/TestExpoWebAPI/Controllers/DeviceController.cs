using DataTableStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestExpoWebAPI.Controllers
{
    public class DeviceController : ApiController
    {
        DeviceClient client = new DeviceClient();
        [HttpGet]
        public long Get()
        {

            var deviceID = client.RetrieveAndUpdateDeviceID();
            return deviceID;
        }
    }
}
