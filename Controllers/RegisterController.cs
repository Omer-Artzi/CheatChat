using Microsoft.AspNetCore.Mvc;
using CheatChat.Models;
using Microsoft.EntityFrameworkCore;

namespace CheatChat.Controllers;
public class RegisterController : Controller
{
    private readonly AppDbContext _DBcontext;

    public RegisterController(AppDbContext DBcontext)
    {
        _DBcontext = DBcontext;
        //this.databaseHelper = databaseHelper;
    }
    // GET: /<controller>/
    [HttpGet]
    [Route("RegisterSwitch")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("Register")]
    public IActionResult Register(RegisterModel user)
    {
        if (ModelState.IsValid)
        {
            _DBcontext.users.Add(user);
            _DBcontext.SaveChanges();
            //databaseHelper.Register(user);
            return RedirectToAction("Index", "Chat");
        }

        return View("chats");
    }
}



