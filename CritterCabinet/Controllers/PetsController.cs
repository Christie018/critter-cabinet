using Microsoft.AspNetCore.Mvc;
using CritterCabinet.Models;

namespace CritterCabinet.Controllers
{
    public class PetsController : Controller
    {
        //Temp in-memory store
        static List<Pet> _pets = new List<Pet>
        {
            new Pet {
                Id = 1,
                Name = "Max",
                Type = "Dog",
                Breed = "Labrador",
                BirthDate = DateTime.Parse("2019-01-01"),
                Status = "Adopted" },
            new Pet {
                Id = 2,
                Name = "Whiskers",
                Type = "Cat",
                Breed = "Siamese",
                BirthDate = DateTime.Parse("2020-02-01"),
                Status = "New" },
            new Pet {
                Id = 3,
                Name = "Goldie",
                Type = "Fish",
                Breed = "Goldfish",
                BirthDate = DateTime.Parse("2021-03-01"),
                Status = "In Recovery" }
        };

        //GET: Pets
        [HttpGet]
        public IActionResult Index()
        {
            return View(_pets);
        }

        //GET: Pets/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var pet = _pets.FirstOrDefault(x => x.Id == id);
            return View(pet);
        }

        //GET: Pets/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST: Pets/ Create
        [HttpPost]
        public IActionResult Create (Pet pet)
        {
            if (ModelState.IsValid)
            {
                pet.Id = _pets.Max (x => x.Id) + 1;
                _pets.Add(pet);

                return RedirectToAction("Announcement",pet);
            }

            return View(pet);
        }

        public ActionResult Announcement(Pet newPet)
        {
            return View(newPet);
        }
    }
}
