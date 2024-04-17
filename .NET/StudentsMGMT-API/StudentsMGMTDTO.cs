using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsMGMT.DTO
{
    public class StudentsMGMTDTO
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public class StudentEntity
        {
            public string StdID { get; set; }
            public string StdName { get; set; }
            public string StdLocation { get; set; }
            public string StdAge { get; set; }
        }
        public List<StudentsMGMTDTO.StudentEntity> Student_List { get; set; }
    }
}
