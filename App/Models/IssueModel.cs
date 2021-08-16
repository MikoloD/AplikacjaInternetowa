using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class IssueModel
    {
        [Key]
        public int IssueId { get; set; }
        public string Description { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public virtual IEnumerable<Multimedium> Images { get; set; }
    }
}
