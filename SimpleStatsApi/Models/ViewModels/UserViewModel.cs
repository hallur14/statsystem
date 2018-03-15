using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleStatsApi.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string firstName { get; set; }
        
        [Required]
        public string lastName { get; set; }
        
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}