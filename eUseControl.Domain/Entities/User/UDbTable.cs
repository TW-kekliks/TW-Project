using System;
using System.ComponentModel.DataAnnotations;
using eUseControl.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.Domain.Entities.User
{
    public class UDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }

        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Username cannot be longer than 30 characters")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]

        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password ccont be shorter than 8 characters")]

        public string Password { get; set; }

        [Required]
        [Display(Name = "Email address")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email cannot be shorter than 5 characters")]

        public string Email { get; set; }

        [DataType(DataType.Date)]

        public DateTime LastLogin { get; set; }

        [StringLength(30)]
        public string LastIp { get; set; } 
        
        public URole Level { get; set; }
    }
}
