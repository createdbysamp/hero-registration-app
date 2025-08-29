using HeroRegistrationForm.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroRegistrationForm.Controllers;

public class HeroController : Controller
{
    // private data variables type shi

    // public variables and such

    // action methods
    [HttpGet("hero/register")]
    public IActionResult Register()
    {
        var heroTypes = new List<string> { "Warrior", "Mage", "Rouge" };
        ViewBag.HeroTypes = heroTypes;
        var viewModel = new HeroRegistrationViewModel
        {
            Name = "",
            HeroType = "",
            Level = 1,
            Email = "",
        };
        return View(viewModel);
    }

    [HttpPost("hero/register")]
    public IActionResult Register(HeroRegistrationViewModel viewModel)
    {
        // check
        // if model state is invalid
        if (!ModelState.IsValid)
        {
            // return the same view (passing viewModel back to it)
            // eg. return View(viewModel);
            // this will display the errors
            return View(viewModel);
        }
        // if model state is valid
        else if (ModelState.IsValid)
        {
            // store submitted name, herotype and email in Session as strings
            HttpContext.Session.SetString("HeroName", viewModel.Name);
            HttpContext.Session.SetString("HeroType", viewModel.HeroType);
            HttpContext.Session.SetString("HeroEmail", viewModel.Email);
            HttpContext.Session.SetString("HeroLevel", viewModel.Level.ToString());

            // redirect to a new RegistrationSuccess action method
            // eg. return RedirectToAction("Registration Success")
            return RedirectToAction("RegistrationSuccess", "Hero");
        }
        return View(viewModel);
    }

    [HttpGet("hero/registrationsuccess")]
    public IActionResult RegistrationSuccess()
    {
        return View();
    }
}
