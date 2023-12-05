﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheatChat.Controllers
{
    public class ChatController : Controller
    {
        // GET: /<controller>/
        [Route("Chats")]
        public IActionResult Index()
        {
            return View();
        }
        //return to home page:
        [Route("Home")]
        public IActionResult ReturnBack(string user)
        {
            //return View("Home", user);
            return View("Index");
            //return RedirectToActionResult("Home");
        }
    }
}

