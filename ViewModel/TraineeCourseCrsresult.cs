using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.ViewModel
{
    public class TraineeCourseCrsresult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        public string Trainee_name { get; set; }
        public string crs_name { get; set; }
        public string statuse { get; set; }



        
        
    }
}
