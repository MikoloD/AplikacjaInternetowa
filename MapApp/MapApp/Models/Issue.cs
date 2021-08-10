using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MapApp.Models
{
    public class Issue : DbContext
    {
        [Key]
        [Display(Name="IdZgłoszenia")]
        public int Id { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Zdjęcia")]
        public byte[] Blob { get; set; }
    }
}
