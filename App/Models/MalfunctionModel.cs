using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public enum State
    {
        Reported,
        InProgress,
        Finished
    }
    public class MalfunctionModel
    {
        [Key]
        public int MalfunctionId { get; set; }
        [Display(Name = "Nazwa awarii")]
        public string MalfunctionName { get; set; }
        public State State { get; set; }
        public virtual List<IssueModel> Issues{ get; set; }
    }
}
