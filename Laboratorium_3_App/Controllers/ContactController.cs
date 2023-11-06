using Microsoft.AspNetCore.Mvc;
using Laboratorium_3_App.Models;

namespace Laboratorium_3_App.Controllers
{
    public class ContactController : Controller
    {
        //static readonly Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();
        //static int index = 1;
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            //return View(_contacts.Values.ToList());
            return View(_contactService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                //model.Id = index++;
                //_contacts[model.Id] = model;
                //return RedirectToAction("Index");
                _contactService.Add(model);
                return RedirectToAction("Index");
            }

            else
            {
                return View(model);
            }
            //return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            //return View(_contacts[id]);
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                //_contacts[model.Id] = model;
                //return RedirectToAction("Index");   
                _contactService.Update(model);
                return RedirectToAction("Index");
            }

            //return View();
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Znajdź kontakt o podanym id (jeśli istnieje)
            Contact contact = _contactService.FindById(id);

            if (contact == null)
            {
                // Obsłuż błąd, jeśli kontakt o podanym id nie istnieje
                return View("Index");
            }

            // Przekazanie kontaktu do widoku ConfirmDelete
            return View("Delete", contact);
        }

        //Uzupelnic POST dla Delete + zrobic swoja aplikacje
        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Delete(model.Id);
                return RedirectToAction("Index");
            }

            else
            {
                return View(model);
            }
        }

    }
}
