using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Code
{
    public class Parameters
    {
        public int PatientId { get; set; }
       
        public string Name { get; set; }

        public string EmailId { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public string DateOfBirth { get; set; }

        public string Age { get; set; }

        public string Gender { get; set; }

        public int DiseaseId { get; set; }

    }
}