using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CheatChat.Models;

namespace CheatChat.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseHelper databaseHelper;

    public HomeController(ILogger<HomeController> logger, DatabaseHelper databaseHelper)
    {
        _logger = logger;
        this.databaseHelper = databaseHelper;
    }

    public IActionResult Index()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
   

    // POST: Home/LogIn
    [HttpPost]
    public ActionResult logIn(string email,string password)
    {
        //Check if user exists
        UserModel? logInUser = databaseHelper.logIn(email, password);
        if(logInUser is null)
        {
            return RedirectToAction("errorNoSuchUser");
        }    
        // Redirect to a Chats page.
        //return RedirectToAction("Chats");
        return View("Chats", logInUser);

    }

    // GET: Home/ThankYou
    public ActionResult Chats()
    {
        return View();
    }
    public ActionResult errorNoSuchUser()
    {
        return View();
    }
}