using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeMVC.Models
{
    public class Employe
    {
        public int Empid {  get; set; }
        public string Empname { get; set; }
        public string Empemail {  get; set; }
        public double Empsalary {  get; set; }
        public string Empjob {  get; set; }
        public string Empdept {  get; set; }
    }
}