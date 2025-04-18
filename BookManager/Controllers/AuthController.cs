using BookManager.Domain;
using BookManager.Entities;
using BookManager.Models.Forms.Utilisateur;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BookManager.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterForm form)
        {
            if(!ModelState.IsValid)
                return View(form);

            BookManagerDbContext dbContext = new BookManagerDbContext();

            dbContext.Utilisateurs.Add(new Utilisateur() { Nom = form.Nom, Prenom = form.Prenom, Email = form.Email, Mdp = form.Mdp });

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(form);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            BookManagerDbContext dbContext = new BookManagerDbContext();

            Utilisateur? utilisateur = dbContext.Utilisateurs.SingleOrDefault(u => u.Email == form.Email && u.Mdp == form.Mdp);

            if(utilisateur is null)
            {
                ModelState.AddModelError("", "Erreur email et/ou mot de passe");
                return View(form);
            }

            HttpContext.Session.SetString("Utilisateur", JsonSerializer.Serialize(utilisateur));

            return RedirectToAction("Index", "Livre");
        }
    }
}
