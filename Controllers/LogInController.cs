﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheatChat.Controllers
{
    public class LogInController : Controller
    {
        // GET: /<controller>/
        [Route("LogIn")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

