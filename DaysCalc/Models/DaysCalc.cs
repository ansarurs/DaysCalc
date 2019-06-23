
using DaysCalculator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaysCalc.Models
{
    public class DaysCalc
    {
        [Required]
        [Display(Name = "DateFrom")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateFormat DateFrom { get; set; }
        [Required]
        [Display(Name = "DateTo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateFormat DateTo { get; set; }
    }
}