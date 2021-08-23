using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace App.Models
{
    public class Multimedium
    {
        [Key]
        public int MultimediumId { get; set; }
        public int IssueId { get; set; }
        public byte[] Image { get; set; }
        public string Img { get; set; }
        public virtual IssueModel Issue { get; set; }

    }
}
