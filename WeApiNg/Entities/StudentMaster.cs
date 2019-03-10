using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeApiNg.Models
{
    public class StudentMaster
    {
        [Key]
        public int StdID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string StdName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        public string Address { get; set; }
    }
}