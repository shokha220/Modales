using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.ViewModel
{
    public class PersonalViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        [Required]
        [Display(Name = "Edad")]

        public int? Edad { get; set; }
        [Required]
        [Display(Name = "IS Active")]

        public Nullable<bool> Is_active { get; set; }

    }
}