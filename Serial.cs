using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQClient
{
    public class Serial
    {
        public string SerialNumber { get; set; } = string.Empty;
        public string AssemblyNumber { get; set;} = string.Empty;
        public string StarDate { get; set;} = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public string Resource { get; set; } = string.Empty;
        public string ResourceUserNameNT { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int id_NIDB { get; set;} = 0;
        public Serial(string serialNumber, string assemblyNumber, string starDate, string endDate, string resource, string resourceUserNameNT, string status, int id_NIDB)
        {
            SerialNumber = serialNumber;
            AssemblyNumber = assemblyNumber;
            StarDate = starDate;
            EndDate = endDate;
            Resource = resource;
            ResourceUserNameNT = resourceUserNameNT;
            Status = status;
            this.id_NIDB = id_NIDB;
        }

        public Serial()
        {
        }
    }
}
