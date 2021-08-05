using MapApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapApp.Controller
{
    public class DbController
    {
        private readonly Context _context;

        public DbController(Context context)
        {
            _context = context;
        }
    }
}
