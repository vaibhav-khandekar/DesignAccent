using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBS.DTO
{
    public class CustomerByTelecallerDTO
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Retval { get; set; }

        public class CustomerByTelecallerEntity
        {
            public int id { get; set; }
            public string full_name { get; set; }
            public DateTime date { get; set; }
            public string contact_no { get; set; }
            public string email_id { get; set; }
            public string gender { get; set; }
            public string city { get; set; }
            public string age { get; set; }
            public string query { get; set; }
            public string assigned_manager { get; set; }
            public string manager_status { get; set; }
            public string assigned_executive { get; set; }
            public string executive_status { get; set; }
            public string assigned_doctor { get; set; }
            public string doctrore_status { get; set; }
            public string assigned_delivery_man { get; set; }
            public string delivery_status { get; set; }
            public string source { get; set; }

        }
        public List<CustomerByTelecallerDTO.CustomerByTelecallerEntity> CustomerByTelecallerList { get; set; }
    }
}