using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.DTO
{
    public class ValidationDTO
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public class ValidationEntity
        {
            public string ID { get; set; }
            public string FullName { get; set; }
            public string EmailAddress { get; set; }
            public string MobileNumber { get; set; }
            public string Statee { get; set; }
            public string City { get; set; }
            public string Gender { get; set; }
        }
        public List<ValidationDTO.ValidationEntity> Validation_List { get; set; }
    }
}
