﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapApp.Controllers
{
    public class IssueController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}