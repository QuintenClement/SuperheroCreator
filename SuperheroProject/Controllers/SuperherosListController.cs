using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperheroProject.Models;

namespace SuperheroProject.Controllers
{
    public class SuperherosListController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SuperherosList
        //public ActionResult Index()
        //{
        //    var superheroesList = new SuperherosList() { name = "Name: Batman", alterEgo = "Alter Ego: Bruce Wayne", catchphrase = "Catchphrase: SHABATMAN", primaryAbility = "Primary Ability: 6th sense", secondaryAbility = "Secondary Ability: Wicked crazy fighting ability" };
        //    return View(superheroesList);
        //}
        public ActionResult Index()
        {

            List<SuperherosList> superhero = db.Superheroes.ToList();
            return View(superhero);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SuperherosList superhero = db.Superheroes.Find(id);
            

            return View(superhero);
        }
        [HttpPost]
        public ActionResult Edit(SuperherosList superhero)
        {
            SuperherosList superheroInDB = db.Superheroes.SingleOrDefault(m => m.Id == superhero.Id);
            superheroInDB.name = superhero.name;
            superheroInDB.alterEgo = superhero.alterEgo;
            superheroInDB.primaryAbility = superhero.primaryAbility;
            superheroInDB.secondaryAbility = superhero.secondaryAbility;
            superheroInDB.catchphrase = superhero.catchphrase;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            if (id.Equals(db.Superheroes.ElementAt(0)))
            {
                db.Superheroes.Remove(db.Superheroes.ElementAt(id));
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            SuperherosList newSuperhero = new SuperherosList();
            return View(newSuperhero);
        }
        [HttpPost]
        public ActionResult Create(SuperherosList newSuperhero)
        {
            db.Superheroes.Add(newSuperhero);
            db.SaveChanges(); 
            return RedirectToAction("Index");

        }
    }
}