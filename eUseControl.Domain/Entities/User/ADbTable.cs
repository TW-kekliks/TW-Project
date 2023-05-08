using System;
using eUseControl.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace eUseControl.Domain.Entities.User
{
    public class ADbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Doctor")]
        public Doctors Doctor { get; set; }

        [Required]
        [Display(Name = "Service")]
        public Services Service { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Time")]
        public TimeSpan Time { get; set; }

        [Required]
        [Display(Name = "Room")]
        public Rooms Room { get; set; }


        [Display(Name = "Notes")]
        [StringLength(100)]
        public string Notes { get; set; }
        

        public ARole Status { get; set; }
    }
}
