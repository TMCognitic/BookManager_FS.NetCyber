using BookManager.Domain;
using BookManager.Entities;
using BookManager.Models.Forms.Livre;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BookManager.Controllers
{
    public class LivreController : Controller
    {
        // GET: LivreController
        public ActionResult Index()
        {
            Utilisateur? _utilisateur = null;
            string? json = HttpContext.Session.GetString("Utilisateur");

            if (json is not null)
                _utilisateur = JsonSerializer.Deserialize<Utilisateur>(json);

            if (_utilisateur is null)
                return RedirectToAction("Login", "Auth");

            BookManagerDbContext dbContext = new BookManagerDbContext();
            dbContext.Attach(_utilisateur);
            dbContext.Entry(_utilisateur).Collection(u => u.Livres).Load();

            return View(_utilisateur.Livres);
        }

        // GET: LivreController/Details/5
        public ActionResult Details(int id)
        {
            Utilisateur? _utilisateur = null;
            string? json = HttpContext.Session.GetString("Utilisateur");

            if (json is not null)
                _utilisateur = JsonSerializer.Deserialize<Utilisateur>(json);

            if (_utilisateur is null)
                return RedirectToAction("Login", "Auth");

            BookManagerDbContext dbContext = new BookManagerDbContext();
            Livre? livre = dbContext.Livres.Find(id);

            if (livre is null || livre.UtilisateurId != _utilisateur.Id)
                return RedirectToAction("Index");

            return View(livre);
        }

        // GET: LivreController/Create
        public ActionResult Create()
        {
            Utilisateur? _utilisateur = null;
            string? json = HttpContext.Session.GetString("Utilisateur");

            if (json is not null)
                _utilisateur = JsonSerializer.Deserialize<Utilisateur>(json);

            if (_utilisateur is null)
                return RedirectToAction("Login", "Auth");

            return View();
        }

        // POST: LivreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateForm form)
        {
            Utilisateur? _utilisateur = null;
            string? json = HttpContext.Session.GetString("Utilisateur");

            if (json is not null)
                _utilisateur = JsonSerializer.Deserialize<Utilisateur>(json);

            if (_utilisateur is null)
                return RedirectToAction("Login", "Auth");

            BookManagerDbContext dbContext = new BookManagerDbContext();
            dbContext.Add(new Livre() { Titre = form.Titre, Annee = form.Annee, NbrePage = form.NbrePage, Auteur = form.Auteur, UtilisateurId = _utilisateur.Id });

            try
            {
                dbContext.SaveChanges();
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(form);
            }
        }

        // GET: LivreController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            Utilisateur? _utilisateur = null;
            string? json = HttpContext.Session.GetString("Utilisateur");

            if (json is not null)
                _utilisateur = JsonSerializer.Deserialize<Utilisateur>(json);

            if (_utilisateur is null)
                return RedirectToAction("Login", "Auth");

            BookManagerDbContext dbContext = new BookManagerDbContext();
            Livre? livre = dbContext.Livres.Find(id);

            if (livre is null || livre.UtilisateurId != _utilisateur.Id)
                return RedirectToAction("Index");

            return View(new EditForm() { Titre = livre.Titre, Annee = livre.Annee, NbrePage = livre.NbrePage, Auteur = livre.Auteur });
        }

        // POST: LivreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditForm form)
        {
            ViewBag.Id = id;
            Utilisateur? _utilisateur = null;
            string? json = HttpContext.Session.GetString("Utilisateur");

            if (json is not null)
                _utilisateur = JsonSerializer.Deserialize<Utilisateur>(json);

            if (_utilisateur is null)
                return RedirectToAction("Login", "Auth");

            BookManagerDbContext dbContext = new BookManagerDbContext();
            Livre? livre = dbContext.Livres.Find(id);

            if (livre is null || livre.UtilisateurId != _utilisateur.Id)
                return RedirectToAction("Index");

            livre.Titre = form.Titre;
            livre.Annee = form.Annee;
            livre.NbrePage = form.NbrePage;
            livre.Auteur = form.Auteur;            

            try
            {
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(form);
            }
        }

        // GET: LivreController/Delete/5
        public ActionResult Delete(int id)
        {
            Utilisateur? _utilisateur = null;
            string? json = HttpContext.Session.GetString("Utilisateur");

            if (json is not null)
                _utilisateur = JsonSerializer.Deserialize<Utilisateur>(json);

            if (_utilisateur is null)
                return RedirectToAction("Login", "Auth");

            BookManagerDbContext dbContext = new BookManagerDbContext();
            Livre? livre = dbContext.Livres.Find(id);

            if (livre is null || livre.UtilisateurId != _utilisateur.Id)
                return RedirectToAction("Index");

            dbContext.Livres.Remove(livre);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
