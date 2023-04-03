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
        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Username cannot be longer than 30 characters")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]

        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password ccont be shorter than 8 characters")]

        public string Password { get; set; }
    }
}
