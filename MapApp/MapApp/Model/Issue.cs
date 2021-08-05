using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MapApp.Model
{
    public class Issue : DbContext
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Blob { get; set; }
    }
}
