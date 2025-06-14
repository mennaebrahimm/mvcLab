﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class Course
    {

        public int Id { get; set; }
        public string Name { get; set; }       
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hours { get; set; }
        [ForeignKey("Department")]
        public int Dept_id { get; set; }
        public Department Department { get; set; }
        public List<Instructor> Instructor { get; set; } 
        public List<Crsresult> Crsresults { get; set; }

    }
}
