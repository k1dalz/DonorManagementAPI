using System.ComponentModel.DataAnnotations;

namespace DonorManagementAPI.Models
{
    public class BloodBanks
    {
        [Key]
        public int BloodBankID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

       
        public DateTime DOB { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(5)]
        public string BloodType { get; set; }
        public int Quantity_ml { get; set; }



    }
}
