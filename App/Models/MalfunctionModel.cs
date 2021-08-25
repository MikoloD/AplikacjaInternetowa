using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class MalfunctionModel
    {
        [Key]
        [Display(Name = "Awaria nr")]
        public int MalfunctionId { get; set; }
        [Display(Name = "Techniczny opis awarii")]
        public string MalfunctionDescription { get; set; }
        public virtual List<IssueModel> Issues{ get; set; }
    }
}
