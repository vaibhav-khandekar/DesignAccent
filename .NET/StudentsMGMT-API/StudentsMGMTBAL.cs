using StudentsMGMT.DAL;
using StudentsMGMT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsMGMT.BAL
{
    public class StudentsMGMTBAL
    {
        StudentsMGMTDAL objSMDAL = new StudentsMGMTDAL();
        StudentsMGMTDTO objSMDTO = new StudentsMGMTDTO();
        public StudentsMGMTDTO GetStudentsDetails()
        {
            objSMDTO = objSMDAL.GetStudentsDetails();
            return objSMDTO;
        }
        public StudentsMGMTDTO AddStudentDetails(string StdName, string StdLocation, string StdAge)
        {
            objSMDTO = objSMDAL.AddStudentDetails(StdName, StdLocation, StdAge);
            return objSMDTO;
        }
        public StudentsMGMTDTO UpdateStudentDetails(int StdID, string StdName, string StdLocation, string StdAge)
        {
            objSMDTO = objSMDAL.UpdateStudentDetails(StdID, StdName, StdLocation, StdAge);
            return objSMDTO;
        }
        public StudentsMGMTDTO DeleteStudentDetails(int StdID)
        {
            objSMDTO = objSMDAL.DeleteStudentDetails(StdID);
            return objSMDTO;
        }
    }
}
