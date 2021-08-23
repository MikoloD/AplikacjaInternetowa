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
    public class IssueModel
    {
        [Key]
        [Display(Name = "Zgłoszenie nr")]
        public int IssueId { get; set; }
        public int? MalfunctionId { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public State State { get; set; }
        public virtual List<Multimedium> Images { get; set; }
        public virtual MalfunctionModel Malfunction { get; set; }
    }
}
