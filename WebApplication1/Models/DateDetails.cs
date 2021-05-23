using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DateDetails
    {
        public string ApplicantName { get; set; }        
        public string DOB { get; set; }       
        public string Age { get; set; }
        public string DOJ { get; set; }
        public string DOL { get; set; }
        public string Expr { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string Mobile { get; set; }      
        public string Email { get; set; }

        public string YearRange { get; set; }

        public List<DateDetails> usersinfo { get; set; }
    }
}