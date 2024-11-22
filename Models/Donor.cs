using System;
using System.ComponentModel.DataAnnotations;

namespace DonorManagementAPI.Models 
{ 
    public class Donor
    {
        [Key]
        public int DonorID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DonorName { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(5)]
        public string BloodType { get; set; }
    }
}
